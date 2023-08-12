namespace ContactsApp.Shared.Models; 

public class Contact {
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string? MiddleName { get; set; }
	public string? LastName { get; set; }

	public virtual ICollection<Email> EmailAddresses { get; set; } = new List<Email>();
	public virtual ICollection<Phone> PhoneNumbers { get; set; } = new List<Phone>();

	public string Name => FirstName
		+ (!string.IsNullOrEmpty(MiddleName) ? " " + MiddleName : "")
		+ (!string.IsNullOrEmpty(LastName) ? " " + LastName : "");
}