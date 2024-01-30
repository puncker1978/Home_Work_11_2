namespace MVVMCustomSortDialogWindows.Models
{
    internal class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person()
        {
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Age { get => age; set => age = value; }

        public Person(string _firstName, string _lastName, int _age)
        {
            FirstName = _firstName;
            LastName = _lastName;
            Age = _age;
        }
    }
}
