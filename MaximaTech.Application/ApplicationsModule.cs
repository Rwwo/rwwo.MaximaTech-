using System.Reflection;

using Microsoft.Extensions.DependencyInjection;



namespace MaximaTech.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application.ApplicationModule).Assembly));
        }
    }
}
