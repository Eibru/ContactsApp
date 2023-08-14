using ContactsApp.Shared.Models;
using ContactsApp.Shared.Services;
using ContactsApp.Shared.ViewModels;
using ContactsApp.WpfApp.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ContactsApp.WpfApp.Services;

public class NavigationService : INavigationService {
    private readonly IServiceProvider _serviceProvider;
    private readonly Frame _navigationFrame;

    public NavigationService(IServiceProvider serviceProvider, Frame navigationFrame) { 
        _serviceProvider = serviceProvider;
        _navigationFrame = navigationFrame;
    }

    public async Task GoToContact(int contactId) {
        var contactView = _serviceProvider.GetRequiredService<ContactView>();
        if(contactId > 0)
            await ((ContactViewModel)contactView.DataContext).LoadContact(contactId);

        _navigationFrame.Navigate(contactView);
    }

    public async Task GoToContactList() {
        var contactListView = _serviceProvider.GetRequiredService<ContactListView>();
        await ((ContactListViewModel)contactListView.DataContext).Load();
        _navigationFrame.Navigate(contactListView);
    }
}