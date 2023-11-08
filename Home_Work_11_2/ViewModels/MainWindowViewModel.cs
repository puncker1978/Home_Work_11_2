using Home_Work_11_2.Infra;
using Home_Work_11_2.Models.Clients;
using Home_Work_11_2.Models.Data;
using Home_Work_11_2.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Home_Work_11_2.ViewModels
{
    internal class MainWindowViewModel
    {
        public string FirstName {  get; set; }
        public string SecondName {  get; set; }
        public string ThirdName { get; set; }
        public string PhoneNumber { get; set; }

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

            NewClientWindow newClientWindow = new();
            newClientWindow.Owner = mainWindow;
            newClientWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newClientWindow.ShowDialog();
        }
    }
}
