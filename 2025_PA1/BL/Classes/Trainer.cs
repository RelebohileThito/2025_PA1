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
    public class Trainer
    {
        public int ExperienceYears { get; set; }
        public string Name { get; set; }

        public Trainer() { }

        public Trainer(string name, int experienceYears)
        {
            Name = name;
            ExperienceYears = experienceYears;
        }

        public string OnDolphinJump(string name, double jumpHeight)
        {
            return $"{Name}, the trainer, says: Wow! {name} jumped {jumpHeight} meters high!";
        }

        public override string ToString()
        {
            return $"Trainer {Name} has {ExperienceYears} years of experience";
        }

        public string TrainAnimal()
        {
            return $"{Name} (with {ExperienceYears} years of experience) is training the animal.";
        }
    }
}
