using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted = 0)
            : base(name, description, points)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = amountCompleted;
        }

        public override void RecordEvent(ref int score)
        {
            if (_amountCompleted < _target)
            {
                _amountCompleted++;
                score += _points;
                Console.WriteLine($"Congratulations! You have earned {_points}");

                if (_amountCompleted == _target)
                {
                    score += _bonus;
                    Console.WriteLine($"*** BONUS UNLOCKED! You earned an extra {_bonus} points! ***");
                }
            }
            else
            {
                Console.WriteLine("You have already completed this goal´s target");
            }
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        public override string GetDetailsString()
        {
            string check = IsComplete() ? "[X]" : "[ ]";
            return $"{check} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
        }
    }
}