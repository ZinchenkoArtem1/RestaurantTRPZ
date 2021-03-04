using Microsoft.Extensions.DependencyInjection;
using RestaurantTRPZ.UI.View;
using RestaurantTRPZ.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantTRPZ.UI
{
    public static class UIDependencies
    {
        public static IServiceCollection RegisterUIDependencies(this IServiceCollection services)
        {
            services.AddSingleton<MainViewModel, MainViewModel>();
            services.AddSingleton<MainWindow, MainWindow>();
            return services;
        }
    }
}
