using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RestaurantTRPZ.BLL.Abstr.Services;
using RestaurantTRPZ.BLL.Impl.Mappers;
using RestaurantTRPZ.BLL.Impl.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.Impl
{
    public static class BLLDependencies
    {
        public static IServiceCollection RegisterBLLDependencies(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(c => c.AddProfile(new ServiceMappingProfile()));
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<ICookService, CookService>();
            services.AddTransient<IDishService, DishService>();
            services.AddTransient<IOrderService, OrderService>();
            return services;
        }
    }
}
