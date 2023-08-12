using System;
using System.Net.Http.Json;
using ContactsApp.Shared.Models;

namespace ContactsApp.Shared;

public interface IApiClient {
    public Task<Contact> GetContact(int id);
    public Task<List<Contact>> GetContacts();
    public Task UpdateContact(Contact contact);
    public Task<Contact> CreateContact(Contact contact);
    public Task DeleteContact(int id);
}

public class ApiClient : IApiClient {
    private readonly HttpClient _httpClient;

    public ApiClient(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public async Task<Contact> CreateContact(Contact contact) {
        var response = await _httpClient.PostAsJsonAsync("/Contacts/", contact);
        response.EnsureSuccessStatusCode();

        Console.WriteLine("Ok");

        return await response.Content.ReadFromJsonAsync<Contact>();
    }

    public async Task DeleteContact(int id) {
        var response = await _httpClient.DeleteAsync($"/Contacts/{id}/");
        response.EnsureSuccessStatusCode();
    }

    public async Task<Contact> GetContact(int id) {
        var response = await _httpClient.GetAsync($"/Contacts/{id}/");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Contact>();
    }

    public async Task<List<Contact>> GetContacts() {
        var response = await _httpClient.GetAsync("/Contacts/");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<Contact>>();
    }

    public async Task UpdateContact(Contact contact) {
        var response = await _httpClient.PutAsJsonAsync("/Contacts/", contact);
        response.EnsureSuccessStatusCode();
    }
}