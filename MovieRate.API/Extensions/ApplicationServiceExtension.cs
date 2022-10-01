using MovieRate.Core.Interfaces;
using MovieRate.Infrastructure.Repositories;
using MovieRate.Infrastructure.Services;

namespace MovieRate.API.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddServiceCollection(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient(typeof(IUnitOfWork),typeof(UnitOfWork));
        services.AddTransient(typeof(ITokenService), typeof(TokenService));
        services.AddTransient(typeof(IXmlHandler<>), typeof(XmlHandler<>));
        return services;
    }
}