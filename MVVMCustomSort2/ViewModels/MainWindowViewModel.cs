﻿using MVVMCustomSort2.Data;
using MVVMCustomSort2.Models;
using MVVMCustomSort2.Utilities;
using MVVMCustomSort2.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Linq.Dynamic.Core;

namespace MVVMCustomSort2.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Поля
        private ObservableCollection<Person> persons;
        #endregion Поля

        #region Свойства
        public ObservableCollection<Person> Persons
        {
            get { return persons; }
            set
            {
                if (value != persons)
                {
                    persons = value;
                    OnPropertyChanged(nameof(Persons));
                }
            }
        }
        #endregion Свойства

        #region Методы
        static private IEnumerable<Person> SortClientMethod(ObservableCollection<Person> _persons)
        {
            IEnumerable<Person> result = _persons.AsQueryable().OrderBy("Name asc");
            return result;
        }
        #endregion Методы

        #region Конструкторы
        public MainWindowViewModel()
        {
            Persons = PersonDB.GetPersons();
            SortPersonCommand = new RelayCommand(SortPerson, CanSortPerson);
            ShowSortWindowCommand = new RelayCommand(ShowSortWindow, CanShowSortWindow);
        }
        #endregion Конструкторы

        #region Команды

        #region Команда открытия окна для сортировки персон
        public ICommand ShowSortWindowCommand { get; set; }
        private bool CanShowSortWindow(object obj) => true;
        private void ShowSortWindow(object obj)
        {
            var mainWindow = obj as MainWindow;
            SortWindow sortWindow = new SortWindow
            {
                Owner = mainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            sortWindow.ShowDialog();
        }
        #endregion

        #region Команда сортировки персон
        public ICommand SortPersonCommand { get; set; }
        private bool CanSortPerson(object obj) => true;
        private void SortPerson(object obj)
        {

            //Получить ссылку на текущее окно
            SortWindow sortWindow = Application.Current.Windows.OfType<SortWindow>().SingleOrDefault(x => x.IsActive);

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
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion Реализация интерфейса INotifyPropertyChanged
    }
}