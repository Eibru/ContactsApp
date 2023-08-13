using CommunityToolkit.Mvvm.ComponentModel;

namespace ContactsApp.Shared.Models;

public partial class Phone : ObservableObject{
    public int Id { get; set; }
    public int ContactId { get; set; }

    [ObservableProperty]
    private string _phoneNumber;

    [ObservableProperty]
    private PhoneType _phoneType;
}

public enum PhoneType {
    Mobile,
    Home,
    Work,
    Other
}
