using System.Text;

namespace AOC2023.Day1;

public class Solution
{
    public static void Run()
    {
        var convert = new Dictionary<string, string>{
            {"one", "1"},
            {"two", "2"},
            {"three", "3"},
            {"four", "4"},
            {"five", "5"},
            {"six", "6"},
            {"seven", "7"},
            {"eight", "8"},
            {"nine", "9"}
        };
                
        var answer = File.ReadAllLines("day1/input.txt")
            .Select(x => convert.Aggregate (x ,(a, b) => a.Replace(b.Key, $"{b.Key}{b.Value}{b.Key}")))
            .Select(x => (x.First(char.IsDigit), x.Last(char.IsDigit)))
            .Select(x => $"{x.Item1}{x.Item2}")
            .Select(int.Parse)
            .Sum();
        Console.WriteLine(answer);
    }
}