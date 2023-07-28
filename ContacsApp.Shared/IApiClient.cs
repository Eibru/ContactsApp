using System;
using ContactsApp.Shared.Models;

namespace ContactsApp.Shared
{
	public interface IApiClient
	{
		public Task<Contact> GetContact(int id);
		public Task<List<Contact>> GetContacts();
		public Task UpdateContact(Contact contact);
		public Task<Contact> CreateContact(Contact contact);
		public Task DeleteContact(int id);
	}
}

