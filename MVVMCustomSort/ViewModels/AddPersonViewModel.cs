using MVVMCustomSort2.Data;
using MVVMCustomSort2.Models;
using MVVMCustomSort2.Utilities;
using MVVMCustomSort2.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;

namespace MVVMCustomSort2.ViewModels
{
    class AddPersonViewModel : INotifyPropertyChanged
    {
        #region Поля
        private string? name;
        private int? age;
        #endregion Поля

        #region Свойства
        public string? Name
        {
            get => name;
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }
        public int? Age
        {
            get => age;
            set
            {
                if (value != age)
                {
                    age = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion Свойства

        #region Конструкторы
        public AddPersonViewModel()
        {
            AddPersonCommand = new RelayCommand(AddPerson, CanAddPerson);
        }
        #endregion Конструкторы

        #region Команды

        #region Команда добавления персоны
        public ICommand AddPersonCommand { get; set; }
        private bool CanAddPerson(object obj) => Name != "" && 0 < Age && Age < 120;
        private void AddPerson(object obj)
        {
            PersonDB.AddNewPerson(new Person(Name, Age));
            
            //Получить ссылку на текущее окно
            AddPersonWindow? window = Application.Current.Windows.OfType<AddPersonWindow>().SingleOrDefault(x => x.IsActive);

            // Закрыть текущее окно
            window?.Close();
        }
        #endregion Команда добавления персоны

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
