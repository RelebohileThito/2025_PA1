using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using Microsoft.Data.Sqlite;

namespace _2025_PA1.BL.Classes

{
    public abstract class Animal
    {
        private int age;

        public Animal() { }

        public Animal(string id, string name, int age)
        {
            ID = id;
            Age = age;
            Name = name;
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        [Key] public string ID { get; set; }
        public string Name { get; set; }

        public abstract string Eat();

        public virtual string MakeSound()
        {
            return "Some generic sound";
        }

        public override string ToString()
        {
            return $"{Name} ({ID}) is {Age} years old.";
        }
    }
}
