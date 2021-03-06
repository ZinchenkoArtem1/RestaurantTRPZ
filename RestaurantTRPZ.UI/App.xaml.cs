using Microsoft.Extensions.DependencyInjection;
using RestarauntTRPZ.DAL.Impl;
using RestaurantTRPZ.BLL.Abstr.Services;
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
            services.RegisterDALDependencies();
            services.RegisterBLLDependencies();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainViewModel viewModel = new MainViewModel(serviceProvider.GetService<IDishService>(), serviceProvider.GetService<IOrderService>());
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = viewModel;
            MainWindow.Show();
        }
    }
}
