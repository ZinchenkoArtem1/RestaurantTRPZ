using Microsoft.Extensions.DependencyInjection;
using RestarauntTRPZ.DAL.Impl;
using RestaurantTRPZ.BLL.Abstr.Services;
using RestaurantTRPZ.BLL.Impl;
using RestaurantTRPZ.CMD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.CMD
{
    class App
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
         
        private void ConfigureServices(IServiceCollection services)
        {
            services.RegisterDALDependencies();
            services.RegisterBLLDependencies();
            services.RegisterCMDDependencies();
        }

        public void Run()
        {
            IUserInterface consoleMenu = serviceProvider.GetRequiredService<IUserInterface>();
            consoleMenu.Show();
        }
    }
}
