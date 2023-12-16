using System.Text.RegularExpressions;

namespace AOC2023.Day2
{
    public static class Solution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("day2/input.txt");
            var totalPower = 0;

            foreach (var line in lines)
            {
                var sets = line.Split(';');
                var minCubes = new Dictionary<string, int>
                {
                    {"red", 0},
                    {"green", 0},
                    {"blue", 0}
                };

                foreach (var set in sets)
                {
                    var currentCubes = new Dictionary<string, int>
                    {
                        {"red", 0},
                        {"green", 0},
                        {"blue", 0}
                    };

                    foreach (Match match in Regex.Matches(set, @"(\d+)\s(red|blue|green)"))
                    {
                        var number = int.Parse(match.Groups[1].Value);
                        var color = match.Groups[2].Value;
                        currentCubes[color] += number;
                    }

                    foreach (var color in currentCubes.Keys)
                    {
                        minCubes[color] = Math.Max(minCubes[color], currentCubes[color]);
                    }
                }

                var power = minCubes["red"] * minCubes["green"] * minCubes["blue"];
                totalPower += power;
            }

            Console.WriteLine(totalPower);
        }
    }
}