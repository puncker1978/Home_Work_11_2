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
        private Client selectedClient;
        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
                NotifyPropertyChanged();
            }
        }

        private Employee employee;
        public Employee Employee
        {
            get => employee;
            set
            {
                employee = value;
                NotifyPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            Clients = Repository.GetClients();

            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }

        public ObservableCollection<Client> Clients { get; set; }

        public ICommand ShowWindowCommand { get; set; }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            var mainWindow = obj as Window;

            NewClientWindow newClientWindow = new()
            {
                Owner = mainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            newClientWindow.ShowDialog();
        }
    }
}
