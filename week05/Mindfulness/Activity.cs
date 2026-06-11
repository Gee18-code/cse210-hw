using System;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");

        while (true)
        {
            string input = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(input.Trim(), out int seconds) && seconds > 0)
            {
                _duration = seconds;
                break;
            }

            Console.Write("Please enter a whole number greater than zero: ");
        }

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    protected void DisplayEndMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[index]);
            Thread.Sleep(300);
            Console.Write("\b \b");
            index = (index + 1) % spinner.Length;
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string text = i.ToString();
            Console.Write(text);
            Thread.Sleep(1000);
            Console.Write(new string('\b', text.Length));
            Console.Write(new string(' ', text.Length));
            Console.Write(new string('\b', text.Length));
        }
    }

    protected int GetRemainingSeconds(DateTime endTime)
    {
        int remaining = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
        return Math.Max(0, remaining);
    }

    public abstract void Run();
}
