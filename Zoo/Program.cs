namespace ZooApp
{
    internal class Program
    {
        static void Main()
        {
            

            var wallaby = new Animal("Per", 4, 20, "Wallaby", "growls", false);
            var croc = new Animal("Dundee", 20, 40, "Crocodile", "hisses", true);
            var lion = new Animal("Mufasa", 15, 30, "lion", "rawrs", true);
            var elephant = new Animal("Dumbo", 35, 80, "elephant", "snorts", false);

            var sondre = new Zookeeper("Sondre", 30, new List<Animal>(){lion, elephant});
            var trym = new Zookeeper("Trym", 27, new List<Animal>(){wallaby, croc});

            var Zoo = new Zoo("Taronga", new List<Animal>(){wallaby, croc, lion, elephant}, new List<Zookeeper>(){trym, sondre});


           
            Menu(Zoo);

            
        }

        private static void BackToMenu(Zoo Zoo)
        {
            Console.WriteLine("Would you like to go back to the menu? Y/N");
            var ans = Console.ReadLine();

            switch (ans.ToLower())
            {
                case "y":
                    Console.Clear();
                    Menu(Zoo);
                    break;
                case "n":
                    Console.Clear();
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine($"{ans} is not a valid command!");
                    break;
            }
        }


        private static void Menu(Zoo Zoo)
        {
            Console.WriteLine("What would you like to do? \n" +
                              "1. Add animals \n" +
                              "2. Add Zookeepers \n" +
                              "3. Assign animal to zookeeper \n" +
                              "4. FeedAnimal \n" +
                              "5. Clean animal enclosure \n" +
                              "6. Exit program");
            int ans = Convert.ToInt32(Console.ReadLine());

            switch (ans)
            {
                case 1:
                    Console.Clear();
                    AddAnimalToZoo(Zoo);
                    BackToMenu(Zoo);
                    break;
                case 2:
                    Console.Clear();
                    AddNewKeeper(Zoo);
                    BackToMenu(Zoo);
                    break;
                case 3:
                    Console.Clear();
                    AssignAnimalToKeeper(Zoo);
                    BackToMenu(Zoo);
                    break;
                case 4:
                    Console.Clear();
                    var chosenkeeper = Zoo.SelectEmployee();
                    chosenkeeper.FeedAnimal();
                    BackToMenu(Zoo);
                    break;
                case 5:
                    Console.Clear();
                    var keeper = Zoo.SelectEmployee();
                    keeper.CleanEnclosure();
                    BackToMenu(Zoo);
                    break;
                case 6:
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine($"{ans} is a invalid command");
                    Console.ReadKey();
                    BackToMenu(Zoo);
                    break;
            }
        }

        private static void AssignAnimalToKeeper(Zoo Zoo)
        {
            var selectedanimal = Zoo.SelectAnimal();
            var selectedkeeper = Zoo.SelectEmployee();

            selectedkeeper.AddAnimal(selectedanimal);
        }

        private static void AddNewKeeper(Zoo Zoo)
        {
            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();
            Console.WriteLine("What is your age?");
            int age = Convert.ToInt32(Console.ReadLine());

            var newkeeper = new Zookeeper(name, age, new List<Animal>());
            Zoo.AddEmployee(newkeeper);
        }

        private static void AddAnimalToZoo(Zoo Zoo)
        {
            Console.WriteLine("What is the name of the animal?");
            var name = Console.ReadLine();
            Console.WriteLine("What is the age of the animal?");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How much health does it have?");
            int hp = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What species is the animal?");
            string species = Console.ReadLine();
            Console.WriteLine("What sound does the animal make?");
            string sound = Console.ReadLine();
            Console.WriteLine("Is the animal a carnivore? Y/N");
            var ans = Console.ReadLine();
            bool carnivore;
            if (ans.ToLower() == "y")
            {
                carnivore = true;
            }
            else
            {
                carnivore = false;
            }

            var newanimal = new Animal(name, age, hp, species, sound, carnivore);
            Zoo.AddAnimal(newanimal);
        }
        
    }
}