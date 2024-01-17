﻿using MVVMCustomSort2.Data;
using MVVMCustomSort2.Models;
using MVVMCustomSort2.Utilities;
using MVVMCustomSort2.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Linq.Dynamic.Core;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace MVVMCustomSort2.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Person> _persons;
        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set
            {
                if (value != _persons)
                {
                    _persons = value;
                    OnPropertyChanged(nameof(Persons));
                }
            }
        }

        static private IEnumerable<Person> SortClientMethod(ObservableCollection<Person> persons)
        {
            IEnumerable<Person> result = persons.AsQueryable().OrderBy("Name asc");
            return result;
        }

        public MainWindowViewModel()
        {
            Persons = PersonDB.GetPersons();
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
            SortPersonCommand = new RelayCommand(SortPerson, CanSortPerson);
            ShowSortWindowCommand = new RelayCommand(ShowSortWindow, CanShowSortWindow);
        }

        #region Команды

        #region Команда открытия окна для добавления новой персоны
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
        #endregion

        #region Команда открытия окна для сортировки персон
        public ICommand ShowSortWindowCommand { get; set; }
        private bool CanShowSortWindow(object obj) => true;
        private void ShowSortWindow(object obj)
        {
            var mainWindow = obj as MainWindow;
            SortWindow sortWindow = new SortWindow();
            sortWindow.Owner = mainWindow;
            sortWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            sortWindow.ShowDialog();
        }
        #endregion

        #region Команда сортировки персон
        public ICommand SortPersonCommand { get; set; }
        private bool CanSortPerson(object obj) => true;
        private void SortPerson(object obj)
        {

            //Получить ссылку на текущее окно
            SortWindow? sortWindow = Application.Current.Windows.OfType<SortWindow>().SingleOrDefault(x => x.IsActive);

            Persons = new ObservableCollection<Person>(SortClientMethod(Persons));
            foreach (var p in Persons)
            {
                Debug.WriteLine(p.Name);
            }

            // Закрыть текущее окно
            sortWindow?.Close();

        }
        #endregion Команда сортировки персон

        #endregion Команды

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