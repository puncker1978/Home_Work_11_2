using Home_Work_11_2.Models.Clients;
using System.Collections.ObjectModel;

namespace Home_Work_11_2.Models.Data
{
    internal static class Repository
    {
        public static ObservableCollection<Client> Clients = new()
        {
            new Client("Иван", "Лукьянов", "Ильич", "+7(915)382-25-36", new Passport(5221, "326587", new DateOnly(2001, 05, 12)), new Address("Гомель", "ул. Гончарная", "4а", "12"), new BankAccount(decimal.Parse("12530,25"))),
            new Client("Мария", "Мошина", "Ивановна", "+7(923)384-21-36", new Passport(5238, "124556", new DateOnly(1987, 08, 15)), new Address("Кемерово", "ул. Пастернака", "15", "22"), new BankAccount(decimal.Parse("25230,21"))),
            new Client("Сергей", "Ильин", "Геннадьевич", "+7(907)532-20-06", new Passport(4238, "253698", new DateOnly(1989, 03, 05)), new Address("Иркутск", "ул. Полевая", "21", "7"), new BankAccount(decimal.Parse("37420,26"))),
            new Client("Андрей", "Бедный", "Николаевич", "+7(922)945-17-38", new Passport(5438, "144785", new DateOnly(1969, 01, 12)), new Address("Оренбург", "ул. Терешковой", "10/2", "77а"), new BankAccount(decimal.Parse("56789,12"))),
            new Client("Елена", "Васнецова", "Николаевна", "+7(902)341-75-12", new Passport(3838, "124536", new DateOnly(1978, 06, 21)), new Address("Омск", "ул. Театральная", "2б", "11"), new BankAccount(decimal.Parse("51236,12")))
        };

        public static void AddClient(Client client) => Clients.Add(client);

        public static void RemoveClient(Client client) => Clients.Remove(client);

        public static void EditClient(Client oldClient, Client newClient)
        {
            RemoveClient(oldClient);
            AddClient(newClient);
        }

        public static ObservableCollection<Client> GetClients() => Clients;
    }
}
