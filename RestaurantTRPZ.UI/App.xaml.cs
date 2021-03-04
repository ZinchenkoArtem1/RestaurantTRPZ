using Microsoft.Extensions.DependencyInjection;
using RestarauntTRPZ.DAL.Impl;
using RestaurantTRPZ.BLL.Impl;
using RestaurantTRPZ.UI.View;
using RestaurantTRPZ.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantTRPZ.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
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
            services.RegisterDALDependencies("RestaurantConnectionDB");
            services.RegisterBLLDependencies();
            services.RegisterUIDependencies();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainViewModel viewModel = serviceProvider.GetService<MainViewModel>();
            MainWindow mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.DataContext = viewModel;
            MainWindow.Show();
        }
    }
}
