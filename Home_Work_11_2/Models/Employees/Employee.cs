using Home_Work_11_2.Abstracts;
using Home_Work_11_2.Interfaces;
using Home_Work_11_2.Models.Clients;

namespace Home_Work_11_2.Models.Employees
{
    public abstract class Employee : Person, IClientDataMonitor
    {
        public static string Position;

        #region Конструкторы
        /// <summary>
        /// Конструктор для инициализации сотрудника
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="secondName">Фамилия</param>
        /// <param name="thirdName">Отчество</param>
        /// <param name="positionFlag">Доступность свойств окна</param>
        public Employee(string firstName,
                        string secondName,
                        string thirdName) : base(firstName, secondName, thirdName)
        {
        }
        #endregion

        #region Методы

        public virtual string ViewClientData(Client client)
        {
            throw new NotImplementedException();
        }

        public virtual void EditClientData(Client oldClientData, Client newClientData)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
