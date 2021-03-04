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
        public static IServiceCollection RegisterDALDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton(new RestaurantContext(connectionString));

            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IDishRepository, DishRepository>();
            services.AddSingleton<ICookRepository, CookRepository>();
            services.AddSingleton<IEquipmentRepository, EquipmentRepository>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
