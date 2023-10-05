using Home_Work_11_2.Models.Clients;

namespace Home_Work_11_2.Interfaces
{
    internal interface IClientDataMonitor
    {
        string ViewClientData(Client client);

        void EditClientData(Client oldClientData, Client newClientData);
    }
}
