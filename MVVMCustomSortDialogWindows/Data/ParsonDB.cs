using MVVMCustomSortDialogWindows.Models;
using System.Collections.ObjectModel;

namespace MVVMCustomSortDialogWindows.Data
{
    internal static class ParsonDB
    {
        private static readonly IEnumerable<Person> people =
        [
            new Person("Алиса", "Пряхина", 25),
            new Person("Алиса", "Нежная", 24),
            new Person("Алина", "Бушуева", 45),
            new Person("Алина", "Рубцова", 32),
            new Person("Лариса", "Бушуева", 31),
            new Person("Лариса", "Банина", 21),
            new Person("Камила", "Валиева", 34),
            new Person("Камила", "Адажина", 25),
        ];

        internal static IEnumerable<Person> People => people;
    }
}
