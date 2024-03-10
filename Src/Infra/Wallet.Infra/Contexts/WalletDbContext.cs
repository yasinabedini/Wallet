using Framework.Entities;
using Framework.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Wallet.Domain.Models.Transaction.Entities;
using Wallet.Domain.Models.Wallet.Entities;

namespace Wallet.Infra.Contexts;

public class WalletDbContext : DbContext
{
    public WalletDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Domain.Models.Wallet.Entities.Wallet> Wallets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore(typeof(BusinessId));

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WalletDbContext).Assembly);

        #region Query Filter
        Expression<Func<AggregateRoot, bool>> filterExprForAggregate = bm => !bm.IsDelete;
        foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes())
        {
            // check if current entity type is child of BaseModel
            if (mutableEntityType.ClrType.IsAssignableTo(typeof(AggregateRoot)))
            {
                // modify expression to handle correct child type
                var parameter = Expression.Parameter(mutableEntityType.ClrType);
                var body = ReplacingExpressionVisitor.Replace(filterExprForAggregate.Parameters.First(), parameter, filterExprForAggregate.Body);
                var lambdaExpression = Expression.Lambda(body, parameter);

                // set filter
                mutableEntityType.SetQueryFilter(lambdaExpression);
            }
        }

        Expression<Func<Entity, bool>> filterExprForEntity = bm => !bm.IsDelete;
        foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes())
        {
            // check if current entity type is child of BaseModel
            if (mutableEntityType.ClrType.IsAssignableTo(typeof(Entity)))
            {
                // modify expression to handle correct child type
                var parameter = Expression.Parameter(mutableEntityType.ClrType);
                var body = ReplacingExpressionVisitor.Replace(filterExprForEntity.Parameters.First(), parameter, filterExprForEntity.Body);
                var lambdaExpression = Expression.Lambda(body, parameter);

                // set filter
                mutableEntityType.SetQueryFilter(lambdaExpression);
            }
        }
        #endregion

        base.OnModelCreating(modelBuilder);
    }
}
