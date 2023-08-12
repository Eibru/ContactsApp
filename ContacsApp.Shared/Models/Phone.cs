namespace ContactsApp.Shared.Models;

public class Phone {
    public int Id { get; set; }
    public string PhoneNumber { get; set; }
    public PhoneType PhoneType { get; set; }
    public int ContactId { get; set; }
}

public enum PhoneType {
    Mobile,
    Home,
    Work,
    Other
}
