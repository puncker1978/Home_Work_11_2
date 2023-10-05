using Home_Work_11_2.Interfaces;
using Home_Work_11_2.Models.Clients;

namespace Home_Work_11_2.Models.Employees
{
    internal class Consultant : Employee, IClientDataMonitor
    {
        #region Конструкторы
        public Consultant(string firstName,
            string secondName,
            string thirdName) : base(firstName,
                secondName, thirdName)
        {
        }
        #endregion

        #region Методы

        public override void EditClientData(Client oldClientData, Client newClientData)
        {
            //Консультант может изменить только номер телефона
            oldClientData.PhoneNumber = newClientData.PhoneNumber;
        }

        public override string ViewClientData(Client client)
        {
            string str = "";
            return str;
        }
        #endregion
    }
}
