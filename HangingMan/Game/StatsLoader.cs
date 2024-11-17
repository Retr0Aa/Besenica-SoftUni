using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangingMan.Game
{
    public class StatsLoader
    {
        public static Stats LoadStats()
        {
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, "stats.txt")))
            {
                int wins = int.Parse(File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "stats.txt"))[0]);
                int loses = int.Parse(File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "stats.txt"))[1]);
                bool useColors = int.Parse(File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "stats.txt"))[2]) == 1 ? true : false;
                return new Stats(wins, loses, useColors);
            }
            else
            {
                File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "stats.txt"), "0\n0\n0");
                return new Stats(0, 0, true);
            }
        }

        public static void AddWin()
        {
            Stats stats = LoadStats();
            stats.wins++;

            File.WriteAllText(
                Path.Combine(Environment.CurrentDirectory, "stats.txt"),
                $"{stats.wins}\n{stats.loses}\n{(stats.useColors ? 1 : 0)}"
            );
        }

        public static void AddLose()
        {
            Stats stats = LoadStats();
            stats.loses++;

            File.WriteAllText(
                Path.Combine(Environment.CurrentDirectory, "stats.txt"),
                $"{stats.wins}\n{stats.loses}\n{(stats.useColors ? 1 : 0)}"
            );
        }

        public static void ToggleColors(bool useColors)
        {
            Stats stats = LoadStats();
            stats.useColors = useColors;

            File.WriteAllText(
                Path.Combine(Environment.CurrentDirectory, "stats.txt"),
                $"{stats.wins}\n{stats.loses}\n{(stats.useColors ? 1 : 0)}"
            );
        }
    }

    public class Stats
    {
        public int wins;
        public int loses;
        public bool useColors;

        public Stats(int wins, int loses, bool useColors)
        {
            this.wins = wins;
            this.loses = loses;
            this.useColors = useColors;
        }
    }
}
