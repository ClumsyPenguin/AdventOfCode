using System.Text;
using System.Text.RegularExpressions;
using AOC2023.Common;

namespace AOC2023.Day1;

public class Solution
{
    public static void Run()
    {
        var totalSum = 0;
        var lines = new List<string>();

        using (var reader = new StreamReader(ReadFileToMemoryStream("day1/input.txt"), Encoding.UTF8))
        {
            while (reader.ReadLine() is { } line)
            {
                lines.Add(line);
            }
        }

        foreach (var line in lines)
        {
            var digits = new string(line.Where(char.IsDigit).ToArray());
        
            if (!string.IsNullOrEmpty(digits))
            {
                var firstDigit = int.Parse(digits[0].ToString());
                var lastDigit = digits.Length > 1 ? int.Parse(digits[^1].ToString()) : firstDigit;
                totalSum += int.Parse($"{firstDigit}{lastDigit}");
            }
        }

        Console.WriteLine($"Total Sum: {totalSum}");
    }
}