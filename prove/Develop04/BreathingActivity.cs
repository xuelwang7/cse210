using System;
using System.Threading;

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "Helps you relax through controlled breathing.") { }

    public void Start(int duration)
    {
        base.Start(duration);

        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine(i % 2 == 0 ? "Breathe in..." : "Breathe out...");
            Thread.Sleep(1000); // Pause for 1 second
        }
    }
}
