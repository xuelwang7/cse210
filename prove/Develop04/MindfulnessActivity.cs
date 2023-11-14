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
