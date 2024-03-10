using Framework.Serializer;
using Microsoft.EntityFrameworkCore;
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
        services.AddDbContext<WalletDbContext>(option => option.UseSqlServer("server=YasiAbdn\\ABDN;initial catalog=Db-Wallet;integrated Security=true;TrustServerCertificate=True", b => b.MigrationsAssembly("Wallet.Api")));


        services.AddTransient<ITransactionRepository, TransactionRepository>();
        services.AddTransient<IWalletRepository, WalletRepository>();

        services.AddTransient<IJsonSerializer, NewtonSoftSerializer>();

        return services;
    }
}
