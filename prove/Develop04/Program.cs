using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            Console.Write("Select an activity (1-4): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                Console.Write("Enter duration (seconds): ");
                if (int.TryParse(Console.ReadLine(), out int duration))
                {
                    breathingActivity.Start(duration);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid duration.");
                }
            }
            else if (choice == "2")
            {
                ReflectionActivity reflectionActivity = new ReflectionActivity();
                Console.Write("Enter duration (seconds): ");
                if (int.TryParse(Console.ReadLine(), out int duration))
                {
                    reflectionActivity.Start(duration);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid duration.");
                }
            }
            else if (choice == "3")
            {
                ListingActivity listingActivity = new ListingActivity();
                Console.Write("Enter duration (seconds): ");
                if (int.TryParse(Console.ReadLine(), out int duration))
                {
                    listingActivity.Start(duration);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid duration.");
                }
            }
            else if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select a valid activity.");
            }
        }
    }
}
