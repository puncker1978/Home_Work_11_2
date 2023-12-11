using Home_Work_11_2.Models.Clients;
using System.Collections.ObjectModel;

namespace Home_Work_11_2.Models.Data
{
    internal static class Repository
    {
        public static ObservableCollection<Client> Clients = new()
        {
            new Client("Иван", "Лукьянов", "Ильич", "+7(915)382-25-36", new Passport(5221, "326587", new DateOnly(2001, 05, 12)), new Address("Гомель", "ул. Гончарная", "4а", "12"), new BankAccount(12547.25m)),
            new Client("Мария", "Мошина", "Ивановна", "+7(923)384-21-36", new Passport(5238, "124556", new DateOnly(1987, 08, 15)), new Address("Кемерово", "ул. Пастернака", "15", "22"), new BankAccount(25698.45m)),
            new Client("Сергей", "Ильин", "Геннадьевич", "+7(907)532-20-06", new Passport(4238, "253698", new DateOnly(1989, 03, 05)), new Address("Иркутск", "ул. Полевая", "21", "7"), new BankAccount(456987.56m)),
            new Client("Андрей", "Бедный", "Николаевич", "+7(922)945-17-38", new Passport(5438, "144785", new DateOnly(1969, 01, 12)), new Address("Оренбург", "ул. Терешковой", "10/2", "77а"), new BankAccount(12589.89m)),
            new Client("Елена", "Васнецова", "Николаевна", "+7(902)341-75-22", new Passport(3838, "124536", new DateOnly(1978, 06, 21)), new Address("Омск", "ул. Театральная", "2б", "11"), new BankAccount(456925.78m)),
            new Client("Елена", "Мошина", "Игоревна", "+7(902)341-45-12", new Passport(3838, "124534", new DateOnly(1972, 06, 15)), new Address("Орск", "ул. Привокзальная", "21", "11"), new BankAccount(456987.78m)),
            new Client("Тамара", "Васнецова", "Андреевна", "+7(902)344-75-12", new Passport(3838, "124536", new DateOnly(1976, 08, 21)), new Address("Минск", "ул. Серова", "11", "11"), new BankAccount(43287.78m)),
            new Client("Сергей", "Васнецов", "Петрович", "+7(902)341-55-12", new Passport(3838, "124536", new DateOnly(1974, 08, 15)), new Address("Москва", "ул. Димитрова", "17", "11"), new BankAccount(452887.78m)),
            new Client("Афанасий", "Васнецов", "Олегович", "+7(902)343-75-12", new Passport(3838, "127536", new DateOnly(1974, 11, 21)), new Address("Чита", "ул. Баха", "24б", "11"), new BankAccount(456987.78m)),
            new Client("Мария", "Иванова", "Ивановна", "+7(902)341-75-00", new Passport(3838, "124538", new DateOnly(1977, 12, 23)), new Address("Смоленск", "ул. Цветочная", "17б", "11"), new BankAccount(126987.78m)),
            new Client("Афанасий", "Воронцов", "Сергеевич", "+7(902)342-74-10", new Passport(3838, "424536", new DateOnly(1969, 08, 16)), new Address("Брянск", "ул. Ночная", "3б", "11"), new BankAccount(156987.78m)),
            new Client("Андрей", "Миронов", "Петрович", "+7(902)351-00-12", new Passport(3838, "124506", new DateOnly(1966, 09, 21)), new Address("Иркутск", "ул. Весенняя", "23", "11"), new BankAccount(516987.78m)),
            new Client("Сергей", "Миронов", "Ильич", "+7(902)311-07-15", new Passport(3838, "124535", new DateOnly(1971, 09, 03)), new Address("Муром", "ул. Заречная", "15", "11"), new BankAccount(17987.78m)),
            new Client("Тамара", "Мошина", "Николаевна", "+7(902)241-17-17", new Passport(3838, "624536", new DateOnly(1956, 12, 24)), new Address("Самара", "ул. Льва толстого", "26", "11"), new BankAccount(38987.78m)),
            new Client("Игорь", "Лукьянов", "Сергеевич", "+7(902)941-70-02", new Passport(3838, "124036", new DateOnly(1969, 02, 21)), new Address("Челябинск", "ул. Поля Лафарга", "4а", "11"), new BankAccount(656987.78m))
        };

        public static void AddNewClient(Client client) => Clients.Add(client);

        public static void RemoveClient(Client client) => Clients.Remove(client);

        public static void EditClient(Client oldClient, Client newClient)
        {
            RemoveClient(oldClient);
            AddNewClient(newClient);
        }

        public static ObservableCollection<Client> GetClients() => Clients;
    }
}
