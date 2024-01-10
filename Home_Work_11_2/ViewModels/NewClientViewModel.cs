using Home_Work_11_2.Infra;
using Home_Work_11_2.Models.Clients;
using Home_Work_11_2.Models.Data;
using Home_Work_11_2.Views;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Home_Work_11_2.ViewModels
{
    internal class NewClientViewModel : INotifyPropertyChanged
    {
        #region Поля

        #region Фамилия, имя, отчество, номер телефона
        private string firstName;
        private string secondName;
        private string thirdName;
        private string phoneNumber;
        #endregion
        
        #region Паспорт
        private int passportSeries;
        private string passportNumber;
        private DateOnly birthDate;
        #endregion

        #region Адрес
        private string town;
        private string street;
        private string houseNumber;
        private string flatNumber;
        #endregion

        #region Банковский счёт
        private decimal sum;
        #endregion

        #endregion Поля

        #region Свойства

        #region Фамилия, Имя, Отчество, номер телефона
        public string FirstName
        { 
            get => firstName;
            set
            {
                if (value != firstName)
                {
                    firstName = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string SecondName
        {
            get => secondName;
            set
            {
                if (value != secondName)
                {
                    secondName = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string ThirdName
        {
            get => thirdName;
            set
            {
                if (value != thirdName)
                {
                    thirdName = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (value != phoneNumber)
                {
                    phoneNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region Паспорт
        public int PassportSeries
        {
            get => passportSeries;
            set
            {
                if (value != passportSeries)
                {
                    passportSeries = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string PassportNumber
        {
            get => passportNumber;
            set
            {
                if (value != passportNumber)
                {
                    passportNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public DateOnly BirthDate
        {
            get => birthDate;
            set
            {
                if (value != birthDate)
                {
                    birthDate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region Адрес
        public string Town
        {
            get => town;
            set
            {
                if (value != town)
                {
                    town = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Street
        {
            get => street;
            set
            {
                if (value != street)
                {
                    street = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string HouseNumber
        {
            get => houseNumber;
            set
            {
                if (value != houseNumber)
                {
                    houseNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string FlatNumber
        {
            get => flatNumber;
            set
            {
                if (value != flatNumber)
                {
                    flatNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region Банковский счёт
        public decimal Sum
        {
            get => sum;
            set
            {
                if (value != sum)
                {
                    sum = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #endregion Свойства

        #region Конструкторы
        public NewClientViewModel()
        {
            AddNewClientCommand = new RelayCommand(AddNewClient, CanAddNewClient);
        }
        #endregion Конструкторы

        #region Команды
        public ICommand AddNewClientCommand { get; set; }
        private bool CanAddNewClient(object obj)
        {
            return !string.IsNullOrWhiteSpace(SecondName) && !string.IsNullOrWhiteSpace(FirstName) &&
                !string.IsNullOrWhiteSpace(PhoneNumber) && !string.IsNullOrWhiteSpace(PassportSeries.ToString()) &&
                !string.IsNullOrWhiteSpace(PassportNumber) && !string.IsNullOrWhiteSpace(BirthDate.ToString()) &&
                !string.IsNullOrWhiteSpace(Town) && !string.IsNullOrWhiteSpace(Street)! && !string.IsNullOrWhiteSpace(HouseNumber);
        }
        private void AddNewClient(object obj)
        {
            Repository.AddNewClient(new Client(FirstName, SecondName, ThirdName, PhoneNumber,
                new Passport(PassportSeries, PassportNumber, BirthDate),
                new Address(Town, Street, HouseNumber, FlatNumber),
                new BankAccount(Sum)));

            //Получить ссылку на текущее окно
            NewClientWindow? window = Application.Current.Windows.OfType<NewClientWindow>().SingleOrDefault(x => x.IsActive);

            // Закрыть текущее окно
            window?.Close();
        }
        #endregion Команды

        #region Реализация интерфейса INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Реализация интерфейса INotifyPropertyChanged
    }
}
