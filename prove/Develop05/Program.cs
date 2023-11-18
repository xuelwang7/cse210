using System;
using System.Collections.Generic;

public interface IGoal
{
    string Name { get; }
    int Value { get; }
    bool IsCompleted { get; }
    string Progress { get; }
    void RecordEvent();
}

public class SimpleGoal : IGoal
{
    public string Name { get; }
    public int Value { get; }
    public bool IsCompleted { get; private set; }

    public SimpleGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public void RecordEvent()
    {
        IsCompleted = true;
    }

    public string Progress => IsCompleted ? "[X]" : "[ ]";
}

public class EternalGoal : IGoal
{
    public string Name { get; }
    public int Value { get; }
    public bool IsCompleted => false;

    public EternalGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public void RecordEvent()
    {
        // Record progress for eternal goals
    }

    public string Progress => "[ ]";
}

public class ChecklistGoal : IGoal
{
    public string Name { get; }
    public int Value { get; }
    public int TargetCount { get; }
    private int completedCount;

    public ChecklistGoal(string name, int value, int targetCount)
    {
        Name = name;
        Value = value;
        TargetCount = targetCount;
        completedCount = 0;
    }

    public void RecordEvent()
    {
        completedCount++;
    }

    public bool IsCompleted => completedCount >= TargetCount;

    public string Progress => $"Completed {completedCount}/{TargetCount} times";
}

public class EternalQuestProgram
{
    private List<IGoal> goals;
    private int userScore;

    public EternalQuestProgram()
    {
        goals = new List<IGoal>();
        userScore = 0;
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Current Score: {userScore} points");
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.Name} - {goal.Progress}");
        }
    }

    public void CreateGoal()
    {
        Console.Write("Enter goal name: ");
        string goalName = Console.ReadLine();

        Console.Write("Enter goal value: ");
        if (int.TryParse(Console.ReadLine(), out int goalValue))
        {
            Console.WriteLine("Choose goal type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");

            Console.Write("Enter your choice (1-3): ");
            string choice = Console.ReadLine();

            IGoal goal = null;
            switch (choice)
            {
                case "1":
                    goal = new SimpleGoal(goalName, goalValue);
                    break;
                case "2":
                    goal = new EternalGoal(goalName, goalValue);
                    break;
                case "3":
                    Console.Write("Enter target count for the checklist goal: ");
                    if (int.TryParse(Console.ReadLine(), out int targetCount))
                    {
                        goal = new ChecklistGoal(goalName, goalValue, targetCount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Target count must be a valid integer.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice. Goal not created.");
                    break;
            }

            if (goal != null)
            {
                goals.Add(goal);
                Console.WriteLine($"Goal '{goalName}' created successfully!");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Goal value must be a valid integer.");
        }
    }

    public void RecordGoalEvent()
    {
        Console.WriteLine("Choose a goal to record an event for:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        Console.Write("Enter your choice (1-{goals.Count}): ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= goals.Count)
        {
            IGoal selectedGoal = goals[choice - 1];
            selectedGoal.RecordEvent();
            userScore += selectedGoal.Value;

            Console.WriteLine($"Event recorded for goal '{selectedGoal.Name}'!");
        }
        else
        {
            Console.WriteLine("Invalid choice. No event recorded.");
        }
    }

    // You can add more methods for gamification, saving/loading, and other features here
}

class Program
{
    static void Main()
    {
        EternalQuestProgram eternalQuest = new EternalQuestProgram();

        while (true)
        {
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("1. Display Goals");
            Console.WriteLine("2. Create Goal");
            Console.WriteLine("3. Record Goal Event");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Exit");

            Console.Write("Select an option (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    eternalQuest.DisplayGoals();
                    break;
                case "2":
                    eternalQuest.CreateGoal();
                    break;
                case "3":
                    eternalQuest.RecordGoalEvent();
                    break;
                case "4":
                    eternalQuest.DisplayScore();
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}
