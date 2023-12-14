// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using Home_Work_11_2.Infra;
using Home_Work_11_2.Models.Clients;
using Home_Work_11_2.Models.Data;
using Home_Work_11_2.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Linq.Dynamic.Core;
using System.Diagnostics;

namespace Home_Work_11_2.ViewModels
{
    internal class MainWindowViewModel : PropertyChangedBase
    {
        #region Константы

        private static readonly string[] colNames = { "Фамилия", "Имя", "Отчество", "Дата рождения", "Сумма на счёте", "Телефон" };
        private static readonly string[] sortDirection = { "По возрастанию", "По убыванию" };

        private readonly Dictionary<string, string> sortParameterDictionary = new Dictionary<string, string>()
        {
            [ColNames[0]] = "SecondName",
            [ColNames[1]] = "FirstName",
            [ColNames[2]] = "ThirdName",
            [ColNames[3]] = "BirthDate",
            [ColNames[4]] = "Sum",
            [ColNames[5]] = "PhoneNumber"
        };
        private readonly Dictionary<string, string> sortDirectionDictionary = new Dictionary<string, string>()
        {
            [SortDirection[0]] = "asc",
            [SortDirection[1]] = "desc"
        };

        #endregion Константы

        #region Поля
        public static string[] ColNames => colNames;
        public static string[] SortDirection => sortDirection;

        private string _searchText;
        private ObservableCollection<Client> _filteredClients;

        private string _firstSortParameter;
        private string _firstSortDirection;
        private string _firstArgumentSort;

        private string _secondSortParameter;
        private string _secondSortDirection;
        private string _secondArgumentSort;

        #endregion Поля

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
        public ObservableCollection<Client> FilteredClients
        {
            get => _filteredClients;
            set
            {
                _filteredClients = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Client> Clients { get; set; }
        public string FirstSortParameter
        {
            get => _firstSortParameter;
            set
            {
                _firstSortParameter = value;
                NotifyPropertyChanged();
            }
        }
        public string FirstSortDirection
        {
            get => _firstSortDirection;
            set
            {
                _firstSortDirection = value;
                NotifyPropertyChanged();
            }
        }
        public string FirstArgumentSort
        {
            get => _firstArgumentSort;
            set
            {
                _firstArgumentSort = FirstSortParameter + " " + FirstSortDirection;
                NotifyPropertyChanged();
            }
        }
        public string SecondSortParameter
        {
            get { return _secondSortParameter; }
            set
            {
                _secondSortParameter = value;
                NotifyPropertyChanged();
            }
        }
        public string SecondSortDirection
        {
            get => _secondSortDirection;
            set
            {
                _secondSortDirection = value;
                NotifyPropertyChanged();
            }
        }
        public string SecondArgumentSort
        {
            get => _secondArgumentSort;
            set
            {
                _secondArgumentSort = SecondSortParameter + " " + SecondSortDirection;
                NotifyPropertyChanged();
            }
        }

        #endregion Свойства

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
            ShowSortClientWindowCommand = new RelayCommand(ShowSortClientWindow, CanShowSortClientWindow);
            SortClientCommand = new RelayCommand(SortClient, CanSortClient);
        }

        public MainWindowViewModel()
        {
            Clients = Repository.GetClients();
            FilteredClients = Repository.GetClients();
            SortClientCommand = new RelayCommand(SortClient, CanSortClient);
        }
        #endregion Конструкторы

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

        //Сортировка по фамилии по возрастанию с использованием Dynamic LINQ
        //(Не зависит от данных combobox'ов в окне сортировки)
        static private IEnumerable<Client> SortClientMethod(ObservableCollection<Client> clients)
        {
            IEnumerable<Client> result = clients.AsQueryable().OrderBy("SecondName asc");
            return result;
        }

        #endregion Методы

        #region Команды

        #region Команда сортировки
        //Команда сортировки клиентов
        public ICommand SortClientCommand { get; set; }
        private bool CanSortClient(object obj)
        {
            //return (!string.IsNullOrEmpty(FirstSortParameter) && !string.IsNullOrEmpty(FirstSortDirection));
            return true;
        }
        private void SortClient(object obj)
        {
            SortClientWindow? sortClientWindow = Application.Current.Windows.OfType<SortClientWindow>().SingleOrDefault(x => x.IsActive);

            FilteredClients = new ObservableCollection<Client>(SortClientMethod(Clients));

            sortClientWindow?.Close();

            foreach (var client in FilteredClients)
            {
                Debug.WriteLine($"{client.SecondName}");
            }
        }
        #endregion Команда сортировки
        
        #region Команда открытия окна для сортировки клиентов
        //Команда открытия окна для редактирования клиента
        public ICommand ShowSortClientWindowCommand { get; set; }
        private bool CanShowSortClientWindow(object obj)
        {
            return true;
        }
        private void ShowSortClientWindow(object obj)
        {
            var mainWindow = obj as Window;

            SortClientWindow sortClientWindow = new()
            {
                Owner = mainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            sortClientWindow.ShowDialog();
        }
        #endregion

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
        
        #endregion Команды
    }
}
