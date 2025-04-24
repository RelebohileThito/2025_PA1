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
    public class Parrot:Animal,IIcanPerformTricks,ICloneable
    {
        private string featherColor;
        private string[] validColors = new[]
        {
        "Bright Yellow", "Black & White", "Green",
        "Blue", "Yellow", "Red", "Orange"
    };

        public string FeatherColor
        {
            get { return featherColor; }
            set
            {
                if (!validColors.Contains(value))
                {
                    string validColor = "";
                    int index = 0;
                    while (index < validColors.Length - 1)
                    {
                        validColor += validColors[index] + ", ";
                        index++;
                    }
                    validColor += validColors[validColors.Length - 1];
                    throw new InvalidFeatherColorException($"'{value}' is not a valid feather color. " +
                                                           $"Allowed colors: {validColor}");
                }

                featherColor = value;
            }
        }

        public Trainer Trainer { get; }

        public Parrot()
        {
            Trainer = new Trainer();
        }

        public Parrot(string id, string name, int age) : base(id, name, age)
        {
            Trainer = new Trainer();
        }

        public object Clone()
        {
            Parrot cloneParrot = new Parrot
            {
                Age = Age,
                FeatherColor = FeatherColor,
                Name = Name
            };
            cloneParrot.Trainer.Name = Trainer.Name;
            cloneParrot.Trainer.ExperienceYears = Trainer.ExperienceYears;

            return cloneParrot;
        }

        public override string Eat()
        {
            return "The parrot eats seeds and fruits.";
        }

        public override string MakeSound()
        {
            return "Squawk! Hello!";
        }

        public string MimicSound(string sound)
        {
            return $"The parrot mimics: {sound}";
        }

        public string PerformTricks()
        {
            return $"{Name} does a somersault in the air!";
        }


    }
}
