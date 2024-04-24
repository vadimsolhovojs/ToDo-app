using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace TODO.UseCases;

public static class Setup
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        services.AddAutoMapper(assembly);
        services.AddValidatorsFromAssembly(assembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        return services;
    }
}