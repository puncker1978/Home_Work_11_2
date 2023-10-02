﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_2.Models
{
    public abstract class Person
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        protected Person(string firstName, string secondName, string thirdName)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
        }
    }
}
