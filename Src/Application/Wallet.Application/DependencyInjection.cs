using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Zamin.Extensions.DependencyInjection;
using Wallet.Infra;

namespace Wallet.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddInfrastructure();

        var assembly = typeof(DependencyInjection).Assembly;

        services.AddZaminAutoMapperProfiles(option =>
        {
            option.AssmblyNamesForLoadProfiles = assembly.ToString();
        });

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssemblies(assembly));

        services.AddValidatorsFromAssembly(assembly);


        return services;
    }
}
