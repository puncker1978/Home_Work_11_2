using System.Reflection;
using static ReflectionSort.Repository;

namespace ReflectionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region этот код работает
            string sortBy = "LastName";
            string thenBy = "FirstName";
            List<Person> sortedPeople = SortList(Persons, sortBy, thenBy);
            foreach (Person person in sortedPeople)
            {
                Console.WriteLine($"{person.FirstName}\t {person.LastName}\t {person.Age}");
            }

            static List<Person> SortList(List<Person> list, string sortBy, string thenBy)
            {
                PropertyInfo? property1 = typeof(Person).GetProperty(sortBy);
                PropertyInfo? property2 = typeof(Person).GetProperty(thenBy);
                if (property1 != null && property2 != null)
                {
                    return [.. list.OrderBy(x => property1.GetValue(x, null)).ThenBy(x => property2.GetValue(x, null))];
                }
                else
                {
                    Console.WriteLine($"Свойство {sortBy}  или {thenBy} не найдено");
                    return list;
                }
            }
            #endregion

            Console.ReadKey();
        }
    }
}
