using Home_Work_11_2.Infra;
using Home_Work_11_2.Models.Clients;
using Home_Work_11_2.Models.Data;
using Home_Work_11_2.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Home_Work_11_2.ViewModels
{
    internal class EditClientViewModel : INotifyPropertyChanged
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

        public static Client Client { get; set; }

        #region Фамилия, Имя, Отчество, номер телефона
        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName != value)
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
                if (secondName != value)
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
                if (thirdName != value)
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
                if (phoneNumber != value)
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
                if (passportSeries != value)
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
                if (passportNumber != value)
                {
                    passportNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public DateOnly BirthDate
        {
            get => DateOnly.Parse(BirthDay);
            set
            {
                BirthDay = value.ToString();
                NotifyPropertyChanged();
            }
        }
        public string BirthDay { get; set; }
       
        #endregion

        #region Адрес
        public string Town
        {
            get => town;
            set
            {
                town = value;
                NotifyPropertyChanged();
            }
        }
        public string Street
        {
            get => street;
            set
            {
                if (street != value)
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
                if (houseNumber != value)
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
                if (flatNumber != value)
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
                if (sum != value)
                {
                    sum = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #endregion Свойства

        #region Конструкторы
        public EditClientViewModel(Client client) 
        {
            Client = client;
            FirstName = client.FirstName;
            SecondName = client.SecondName;
            ThirdName = client.ThirdName;
            PhoneNumber = client.PhoneNumber;
            PassportSeries = client.Passport.PassportSeries;
            PassportNumber = client.Passport.PassportNumber;
            BirthDate = client.Passport.BirthDate;
            Town = client.Address.Town;
            Street = client.Address.Street;
            HouseNumber = client.Address.HouseNumber;
            FlatNumber = client.Address.FlatNumber;
            Sum = client.BankAccount.Sum;
            EditClientCommand = new RelayCommand(EditClient, CanEditClient);
        }
        #endregion Конструкторы

        #region Команды
        public ICommand EditClientCommand { get; set; }
        private bool CanEditClient(object obj)
        {
            return !string.IsNullOrWhiteSpace(SecondName) && !string.IsNullOrWhiteSpace(FirstName) &&
                !string.IsNullOrWhiteSpace(PhoneNumber) && !string.IsNullOrWhiteSpace(PassportSeries.ToString()) &&
                !string.IsNullOrWhiteSpace(PassportNumber) && !string.IsNullOrWhiteSpace(BirthDate.ToString()) &&
                !string.IsNullOrWhiteSpace(Town) && !string.IsNullOrWhiteSpace(Street)! && !string.IsNullOrWhiteSpace(HouseNumber);
        }
        private void EditClient(object obj)
        {
            Client newClient = new(FirstName, SecondName, ThirdName, PhoneNumber,
                    new Passport(PassportSeries, PassportNumber, BirthDate),
                    new Address(Town, Street, HouseNumber, FlatNumber),
                    new BankAccount(Sum));
            Repository.EditClient(Client, newClient);

            //Получить ссылку на текущее окно
            EditClientWindow? window = Application.Current.Windows.OfType<EditClientWindow>().SingleOrDefault(x => x.IsActive);

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
