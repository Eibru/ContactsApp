using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactsApp.Shared.Models;
using ContactsApp.Shared.Services;

namespace ContactsApp.Shared.ViewModels;

public partial class ContactViewModel : ObservableObject {
	private readonly IApiClient _apiClient;
	private readonly INavigationService _navigationService;
	private readonly IAlertService _alertService;

	[ObservableProperty]
	private Contact _contact = new Contact();

	[ObservableProperty]
	private bool _loading;

	public ContactViewModel(IApiClient apiClient, INavigationService navigationService, IAlertService alertService) {
		_apiClient = apiClient;
		_navigationService = navigationService;
		_alertService = alertService;
	}

	public async Task LoadContact(int id) {
		Loading = true;

		try {
			Contact = await _apiClient.GetContact(id);
		} catch(Exception ex) {
			await _alertService.ShowError("Error loading contact", ex.Message);
		} finally {
			Loading = false;
		}
	}

	[RelayCommand]
	private async Task Close() {
		await _navigationService.GoToContactList();
	}

	[RelayCommand]
	private async Task Delete() {
		Loading = true;

		try {
			await _apiClient.DeleteContact(Contact.Id);
			await _alertService.ShowSuccess("Contact deleted", "");
			await _navigationService.GoToContactList();
		} catch(Exception ex) {
			await _alertService.ShowError("Error deleting contact", ex.Message);
		} finally {
			Loading = false;
		}
	}

	[RelayCommand]
	private async Task Save() {
		if(Contact.Id == 0)
			await CreateContact();
		else
			await UpdateContact();
	}

	[RelayCommand]
	private void AddEmail() {
		Contact.EmailAddresses.Add(new Email());
		OnPropertyChanged(nameof(Contact.EmailAddresses));
	}

	[RelayCommand]
	private void AddPhone() {
		Contact.PhoneNumbers.Add(new Phone());
		OnPropertyChanged(nameof(Contact.PhoneNumbers));
	}

    [RelayCommand]
    private void RemoveEmail(int id) { //TODO - this does not remove the email
		var item = Contact.EmailAddresses.First(x => x.Id == id);
		Contact.EmailAddresses.Remove(item);
    }

    [RelayCommand]
    private void RemovePhone(int id) { //TODO - this does not remove the email
        var item = Contact.PhoneNumbers.First(x => x.Id == id);
        Contact.PhoneNumbers.Remove(item);
    }

    private async Task CreateContact() {
		Loading = true;

		try {
			Contact = await _apiClient.CreateContact(Contact);
			await _alertService.ShowSuccess("Contact created", "");
		} catch(Exception ex) {
			await _alertService.ShowError("Error adding contact", ex.Message);
		} finally {
			Loading = false;
		}
	}

	private async Task UpdateContact() {
		Loading = true;

		try {
			await _apiClient.UpdateContact(Contact);
			await _alertService.ShowSuccess("Contact updated", "");
		} catch(Exception ex) {
			await _alertService.ShowError("Error updating contact", ex.Message);
		} finally {
			Loading = false;
		}
	}
}