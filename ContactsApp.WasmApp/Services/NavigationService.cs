using ContactsApp.Shared.Services;
using Microsoft.AspNetCore.Components;

namespace ContactsApp.WasmApp.Services;

public class NavigationService : INavigationService {
    private readonly NavigationManager _navigationManager;

    public NavigationService(NavigationManager navigationManager) {
        _navigationManager = navigationManager;
    }

    public async Task GoToContact(int contactId) {
        await Task.CompletedTask;
        _navigationManager.NavigateTo($"/contacts/{contactId}");
    }

    public async Task GoToContactList() {
        await Task.CompletedTask;
        _navigationManager.NavigateTo("/contacts");
    }
}