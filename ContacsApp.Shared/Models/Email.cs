using CommunityToolkit.Mvvm.ComponentModel;

namespace ContactsApp.Shared.Models;

public partial class Email : ObservableObject{
    public int Id { get; set; }
    public int ContactId { get; set; }

    [ObservableProperty]
    private string _emailAddress;

    [ObservableProperty]
    private EmailType _emailType;
}

public enum EmailType {
    Home,
    Work,
    Other
}