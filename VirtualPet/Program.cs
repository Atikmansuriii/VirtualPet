using System;

namespace VirtualPet
{
    public class Pet
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Hunger { get; set; }
        public int Happiness { get; set; }
        public int Health { get; set; }

        // Constructor to initialize the pet with default stats
        public Pet(string name, string type)
        {
            Name = name;
            Type = type;
            Hunger = 5;  // Initial hunger level
            Happiness = 5;  // Initial happiness level
            Health = 5;  // Initial health level
        }

        // Method to feed the pet
        public void Feed()
        {
            Hunger = Math.Max(Hunger - 2, 0);  // Decrease hunger, not below 0
            Health = Math.Min(Health + 1, 10);  // Slightly increase health, not above 10
            Console.WriteLine($"{Name} has been fed. Hunger is now {Hunger}. Health is now {Health}.");
        }

        // Method to play with the pet
        public void Play()
        {
            Happiness = Math.Min(Happiness + 2, 10);  // Increase happiness, not above 10
            Hunger = Math.Min(Hunger + 1, 10);  // Slightly increase hunger, not above 10
            Console.WriteLine($"{Name} played. Happiness is now {Happiness}. Hunger is now {Hunger}.");
        }

        // Method to let the pet rest
        public void Rest()
        {
            Health = Math.Min(Health + 2, 10);  // Increase health, not above 10
            Happiness = Math.Max(Happiness - 1, 0);  // Slightly decrease happiness, not below 0
            Console.WriteLine($"{Name} rested. Health is now {Health}. Happiness is now {Happiness}.");
        }

        // Method to display the pet's current stats
        public void DisplayStats()
        {
            Console.WriteLine($"{Name}'s Stats - Hunger: {Hunger}, Happiness: {Happiness}, Health: {Health}");
        }

        // Method to check and display any critical statuses
        public void StatusCheck()
        {
            if (Hunger >= 8)
                Console.WriteLine($"{Name} is very hungry!");
            if (Happiness <= 2)
                Console.WriteLine($"{Name} is very unhappy!");
            if (Health <= 2)
                Console.WriteLine($"{Name} is very unhealthy!");

            // Implementing consequences for neglect
            if (Hunger >= 10)
                Health = Math.Max(Health - 2, 0);
            if (Happiness == 0)
                Health = Math.Max(Health - 1, 0);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Welcome message and pet creation
            Console.WriteLine("Welcome to the Virtual Pet game!");

            string[] petTypes = { "Cat", "Dog", "Rabbit" };
            string type = ChoosePetType(petTypes);

            Console.WriteLine("Give your pet a name: ");
            string name = Console.ReadLine();

            // Initialize the pet
            Pet pet = new Pet(name, type);
            Console.WriteLine($"Welcome, {pet.Name} the {pet.Type}!");

            // Main game loop
            while (true)
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Feed");
                Console.WriteLine("2. Play");
                Console.WriteLine("3. Rest");
                Console.WriteLine("4. Check Status");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                // Handle user choice
                switch (choice)
                {
                    case "1":
                        pet.Feed();
                        break;
                    case "2":
                        pet.Play();
                        break;
                    case "3":
                        pet.Rest();
                        break;
                    case "4":
                        pet.DisplayStats();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye! Thanks for playing.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                // Check pet's status and simulate time passing
                pet.StatusCheck();
                SimulateTimePassing(pet);
            }
        }

        // Method to choose pet type
        static string ChoosePetType(string[] petTypes)
        {
            Console.WriteLine("Choose your pet type:");
            for (int i = 0; i < petTypes.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {petTypes[i]}");
            }

            while (true)
            {
                string choice = Console.ReadLine();
                if (int.TryParse(choice, out int index) && index > 0 && index <= petTypes.Length)
                {
                    return petTypes[index - 1];
                }
                else
                {
                    Console.WriteLine("Invalid choice, please select a valid pet type.");
                }
            }
        }

        // Method to simulate the passage of time
        static void SimulateTimePassing(Pet pet)
        {
            pet.Hunger = Math.Min(pet.Hunger + 1, 10);  // Increase hunger over time, not above 10
            pet.Happiness = Math.Max(pet.Happiness - 1, 0);  // Decrease happiness over time, not below 0
            Console.WriteLine($"{pet.Name}'s hunger increased and happiness decreased with time passing.");
        }
    }
}
