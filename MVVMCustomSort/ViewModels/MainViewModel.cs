using MVVMCustomSort.Data;
using MVVMCustomSort.Models;
using MVVMCustomSort.Utilities;
using MVVMCustomSort.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MVVMCustomSort.ViewModels
{
    class MainViewModel
    {
        public ObservableCollection<Person> Persons { get; set; }

        public MainViewModel()
        {
            Persons = PersonDB.GetPersons();
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }

        public ICommand ShowWindowCommand { get; set; }
        private bool CanShowWindow(object obj) => true;
        private void ShowWindow(object obj)
        {
            var mainWindow = obj as Window;
            AddPersonWindow addPersonWindow = new AddPersonWindow();
            addPersonWindow.Owner = mainWindow;
            addPersonWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addPersonWindow.Show();
        }
    }
}
