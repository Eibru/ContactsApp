using ContactsApp.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf.Ui.Mvvm.Contracts;

namespace ContactsApp.WpfApp.Services;
public class AlertService : IAlertService {
    private readonly ISnackbarService _snackbarService;

    public AlertService(ISnackbarService snackbarService) {
        _snackbarService = snackbarService;
    }

    public async Task ShowError(string title, string message) {
        _snackbarService.ShowAsync(title, message, Wpf.Ui.Common.SymbolRegular.Alert32, Wpf.Ui.Common.ControlAppearance.Danger);
        await Task.CompletedTask;
    }

    public async Task ShowInfo(string title, string message) {
        _snackbarService.ShowAsync(title, message, Wpf.Ui.Common.SymbolRegular.Alert32, Wpf.Ui.Common.ControlAppearance.Info);
        await Task.CompletedTask;
    }

    public async Task ShowSuccess(string title, string message) {
        _snackbarService.ShowAsync(title, message, Wpf.Ui.Common.SymbolRegular.Alert32, Wpf.Ui.Common.ControlAppearance.Success);
        await Task.CompletedTask;
    }

    public async Task ShowWarning(string title, string message) {
        _snackbarService.ShowAsync(title, message, Wpf.Ui.Common.SymbolRegular.Alert32, Wpf.Ui.Common.ControlAppearance.Caution);
        await Task.CompletedTask;
    }
}