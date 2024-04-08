using Framework.Serializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wallet.Domain.Models.Transaction.Repositories;
using Wallet.Domain.Models.Wallet.Repositories;
using Wallet.Infra.Contexts;
using Wallet.Infra.Models.Transaction.Repositories;
using Wallet.Infra.Models.Wallet.Repositories;


namespace Wallet.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

        services.AddDbContext<WalletDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));


        services.AddTransient<ITransactionRepository, TransactionRepository>();
        services.AddTransient<IWalletRepository, WalletRepository>();

        services.AddTransient<IJsonSerializer, NewtonSoftSerializer>();

        return services;
    }
}
