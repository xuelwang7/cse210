using System;
using System.Threading;

class MindfulnessActivity
{
    public string Name { get; }
    public string Description { get; }

    public MindfulnessActivity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void Start(int duration)
    {
        Console.WriteLine($"Starting {Name} activity: {Description}");
        Console.WriteLine($"Duration: {duration} seconds");

        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds

        // Implement your activity logic here, e.g., breathing, reflection, listing

        Console.WriteLine($"Good job! You have completed the {Name} activity.");
        Console.WriteLine($"Duration: {duration} seconds");
        Thread.Sleep(3000); // Pause for 3 seconds
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "Helps you relax through controlled breathing.") { }

    public void Start(int duration)
    {
        base.Start(duration);

        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine(i % 2 == 0 ? "Breathe in..." : "Breathe out...");
            Thread.Sleep(2000); // Pause for 2 second
        }
    }
}

class ReflectionActivity : MindfulnessActivity
{
    public ReflectionActivity() : base("Reflection", "Reflect on a past experience of strength and resilience.") { }

    public void Start(int duration)
    {
        base.Start(duration);

        // Implement the reflection activity here
    }
}

class ListingActivity : MindfulnessActivity
{
    public ListingActivity() : base("Listing", "List positive aspects of your life or strengths.") { }

    public void Start(int duration)
    {
        base.Start(duration);

        // Implement the listing activity here
    }
}

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
