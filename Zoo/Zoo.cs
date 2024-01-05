using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp
{
    internal class Zoo
    {
        private string _name;
        private List<Animal> _allAnimals;
        private List<Zookeeper> _employees;

        public Zoo(string name, List<Animal> allAnimals, List<Zookeeper> employees)
        {
            _name = name;
            _allAnimals = allAnimals;
            _employees = employees;
        }

        public void AddAnimal(Animal animal)
        {
            _allAnimals.Add(animal);
            Console.WriteLine($"{animal.Name} has joined the zoo");
        }

        public void AddEmployee(Zookeeper employee)
        {
            _employees.Add(employee);
            Console.WriteLine($"{employee.Name} has started working here!");
        }

        public void RemoveAnimal(Animal animal)
        {
            _allAnimals.Remove(animal);
            Console.WriteLine($"{animal.Name} has left the zoo");
        }

        public Zookeeper SelectEmployee()
        {
            Console.WriteLine("Which zookeeper do you want to select?");
            foreach (var keeper in _employees)
            {
                Console.WriteLine($"- {keeper.Name}");
            }
            var choice = Console.ReadLine();
            foreach (var zookeeper in _employees)
            {
                if (zookeeper.Name.ToLower() == choice.ToLower())
                {
                    return zookeeper;
                }
            }

            return null;
        }

        public Animal SelectAnimal()
        {
            Console.WriteLine("Which animal do you want to select?");
            foreach (var animal in _allAnimals)
            {
                Console.WriteLine($"- {animal.Name}");
            }
            var choice = Console.ReadLine();
            foreach (var animal in _allAnimals)
            {
                if (choice.ToLower() == animal.Name.ToLower())
                {
                    return animal;
                }
                
            }

            return null;
        }

        public void AssignAnimalToKeeper()
        {
            var animal = SelectAnimal();
            var keeper = SelectEmployee();

            keeper.AddAnimal(animal);
            Console.WriteLine($"{animal.Name} is now assigned to {keeper.Name}");

        }
    }
}
