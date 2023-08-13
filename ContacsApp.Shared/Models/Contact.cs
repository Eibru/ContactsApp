using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ContactsApp.Shared.Models; 

public partial class Contact : ObservableObject {
    public Contact() {
        EmailAddresses = new ObservableCollection<Email>();
        PhoneNumbers = new ObservableCollection<Phone>();
    }

	public int Id { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Name))]
    private string _firstName;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Name))]
    private string? _middleName;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Name))]
    private string? _lastName;

    [ObservableProperty]
    private ObservableCollection<Email> _emailAddresses;

    [ObservableProperty]
    private ObservableCollection<Phone> _phoneNumbers;

	public string Name => FirstName
		+ (!string.IsNullOrEmpty(MiddleName) ? " " + MiddleName : "")
		+ (!string.IsNullOrEmpty(LastName) ? " " + LastName : "");
}