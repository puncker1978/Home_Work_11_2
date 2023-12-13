using Home_Work_11_2.Abstracts;

namespace Home_Work_11_2.Models.Clients
{
    public class Client : Person
    {
        #region Поля
        /// <summary>
        /// Уникальный идентификационный номер клиента
        /// </summary>
        private Guid id;

        /// <summary>
        /// Номер телефона клиента
        /// </summary>
        private string phoneNumber;
        #endregion

        #region Свойства
        /// <summary>
        /// Адрес клиента
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Паспорт клиента
        /// </summary>
        public Passport Passport { get; set; }

        /// <summary>
        /// Банковский счёт клиента
        /// </summary>
        public BankAccount BankAccount { get; set; }

        /// <summary>
        /// Уникальный идентификационный номер клиента
        /// </summary>
        public Guid Id { get => id; set => id = value; }

        /// <summary>
        /// Номер телефона клиента
        /// </summary>
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор, описывающий клиента
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="secondName">Фамилия</param>
        /// <param name="thirdName">Отчество</param>
        /// <param name="phoneNumber">Телефон</param>
        /// <param name="passport">Паспортные данные</param>
        /// <param name="address">Адрес</param>
        /// <param name="account">Банковский счёт</param>
        public Client(string firstName,
                      string secondName,
                      string thirdName,
                      string phoneNumber,
                      Passport passport,
                      Address address,
                      BankAccount bankAccount) : base(firstName, secondName, thirdName)
        {

            Id = Guid.NewGuid();
            PhoneNumber = phoneNumber;
            Passport = passport;
            Address = address;
            BankAccount = bankAccount;
        }
        #endregion Конструкторы
    }
}
