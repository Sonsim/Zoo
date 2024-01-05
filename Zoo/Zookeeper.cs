using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp
{
    internal class Zookeeper : LivingBeing
    {
        internal List<Animal> animals;
        public Zookeeper(string name, int age, List<Animal> animals) : base(name, age)
        {
            this.animals = animals;
        }

        public Animal SelectAnimal()
        {
            Console.WriteLine("Which animal do you want to choose?");
            foreach (var animal in animals)
            {
                Console.WriteLine($"- {animal.Name}");
            }
            var choice = Console.ReadLine().ToLower();

            foreach (var animal in animals)
            {
                if (choice == animal.Name.ToLower())
                {
                    return animal;
                }
               
            }

            return null;
        }

        public void FeedAnimal()
        {
            Animal chosenanimal = SelectAnimal();
            Console.WriteLine("What do you want to feed the animal? \n" +
                              "- Meat \n" +
                              "- Grass \n" +
                              "- Water \n" +
                              "- Candy \n");
            var choice = Console.ReadLine().ToLower();

            if (choice == "grass" && chosenanimal.IsCarnivore() == true)
            {
                chosenanimal.healthstatus = chosenanimal.healthstatus - 5;
                Console.WriteLine($"{chosenanimal.Name} is eating the wrong food! \n" +
                                  $"They have {chosenanimal.GetHealthStatus()} health left.");
                chosenanimal.CheckHealth();
            }

            if (choice == "meat" && chosenanimal.IsCarnivore() == false)
            {
                chosenanimal.healthstatus = chosenanimal.healthstatus - 5;
                Console.WriteLine($"{chosenanimal.Name} is eating the wrong food! \n" +
                                  $"They have {chosenanimal.GetHealthStatus()} health left.");
                chosenanimal.CheckHealth();
            }
            else
            {
                Console.WriteLine($"{chosenanimal.Name} is eating {choice} happily");
                chosenanimal.MakeSound();
                chosenanimal.CheckHealth();
            }
        }

        public void CleanEnclosure()
        {
            Animal chosenanimal = SelectAnimal();
            Console.WriteLine($"{Name} is cleaning the enclosure of {chosenanimal.Name}");
        }

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
            Console.WriteLine($"{animal.Name} is added to {Name} responsibility");
        }

        public void RemoveAnimal(Animal animal)
        {
            animals.Remove(animal);
            Console.WriteLine($"{animal.Name} is no longer the responsibility of {Name}");
        }
    }
}
