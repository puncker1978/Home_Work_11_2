using Home_Work_11_2.Infra;
using Home_Work_11_2.Models.Clients;
using Home_Work_11_2.Models.Data;
using Home_Work_11_2.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Home_Work_11_2.ViewModels
{
    internal class MainWindowViewModel : PropertyChangedBase
    {
        #region Поля
        private string _searchText;
        #endregion

        #region Методы
        private void UpdateFilteredClients()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredClients = new ObservableCollection<Client>(Clients);
            }
            else
            {
                FilteredClients = new ObservableCollection<Client>(
                    Clients.Where(
                        client => client.FirstName.Contains(
                            SearchText, StringComparison.OrdinalIgnoreCase)));
            }
        }
        #endregion


        #region Свойства
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    NotifyPropertyChanged(nameof(SearchText));
                    UpdateFilteredClients();
                }
            }
        }
        public static string? Position { get; set; }
        public static Client? SelectedClient { get; set; }
        public ObservableCollection<Client> FilteredClients { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        #endregion

        #region Конструкторы
        public MainWindowViewModel(string position)
        {
            Clients = Repository.GetClients();
            FilteredClients = Repository.GetClients();
            Position = position;
            ShowAddNewClientWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
            DeleteClientCommand = new RelayCommand(DeleteClient, CanDeleteClient);
            ShowEditClientWindowCommand = new RelayCommand(ShowEditClientWindow, CanShowEditClientWindow);
            SearchClientCommand = new RelayCommand(SearchClient, CanSearchClient);
        }
        #endregion

        #region Команды
        #region Команда открытия окна для добавления нового клиента
        //Команда открытия окна для добавления нового клиента
        public ICommand ShowAddNewClientWindowCommand { get; set; }
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
        #endregion

        #region Команда открытия окна для редактирования клиента
        //Команда открытия окна для редактирования клиента
        public ICommand ShowEditClientWindowCommand { get; set; }
        private bool CanShowEditClientWindow(object obj)
        {
            return true;
        }
        private void ShowEditClientWindow(object obj)
        {
            var mainWindow = obj as Window;

            EditClientWindow editClientWindow = new(SelectedClient)
            {
                Owner = mainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            editClientWindow.ShowDialog();
            
        }
        #endregion

        #region Команда для удаления клиента
        //Команда для удаления клиента
        public ICommand DeleteClientCommand { get; set; }
        private bool CanDeleteClient(object obj)
        {
            return SelectedClient != null;
        }
        private void DeleteClient(object obj)
        {
            Repository.RemoveClient(SelectedClient);
        }
        #endregion

        #region Команда поиска клиента
        //Команда для поиска клиента
        public ICommand SearchClientCommand { get; set; }
        private bool CanSearchClient(object obj)
        {
            return !string.IsNullOrWhiteSpace(SearchText);
        }
        private void SearchClient(object obj)
        {
            UpdateFilteredClients();
        }
        #endregion
        #endregion Команды
    }
}
