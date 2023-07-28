using System;
namespace ContactsApp.Shared.Services
{
	public interface INavigationService
	{
		public Task GoToContactList();
		public Task GoToContact(int contactId);
	}
}

