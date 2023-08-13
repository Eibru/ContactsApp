using ContactsApp.Shared;
using ContactsApp.Shared.Services;
using ContactsApp.Shared.ViewModels;
using ContactsApp.WpfApp.Services;
using ContactsApp.WpfApp.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ContactsApp.WpfApp;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application {
    private ServiceProvider _serviceProvider;

    public App() {
        ServiceCollection services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();
    }

    private void ConfigureServices(ServiceCollection services) {
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<IAlertService, AlertService>();
        services.AddSingleton<ContactListViewModel>();
        services.AddTransient<ContactViewModel>();
        services.AddSingleton<HttpClient>(sp => new HttpClient() { BaseAddress = new Uri("http://localhost:5050") });
        services.AddSingleton<IApiClient, ApiClient>();
        services.AddSingleton<MainWindow>();
        services.AddSingleton<ContactListView>();
        services.AddSingleton<ContactView>();

        //Navigationframe
        services.AddSingleton<Frame>();
    }

    private void OnStartup(object sender, StartupEventArgs e) {
        var mainWindow = _serviceProvider.GetService<MainWindow>();
        mainWindow.Show();
    }
}