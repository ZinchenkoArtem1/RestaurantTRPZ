using Microsoft.Extensions.DependencyInjection;
using RestaurantTRPZ.BLL.DI;
using RestaurantTRPZ.BLL.Services.Interfaces;
using RestaurantTRPZ.WPF.View;
using RestaurantTRPZ.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantTRPZ.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider ServiceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider(validateScopes: true);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.RegisterBusinessServices();
            services.AddScoped<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            IDishService dishService = ServiceProvider.GetService<IDishService>();
            var viewModel = new MainViewModel(dishService);
            Console.WriteLine("afsdafsf");
            MainWindow mainWindow = ServiceProvider.GetService<MainWindow>();
            mainWindow.DataContext = viewModel;
            mainWindow.Show();
        }
    }
}
