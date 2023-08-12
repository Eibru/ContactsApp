using ContactsApp.Shared.Services;
using MudBlazor;

namespace ContactsApp.WasmApp.Services;

public class AlertService : IAlertService {
    private readonly ISnackbar _snackbar;

    public AlertService(ISnackbar snackbar) {
        _snackbar = snackbar;
    }

    public async Task ShowError(string title, string message) {
        _snackbar.Add(title + "\n" + message, Severity.Error);
        await Task.CompletedTask;
    }

    public async Task ShowInfo(string title, string message) {
        _snackbar.Add(title + "\n" + message, Severity.Info);
        await Task.CompletedTask;
    }

    public async Task ShowSuccess(string title, string message) {
        _snackbar.Add(title + "\n" + message, Severity.Success);
        await Task.CompletedTask;
    }

    public async Task ShowWarning(string title, string message) {
        _snackbar.Add(title + "\n" + message, Severity.Warning);
        await Task.CompletedTask;
    }
}