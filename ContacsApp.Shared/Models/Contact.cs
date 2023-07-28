using System;
namespace ContactsApp.Shared.Models
{
	public class Contact
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string? MiddleName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }

		public string Name => FirstName
			+ (!string.IsNullOrEmpty(MiddleName) ? " " + MiddleName : "")
			+ (!string.IsNullOrEmpty(LastName) ?  " " + LastName : "");
	}
}

