namespace ContactsApp.Shared.Services; 

public interface IAlertService {
    public Task ShowError(string title, string message);
    public Task ShowWarning(string title, string message);
    public Task ShowSuccess(string title, string message);
    public Task ShowInfo(string title, string message);
}