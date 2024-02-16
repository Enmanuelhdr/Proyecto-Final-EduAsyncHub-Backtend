using ProyectoFinal.Interfaces;
using ProyectoFinal.Services;
using ProyectoFinal.Validations;

namespace ProyectoFinal.Configuration
{
    public static class DepencyInjection
    {
        public static void GetDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IValidationsManager, ValidationsManager>();
            services.ValidatorsInjections();
        }
    }
}
