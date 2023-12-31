﻿namespace MVVMCustomSort.Models
{
    class Person
    {
        private string? name;
        private int? age;

        public string? Name { get => name; set => name = value; }
        public int? Age { get => age; set => age = value; }

        public Person() { }

        public Person(string? name, int? age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
