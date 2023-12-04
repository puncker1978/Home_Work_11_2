using static ReflectionSort.Repository;

namespace ReflectionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (Person person in Persons)
            {
                Console.WriteLine($"{person.FirstName}\t {person.LastName}\t {person.Age}");
            }
            Console.WriteLine();



            Type type = typeof(Person);
            var prop1 = type.GetProperty("LastName");
            var prop2 = type.GetProperty("FirstName");


            List<Person> sortedPersons = (from person in Persons
                                          orderby person.GetType().GetProperty("LastName").Name
                                          select person) as List<Person>;


            foreach (Person person in sortedPersons)
            {
                Console.WriteLine($"{person.FirstName}\t {person.LastName}\t {person.Age}");
            }


            Console.ReadKey();
        }
    }
}
