using System;
using System.Collections.Generic;
 
//-------------------------------------------------------------------------------------
// CREATIVITY AND EXCEEDING REQUIREMENTS REPORT:
// 1. I improved the robustness of the program by adding data sanitization if the user
//    types the delimiter symbol '|' in their text, the program automatically filters
//    it out before saving to prevent corrupting the file load structure.
// 2. Implemented active validation checking if flies exist before trying to Load them
//    preventing runtime crashes.
//-------------------------------------------------------------------------------------
 
 
 
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
 
        List<string> prompts = new List<string>
        {
            "What was the best part of your day?",
            "What are you grateful for today?",
            "Describe a challenge you faced and how you overcame it.",
            "What is something new you learned today?",
            "Write about a memorable moment from your day."
        };
 
        Random randomGenerator = new Random();
        int choice = -1;
 
        Console.WriteLine("Welcome to the journal Program!");
 
        while (choice != 5)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? ");
 
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 1)
                {
                    int randomIndex = randomGenerator.Next(prompts.Count);
                    string randomprompt = prompts[randomIndex];
 
                    Console.WriteLine($"\nPrompt: {randomprompt}");
                    Console.Write("> ");
                    string userResponse = Console.ReadLine();
 
                    Entry newEntry = new Entry();
                    newEntry._date = DateTime.Now.ToString("yyyy-MM-dd");
                    newEntry._promptText = randomprompt;
                    newEntry._entryText = userResponse;
 
                    journal.AddEntry(newEntry);
 
                }
                else if (choice == 2)
                {
                    Console.WriteLine("\n---  Journal Entries ---");
                    journal.DisplayAll();
                }
                else if (choice == 3)
                {
                    Console.Write("What is the filename? ");
                    string filename = Console.ReadLine();
                    journal.LoadFromFile(filename);
                }
                else if (choice == 4)
                {
                    Console.Write("What is the filename? ");
                    string filename = Console.ReadLine();
                    journal.SaveToFile(filename);
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Thank you for using the journal Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid option. Please choose a number from 1 to 5.");
                }
            }
            else            {
                Console.WriteLine("Please enter a valid numeric option.");
            }
        }
    }
}