using MVVMCustomSort3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCustomSort3.Data
{
    internal static class PersonDB
    {
        public static ObservableCollection<Person> Persons = new ObservableCollection<Person>()
        {
            new Person("Анна", 25),
            new Person("Борис", 24),
            new Person("Валентина", 41),
            new Person("Алиса", 32),
            new Person("Алиса", 40),
            new Person("Алина", 21),
            new Person("Анна", 32),
            new Person("Анна", 24),
            new Person("Борис", 32),
            new Person("Борис", 18),
            new Person("Борис", 18),
            new Person("Валентина", 32),
            new Person("Валентина", 22),
            new Person("Владислава", 23),
        };

        public static ObservableCollection<Person> GetPersons() => Persons;

        public static void AddNewPerson(Person person) => Persons.Add(person);

        public static void DeletePerson(Person person) => Persons.Remove(person);
    }
}
