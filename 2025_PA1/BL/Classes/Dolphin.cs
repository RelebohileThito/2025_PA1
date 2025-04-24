using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_PA1.BL.Classes
{
    public class Dolphin:Animal,IIcanPerformTricks
    {
        public delegate string JumpedEventDelegate(string name, double jumpHeight);
        public event JumpedEventDelegate Jumped;

        public Trainer Trainer { get; set; }
        public double SwimSpeed { get; set; }

        public Dolphin() { }

        public Dolphin(string id, string name, int age) : base(id, name, age) { }

        public override string Eat()
        {
            return $"The dolphin, {Name}, eats fish and squid.";
        }

        public string Jump(double height)
        {
            if (Jumped != null)
            {
                Jumped(Name, height);
            }
            return $"{Name} jumps {height} meters out of the water!";
        }

        public override string MakeSound()
        {
            return "Click-click-whistle!";
        }

        public string PerformTricks()
        {
            return $"The dolphin, {Name}, jumps through a hoop.";
        }

        public string ShowTrainer()
        {
            return $"{Name} is trained by {Trainer.Name}, who has {Trainer.ExperienceYears} years of experience.";
        }

        
    }
}
