using System.Globalization;

namespace DayFour;

class Program
{
  static void Main(string[] args)
  {
    string[] input = File.ReadAllLines("input.txt");
    char[,] grid = new char[input.Length, input[0].Length];

    for (int i = 0; i < input.Length; i++)
    {
      for (int j = 0; j < input[i].Length; j++)
      {
        grid[i, j] = input[i][j];
      }
    }

    // PART ONE
    Console.WriteLine(partOne(grid, "XMAS"));

    // PART TWO
    Console.WriteLine(partTwo(grid));
  }

  static int partOne(char[,] grid, string word)
  {
    int count = 0;

    int[] dRow = { -1, -1, -1, 0, 1, 1, 1, 0 };
    int[] dCol = { -1, 0, 1, 1, 1, 0, -1, -1 };

    for (int i = 0; i < grid.GetLength(0); i++)
    {
      for (int j = 0; j < grid.GetLength(1); j++)
      {
        for (int k = 0; k < 8; k++)
        {
          int row = i;
          int col = j;
          int l;

          for (l = 0; l < word.Length; l++)
          {
            if (row < 0 || row >= grid.GetLength(0) || col < 0 || col >= grid.GetLength(1) || grid[row, col] != word[l])
              break;

            row += dRow[k];
            col += dCol[k];
          }
          if (l == word.Length)
            count++;
        }
      }
    }

    return count;
  }

  static int partTwo(char[,] grid)
  {
    int count = 0;

    for (int i = 1; i < grid.GetLength(0) - 1; i++)
    {
      for (int j = 1; j < grid.GetLength(1) - 1; j++)
      {
        if (grid[i, j] == 'A')
        {
          bool diagonal1 =
            (grid[i - 1, j - 1] == 'M' && grid[i + 1, j + 1] == 'S') ||
            (grid[i - 1, j - 1] == 'S' && grid[i + 1, j + 1] == 'M'); 

          bool diagonal2 =
            (grid[i - 1, j + 1] == 'M' && grid[i + 1, j - 1] == 'S') ||
            (grid[i - 1, j + 1] == 'S' && grid[i + 1, j - 1] == 'M');

          if (diagonal1 && diagonal2)
          {
            count++;
          }
        }
      }
    }
    return count;
  }
}