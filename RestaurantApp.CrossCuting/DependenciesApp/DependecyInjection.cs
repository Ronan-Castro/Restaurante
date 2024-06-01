using RestaurantApp.Domain.Interfaces;
using RestaurantApp.Infrastructure.Context;
using RestaurantApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RestaurantApp.CrossCuting.DependenciesApp
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder>? dbContextOptionsAction = null)
        {
            // Adiciona DbContext ao serviço (isso é configurado no WebServer e Maui
            services.AddDbContext<ApplicationDbContext>(dbContextOptionsAction);
           
            
            // Adicionar serviços conforme necessário
            services.AddScoped<IGrupoRepository, GrupoRepository>();
 
            return services;
        }
    }
}
