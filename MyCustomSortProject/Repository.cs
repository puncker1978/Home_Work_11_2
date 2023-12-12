using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomSortProject
{
    internal static class Repository
    {
        public static ObservableCollection<Person> Persons =
        [
            new Person("Иван", "Николаев", 26),
            new Person("Иван", "Степанов", 21),
            new Person("Анна", "Николаева", 24),
            new Person("Анна", "Владимирова", 28),
            new Person("Борис", "Корчевников", 20),
            new Person("Борис", "Инжуватов", 26),
            new Person("Абрам", "Инжуватов", 22),
            new Person("Данна", "Владимирова", 21),
            new Person("Лариса", "Николаева", 24),
            new Person("Игнат", "Степанов", 26)
        ];
    }
}
