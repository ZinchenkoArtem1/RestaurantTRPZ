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

            services.AddSingleton<ICookService, CookService>();
            services.AddSingleton<IDishService, DishService>();
            services.AddSingleton<IOrderService, OrderService>();
            return services;
        }
    }
}
