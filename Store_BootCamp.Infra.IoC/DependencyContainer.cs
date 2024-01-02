using Microsoft.Extensions.DependencyInjection;
using Store_BootCamp.Application.Interfaces;
using Store_BootCamp.Application.Services.Impelementations;
using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Infra.Data.Repository;

namespace Store_BootCamp.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application Layer
            services.AddScoped<IUserService, UserService>();

            //Infra Data
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
