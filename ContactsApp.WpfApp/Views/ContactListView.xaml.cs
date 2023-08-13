using ContactsApp.Shared.ViewModels;
using System.Windows.Controls;

namespace ContactsApp.WpfApp.Views;

/// <summary>
/// Interaction logic for ContactListView.xaml
/// </summary>
public partial class ContactListView {
    public ContactListView(ContactListViewModel viewModel){
        InitializeComponent();

        DataContext = viewModel;
    }
}
