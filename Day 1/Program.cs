using System;
using System.Collections.Generic;
using System.IO;

namespace Day1;

class Program
{
    static void Main()
    {
        string text = File.ReadAllText("./input.txt");

        List<int> left = new List<int>();
        List<int> right = new List<int>();

        int startIndex = -1;

        for(int i = 0; i < text.Length; i++)
        {
            if(char.IsDigit(text[i]))
            {
                if (startIndex == -1)
                {
                    startIndex = i;
                }
            }
            else
            {
                if (startIndex != -1)
                {
                    if(left.Count <= right.Count)
                    {
                        left.Add(int.Parse(text.Substring(startIndex, (i - startIndex))));
                    }
                    else
                    {
                        right.Add(int.Parse(text.Substring(startIndex, (i - startIndex))));
                    }
                    startIndex = -1;
                }
            }
        }

        if (startIndex != -1)
        {
            if (left.Count <= right.Count)
            {
                left.Add(int.Parse(text.Substring(startIndex)));
            }
            else
            {
                right.Add(int.Parse(text.Substring(startIndex)));
            }
        }

        left.Sort();
        right.Sort();

        // PART ONE
        int totalDistance = 0;

        for(int i = 0; i < left.Count; i++)
        {
            totalDistance += Math.Abs(left[i] - right[i]);
        }

        Console.WriteLine(totalDistance);

        // PART TWO
        int similarityScore = 0;
        foreach(int leftNums in left)
        {
            int tempScore = 0;
            foreach(int rightNums in right)
            {
                if (leftNums < rightNums)
                {
                    break;
                }
                if(leftNums == rightNums)
                {
                    tempScore++;
                }
            }
            similarityScore += (leftNums * tempScore);
        }
        Console.WriteLine(similarityScore);
    }
}