using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RestaurantTRPZ.BLL.Config;
using RestaurantTRPZ.BLL.Services;
using RestaurantTRPZ.BLL.Services.Interfaces;
using RestaurantTRPZ.DAL.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.DI
{
    public static class BLLService
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            services.RegisterDataServices();

            services.AddSingleton<IDishService, DishService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<ICookQueueService, CookQueueService>();
            services.AddSingleton<IOrderTimeCalculationService, OrderTimeCalculationService>();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfig());
            });
            services.AddSingleton(configuration.CreateMapper());
            return services;
        }
    }
}
