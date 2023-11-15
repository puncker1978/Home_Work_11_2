using Home_Work_11_2.Infra;
using Home_Work_11_2.Models.Clients;
using Home_Work_11_2.Models.Data;
using Home_Work_11_2.Models.Employees;
using Home_Work_11_2.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Home_Work_11_2.ViewModels
{
    internal class MainWindowViewModel : PropertyChangedBase
    {
        public static bool Flag => Position == "Менеджер";
        public static string? Position {  get; set; }
        
        public static Client? SelectedClient {  get; set; }

        public MainWindowViewModel(string position)
        {
            Clients = Repository.GetClients();
            Position = position;
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }

        public ObservableCollection<Client> Clients { get; set; }

        public ICommand ShowWindowCommand { get; set; }

        private bool CanShowWindow(object obj)
        {
            return Position == "Менеджер";
        }

        private void ShowWindow(object obj)
        {
            var mainWindow = obj as Window;

            NewClientWindow newClientWindow = new()
            {
                Owner = mainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            newClientWindow.ShowDialog();
        }
    }
}
