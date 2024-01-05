using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp
{
    internal class Animal : LivingBeing
    {
        private string _species;
        internal int healthstatus;
        private string _sound;
        private bool _carnivore;

        public Animal(string name, int age, int hpstatus, string species, string sound, bool carnivore) : base(name, age)
        {
            healthstatus = hpstatus;
            _species = species;
            _sound = sound;
            _carnivore = carnivore;
        }

        public void MakeSound()
        {
            Console.WriteLine($"{_sound}");
        }

        public void CheckHealth()
        {
            if (healthstatus <= 0)
            {
                Console.WriteLine($"{Name} has died");

            }

            if (healthstatus > 0 && healthstatus <= 5)
            {
                Console.WriteLine($"{Name} needs the right food");
            }
            else
            {
                Console.WriteLine($"{Name} is healthy");
            }
        }
        
        public int GetHealthStatus()
        {
            return healthstatus;
        }

        public bool IsCarnivore()
        {
            return _carnivore;
        }
    }
}
