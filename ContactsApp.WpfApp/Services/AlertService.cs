using ContactsApp.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContactsApp.WpfApp.Services;
public class AlertService : IAlertService {
    public async Task ShowError(string title, string message) {
        MessageBox.Show(message, title);
    }

    public async Task ShowInfo(string title, string message) {
        MessageBox.Show(message, title);
    }

    public async Task ShowSuccess(string title, string message) {
        MessageBox.Show(message, title);
    }

    public async Task ShowWarning(string title, string message) {
        MessageBox.Show(message, title);
    }
}