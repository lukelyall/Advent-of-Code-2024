using System;
using System.Collections.Generic;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main()
        {
            List<List<int>> levels = new List<List<int>>();

            var lines = File.ReadLines("./input.txt");
            foreach (var line in lines)
            {
                var numbers = new List<int>();
                foreach (var part in line.Split(' '))
                {
                    if (int.TryParse(part, out int num))
                    {
                        numbers.Add(num);
                    }
                }
                levels.Add(numbers);
            }

            // PART ONE
            int safeReports = 0;
            for (int i = 0; i < levels.Count; i++)
            {
                List<int> level = levels[i];
                bool safe = CheckIfSafe(level);
                if (safe)
                {
                    safeReports++;
                }
            }
            Console.WriteLine(safeReports);

            // PART TWO
            int safeReportsPartTwo = 0;
            for (int i = 0; i < levels.Count; i++)
            {
                List<int> level = levels[i];

                if (CheckIfSafe(level))
                {
                    safeReportsPartTwo++;
                    continue;
                }

                bool canBeSafe = false;
                for (int j = 0; j < level.Count; j++)
                {
                    List<int> modifiedLevel = new List<int>(level);
                    modifiedLevel.RemoveAt(j);

                    if (CheckIfSafe(modifiedLevel))
                    {
                        canBeSafe = true;
                        break;
                    }
                }

                if (canBeSafe)
                {
                    safeReportsPartTwo++;
                }
            }
            Console.WriteLine(safeReportsPartTwo);
        }

        static bool CheckIfSafe(List<int> level)
        {
            bool safe = true;
            bool? ascending = null;
            for (int j = 0; j < level.Count - 1; j++)
            {
                int difference = level[j + 1] - level[j];

                if (difference == 0)
                    return false;

                if (ascending == null)
                {
                    if (difference > 0)
                        ascending = true;
                    else
                        ascending = false;
                }
                else
                {
                    if ((ascending == true && difference <= 0) || (ascending == false && difference >= 0))
                        return false;
                }

                if (Math.Abs(difference) < 1 || Math.Abs(difference) > 3)
                    return false;
            }
            return safe;
        }
    }
}