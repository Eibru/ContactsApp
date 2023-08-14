using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactsApp.Shared.Models;
using ContactsApp.Shared.Services;

namespace ContactsApp.Shared.ViewModels;

public partial class ContactListViewModel : ObservableObject {
    private readonly IApiClient _apiClient;
    private readonly INavigationService _navigationService;
    private readonly IAlertService _alertService;

    [ObservableProperty]
    private List<Contact> _contacts = new List<Contact>();

    [ObservableProperty]
    private bool _loading;

    public ContactListViewModel(IApiClient apiClient, INavigationService navigationService, IAlertService alertService) {
        _apiClient = apiClient;
        _navigationService = navigationService;
        _alertService = alertService;
    }

    public async Task Load() {
        Loading = true;

        try {
            Contacts = await _apiClient.GetContacts();
        } catch(Exception ex) {
            await _alertService.ShowError("Error loading contacts", ex.Message);
        } finally {
            Loading = false;
        }
    }

    [RelayCommand]
    private async Task ViewContact(int id) {
        await _navigationService.GoToContact(id);
    }
}
