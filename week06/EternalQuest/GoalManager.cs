using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void Start()
        {
            string choice = "";
            while (choice != "6")
            {
                DisplayPlayerInfo();
                Console.WriteLine("\nMenu Options");
                Console.WriteLine(" 1. Create New Goal");
                Console.WriteLine(" 2. List Goals");
                Console.WriteLine(" 3. Save Goals");
                Console.WriteLine(" 4 . Load Goals");
                Console.WriteLine(" 5. Record Event");
                Console.WriteLine(" 6. Quit");
                Console.Write("Select a choice from the menu: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": CreateGoal(); break;
                    case "2": ListGoalDetails(); break;
                    case "3": SaveGoals(); break;
                    case "4": LoadGoals(); break;
                    case "5": RecordEvent(); break;
                    case "6": break;
                    default: Console.WriteLine("Invalid option"); break;
                }
            }
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine();
            Console.WriteLine($"You have {_score} points");

            int level = (_score / 500) + 1;
            string rank = "Beginner";
            if (level == 2) rank = "Novice";
            else if (level == 3) rank = "Apprentice";
            else if (level == 4) rank = "Journeyman";
            else if (level == 5) rank = "Expert";
            else if (level >= 6) rank = "Master";

            Console.WriteLine($"Current Level: {level} - Title [ {rank}]");
        }

        public void ListGoalNames()
        {
            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
            }
        }

        public void ListGoalDetails()
        {
            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString}");
            }
        }

        public void CreateGoal()
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine(" 1. Simple Goal");
            Console.WriteLine(" 2. Eternal Goal");
            Console.WriteLine(" 3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string type = Console.ReadLine();

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            if (type == "1")
            {
                _goals.Add(new SimpleGoal(name, description, points));
            }
            else if (type == "2")
            {
                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (type == "3")
            {
                Console.Write("How many time does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
            }
        }

        public void RecordEvent()
        {
            ListGoalNames();
            Console.Write("Which goal did you accomplish? ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
            {
                _goals[index - 1].RecordEvent(ref _score);
            }
            else
            {
                Console.WriteLine("Invalid goal selection.");
            }
        }

        public void SaveGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string fileName = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
        }

        public void LoadGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string fileName = Console.ReadLine();

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                _score = int.Parse(lines[0]);
                _goals.Clear();

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(':');
                    string type = parts[0];
                    string[] details = parts[1].Split(',');

                    string name = details[0];
                    string desc = details[1];
                    int points = int.Parse(details[2]);

                    if (type == "SimpleGoal")
                    {
                        bool isComplete = bool.Parse(details[3]);
                        _goals.Add(new SimpleGoal(name, desc, points, isComplete));
                    }
                    else if (type == "ChecklistGoal")
                    {
                        _goals.Add(new EternalGoal(name, desc, points));
                    }
                    else if (type == "ChecklistGoal")
                    {
                        int bonus = int.Parse(details[3]);
                        int target = int.Parse(details[4]);
                        int amount = int.Parse(details[5]);
                        _goals.Add(new ChecklistGoal(name, desc, points, target, bonus, amount));
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }
    }
}