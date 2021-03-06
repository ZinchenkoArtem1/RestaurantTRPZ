using Microsoft.Extensions.DependencyInjection;
using RestarauntTRPZ.DAL.Abstr.Repositories;
using RestarauntTRPZ.DAL.Abstr.UOW;
using RestarauntTRPZ.DAL.Impl.EF;
using RestarauntTRPZ.DAL.Impl.Repositories;
using RestarauntTRPZ.DAL.Impl.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntTRPZ.DAL.Impl
{
    public static class DALDependencies
    {
        public static IServiceCollection RegisterDALDependencies(this IServiceCollection services)
        {
            services.AddScoped<RestaurantContext, RestaurantContext>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IDishRepository, DishRepository>();
            services.AddScoped<ICookRepository, CookRepository>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
