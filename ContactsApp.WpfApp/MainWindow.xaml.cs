using ContactsApp.Shared.Services;
using ContactsApp.Shared.ViewModels;
using ContactsApp.WpfApp.Services;
using ContactsApp.WpfApp.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ContactsApp.WpfApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow {
    private readonly INavigationService _navigationService;
    private readonly IServiceProvider _serviceProvider;
    private readonly Wpf.Ui.Mvvm.Contracts.ISnackbarService _snackbarService;

    public MainWindow(INavigationService navigationService, IServiceProvider sp, Frame navigationFrame, Wpf.Ui.Mvvm.Contracts.ISnackbarService snackbarService) {
        InitializeComponent();

        _navigationService = navigationService;
        _serviceProvider = sp;

        frame.Content = navigationFrame;
        _snackbarService = snackbarService;

        _snackbarService.SetSnackbarControl(RootSnackbar);
    }

    public async void NavigateToContactList(object sender, EventArgs e) {
        await _navigationService.GoToContactList();
    }

}