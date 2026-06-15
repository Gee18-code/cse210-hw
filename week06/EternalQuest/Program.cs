using System;

namespace EternalQuest
{
    class Program
    {
        // =========================================================================================
        // EXCEEDING REQUIREMENTS (CREATIVITY)
        // =========================================================================================
        // To exceed the core requirements, I added a "Leveling and Rank System" to the program.
        // As the user earns points, the DisplayPlayerInfo() method calculates a Level based on
        // the score (every 500 points equals a new level).
        // Depending on their level, they are granted a special Rank/Title (e.g., Beginner.
        // Novice, Apprentice, Expert, Master) which is displayed dynamically in the main menu.
        // Additionally, I included bonus unlocked notifications for Checklist goals.
        // =========================================================================================
        static void Main(string[] args)
        {
            GoalManager manager = new GoalManager();
            manager.Start();
        }
    }
}