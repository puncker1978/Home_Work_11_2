using MVVMCustomSort.Data;
using MVVMCustomSort.Models;
using MVVMCustomSort.Utilities;
using MVVMCustomSort.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Linq.Dynamic.Core;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMCustomSort.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Person> _persons;
        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set
            {
                if(value != _persons)
                {
                    _persons = value;
                    OnPropertyChanged();
                }
            }
        }

        static private IEnumerable<Person> SortClient(ObservableCollection<Person> persons)
        {
            IEnumerable<Person> result = persons.AsQueryable().OrderBy("Age desc");
            return result;
        }

        public MainViewModel()
        {
            Persons = PersonDB.GetPersons();
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
            SortPersonCommand = new RelayCommand(SortPerson, CanSortPerson);
        }


        #region Команды
        public ICommand ShowWindowCommand { get; set; }
        private bool CanShowWindow(object obj) => true;
        private void ShowWindow(object obj)
        {
            var mainWindow = obj as MainWindow;
            AddPersonWindow addPersonWindow = new AddPersonWindow();
            addPersonWindow.Owner = mainWindow;
            addPersonWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addPersonWindow.ShowDialog();
        }

        public ICommand SortPersonCommand { get; set; }
        private bool CanSortPerson(object obj) => true;
        private void SortPerson(object obj)
        {
            Persons = new ObservableCollection<Person>(SortClient(Persons));
        }
        #endregion

        #region Реализация интерфейса INotifyPropertyChanged
        /// <summary>Событие для извещения об изменения свойства</summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
