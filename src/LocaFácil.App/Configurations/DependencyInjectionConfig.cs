using LocFácil.Business.Interfaces;
using LocFácil.Data.Context;
using LocFácil.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace LocaFácil.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();

            return services;
        }
    }
}
