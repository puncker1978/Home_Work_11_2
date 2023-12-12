using System.Reflection;
using static MyCustomSortProject.Repository;
using System.Linq.Dynamic.Core;
using System.Collections.ObjectModel;

namespace MyCustomSortProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string orderBy = "LastName";
            string thenBy = "FirstName";

            static void ShowCollection(IEnumerable<Person> collection)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine($"{item.LastName}\t {item.FirstName}\t\t {item.Age}");
                }
                Console.WriteLine();
            }

            ShowCollection(Persons);

            static IEnumerable<Person> SortCollection(IEnumerable<Person> collection)
            {
                return collection.AsQueryable().OrderBy("LastName asc").ToList();
            }

            IEnumerable<Person> sortedPersons = SortCollection(Persons);
            ShowCollection(sortedPersons);

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
