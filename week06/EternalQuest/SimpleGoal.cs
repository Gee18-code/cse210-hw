using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
        {
            _isComplete = isComplete;
        }

        public override void RecordEvent(ref int score)
        {
            if (!_isComplete)
            {
                _isComplete = true;
                score += _points;
                Console.WriteLine($"Congratulations! you have earned {_points} points!");
            }
            else
            {
                Console.WriteLine("You have already completed this goal");
            }
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
        }
    }
}