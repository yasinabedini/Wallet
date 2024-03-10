using Framework.Serializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wallet.Infra.Contexts;


namespace Wallet.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<WalletDbContext>(option => option.UseSqlServer("server=YasiAbdn\\ABDN;initial catalog=Db-Wallet;integrated Security=true;TrustServerCertificate=True", b => b.MigrationsAssembly("Wallet.Api")));

        services.AddTransient<IJsonSerializer, NewtonSoftSerializer>();

        return services;
    }
}
