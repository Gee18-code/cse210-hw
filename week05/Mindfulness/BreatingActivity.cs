using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        Start();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            int remaining = GetRemainingSeconds(endTime);
            if (remaining <= 0)
            {
                break;
            }

            Console.WriteLine();
            Console.Write("Breathe in... ");
            int inhale = Math.Min(4, remaining);
            ShowCountDown(inhale);

            remaining = GetRemainingSeconds(endTime);
            if (remaining <= 0)
            {
                break;
            }

            Console.WriteLine();
            Console.Write("Breathe out... ");
            int exhale = Math.Min(6, remaining);
            ShowCountDown(exhale);
        }

        DisplayEndMessage();
    }
}
