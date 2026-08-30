
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.DnsClient.Util.Registrars;
using Soenneker.Utils.String.Registrars;
using Soenneker.Validators.Email.Mx.Abstract;

namespace Soenneker.Validators.Email.Mx.Registrars;

/// <summary>
/// A validation module checking for the existance of domain MX records
/// </summary>
public static class EmailMxValidatorRegistrar
{
    /// <summary>
    /// Adds <see cref="IEmailMxValidator"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddEmailMxValidatorAsSingleton(this IServiceCollection services)
    {
        services.AddStringUtilAsSingleton();
        services.AddDnsClientUtilAsSingleton();
        services.TryAddSingleton<IEmailMxValidator, EmailMxValidator>();
        return services;
    }

    /// <summary>
    /// Adds <see cref="IEmailMxValidator"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddEmailMxValidatorAsScoped(this IServiceCollection services)
    {
        services.AddStringUtilAsScoped();
        services.AddDnsClientUtilAsSingleton();
        services.TryAddScoped<IEmailMxValidator, EmailMxValidator>();
        return services;
    }
}
