using Home_Work_11_2.Interfaces;
using Home_Work_11_2.Models.Clients;

namespace Home_Work_11_2.Models.Employees
{
    internal class Manager : Employee, IClientDataMonitor
    {
        public static readonly string Position = "Менеджер";

        #region Конструкторы
        public Manager(string firstName,
            string secondName,
            string thirdName) : base(firstName, secondName, thirdName)
        {
        }

        #endregion

        #region Методы
        public override void EditClientData(Client oldClientData, Client newClientData)
        {
            oldClientData = newClientData;
        }

        public override string ViewClientData(Client client)
        {
            string str = "";
            return str;
        }
        #endregion
    }
}
