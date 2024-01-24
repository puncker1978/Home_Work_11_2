using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCustomSort3.Models
{
    internal class Person : INotifyPropertyChanged
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
