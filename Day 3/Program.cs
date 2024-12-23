using System;
using System.Text.RegularExpressions;

namespace Day3;

class Program
{
    static void Main()
    {
        string input = File.ReadAllText("./input.txt");
        string pattern = @"mul\((\d+),\s*(\d+)\)";

        int total = 0;

        // PART ONE
        foreach(Match match in Regex.Matches(input, pattern))
        {
            int num1 = int.Parse(match.Groups[1].Value);
            int num2 = int.Parse(match.Groups[2].Value);

            total += num1 * num2;
        }

        Console.WriteLine($"total: {total}");

        // PART TWO
        string doPattern = @"do\(\)";
        string dontPattern = @"don't\(\)";

        bool mul = true;
        int partTwoTotal = 0;

        foreach (var command in Regex.Split(input, @"(mul\(\d+,\s*\d+\)|do\(\)|don't\(\))"))
        {
            if (Regex.IsMatch(command, pattern))
            {
                if (mul)
                {
                    var mulMatch = Regex.Match(command, pattern);
                    int num1 = int.Parse(mulMatch.Groups[1].Value);
                    int num2 = int.Parse(mulMatch.Groups[2].Value);
                    partTwoTotal += num1 * num2;
                }
            }
            else if (Regex.IsMatch(command, doPattern))
                mul = true;
            else if (Regex.IsMatch(command, dontPattern))
                mul = false;
        }
        Console.WriteLine($"total: {partTwoTotal}");
    }
}