using Microsoft.Extensions.DependencyInjection;
using RestaurantTRPZ.CMD.Impl;
using RestaurantTRPZ.CMD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.CMD
{
    public static class CMDDeendencies
    {
        public static IServiceCollection RegisterCMDDependencies(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IDataReader), typeof(ConsoleDataReader));
            services.AddSingleton(typeof(IDataWritter), typeof(ConsoleDataWritter));
            services.AddSingleton(typeof(IUserInterface), typeof(ConsoleUserInterface));
            return services;
        }
    }
}
