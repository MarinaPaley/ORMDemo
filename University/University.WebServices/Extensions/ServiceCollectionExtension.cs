namespace University.WebServices.Controllers
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(MapConfigurator))
                .AddScoped(sp => sp.GetService<MapConfigurator>().CreateMapper());
        }
    }
}
