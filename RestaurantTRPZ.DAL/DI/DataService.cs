using Microsoft.Extensions.DependencyInjection;
using RestaurantTRPZ.DAL.EF;
using RestaurantTRPZ.DAL.Repositories;
using RestaurantTRPZ.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.DI
{
    public static class DataServices
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services)
        {
            
            services.AddSingleton<RestaurantContext>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IDishRepository, DishRepository>();
            services.AddSingleton<ICookRepository, CookRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IEquipmentRepository, EquipmentRepository>();
            

            return services;
        }
    }
}
