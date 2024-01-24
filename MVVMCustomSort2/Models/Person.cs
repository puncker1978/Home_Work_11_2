﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMCustomSort2.Models
{
    class Person : INotifyPropertyChanged
    {
        private string name;
        private int? age;

        public string Name
        {
            get => name;
            set
            {
                if (name == value) return;
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public int? Age
        {
            get => age;
            set
            {
                if (age == value) return;
                age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public Person() { }

        public Person(string name, int? age)
        {
            this.Name = name;
            this.Age = age;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
