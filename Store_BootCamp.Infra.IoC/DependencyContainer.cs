using Microsoft.Extensions.DependencyInjection;
using Store_BootCamp.Application.Convertor;
using Store_BootCamp.Application.Services.Impelementations;
using Store_BootCamp.Application.Services.Interfaces;
using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Infra.Data.Repository;

namespace Store_BootCamp.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application Layer
            services.AddTransient<IViewRenderService, RenderViewToString>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IContactService, ContactService>();

            //Infra Data
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
        }
    }
}
