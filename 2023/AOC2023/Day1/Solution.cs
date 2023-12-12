using System.Text;
using System.Text.RegularExpressions;
using AOC2023.Common;

namespace AOC2023.Day1;

public class Solution
{
    public static void Run()
    {
        var totalSum = 0;

        using (var reader = new StreamReader("day1/input.txt", Encoding.UTF8))
        {
            while (reader.ReadLine() is { } line)
            {
                var digits = new string(line.Where(char.IsDigit).ToArray());
            
                if (digits.Length > 0)
                {
                    var firstDigit = int.Parse(digits[0].ToString());
                    var lastDigit = digits.Length > 1 ? int.Parse(digits[^1].ToString()) : firstDigit;
                    totalSum += firstDigit * 10 + lastDigit;
                }
            }
        }

        Console.WriteLine($"Total Sum: {totalSum}");
    }
}