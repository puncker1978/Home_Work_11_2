﻿using MVVMCustomSort2.Data;
using MVVMCustomSort2.Models;
using MVVMCustomSort2.Utilities;
using MVVMCustomSort2.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Linq.Dynamic.Core;
using System.Runtime.CompilerServices;

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
            get => persons; 
            set
            {
                if (value == persons) return;
                else
                {
                    persons = value;
                    OnPropertyChanged(nameof(Persons));
                }
            }
        }
        #endregion Свойства

        #region Методы
        static private IEnumerable<Person> SortClientMethod(IEnumerable<Person> _persons)
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
            ShowSortParameterWindowCommand = new RelayCommand(ShowSortParameterWindow, CanShowSortParameterWindow);
        }
        #endregion Конструкторы

        #region Команды

        #region Команда открытия окна для сортировки персон
        public ICommand ShowSortParameterWindowCommand { get; set; }
        private bool CanShowSortParameterWindow(object obj) => true;
        private void ShowSortParameterWindow(object obj)
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
            IEnumerable<Person> Persons = (IEnumerable<Person>)obj;
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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion Реализация интерфейса INotifyPropertyChanged
    }
}