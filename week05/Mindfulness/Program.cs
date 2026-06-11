using System;

class Program
{
    private static int _breathingCount = 0;
    private static int _reflectionCount = 0;
    private static int _listingCount = 0;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("===================");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine();
            Console.Write("Select an option from the menu: ");

            string choice = Console.ReadLine() ?? string.Empty;

            if (choice == "1")
            {
                new BreathingActivity().Run();
                _breathingCount++;
                PauseBeforeReturningToMenu();
            }
            else if (choice == "2")
            {
                new ReflectingActivity().Run();
                _reflectionCount++;
                PauseBeforeReturningToMenu();
            }
            else if (choice == "3")
            {
                new ListingActivity().Run();
                _listingCount++;
                PauseBeforeReturningToMenu();
            }
            else if (choice == "4")
            {
                Console.WriteLine();
                Console.WriteLine("Thank you for using the Mindfulness Program.");
                Console.WriteLine($"Session summary: {_breathingCount} breathing, {_reflectionCount} reflection, {_listingCount} listing.");
                break;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("That is not a valid choice. Press Enter to try again.");
                Console.ReadLine();
            }
        }
    }

    private static void PauseBeforeReturningToMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the menu.");
        Console.ReadLine();
    }
}