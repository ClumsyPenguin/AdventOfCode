using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC2023.Day3
{
    public static class Solution
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("day3/input.txt");

            var totalPartNumber = lines.Select((value, index) => new { value, index }).Sum(line => ProcessLine(line.value, line.index, lines));

            Console.WriteLine(totalPartNumber);
        }

        private static int ProcessLine(string line, int lineNumber, string[] allLines)
        {
            return Regex.Matches(line, @"\d{1,3}")
                        .Where(match => IsPartNumber(line, match, lineNumber, allLines))
                        .Sum(match => int.Parse(match.Value));
        }

        private static bool IsPartNumber(string currentLine, Capture match, int currentLineIndex, string[] allLines)
        {
            var matchString = match.Value;
            var indexOfMatch = currentLine.IndexOf(matchString, StringComparison.Ordinal);
            var indexOffset = matchString.Length;

            var surroundingLines = GetSurroundingLines(currentLineIndex, allLines, indexOfMatch, indexOffset);
            return surroundingLines.Any(ContainsSymbol);
        }

        private static IEnumerable<string> GetSurroundingLines(int currentLineIndex, IReadOnlyList<string> allLines, int indexOfMatch, int indexOffset)
        {
            var upperLine = currentLineIndex > 0 ? ExtractRelevantSubstring(allLines[currentLineIndex - 1], indexOfMatch, indexOffset) : string.Empty;
            var lowerLine = currentLineIndex < allLines.Count - 1 ? ExtractRelevantSubstring(allLines[currentLineIndex + 1], indexOfMatch, indexOffset) : string.Empty;
            var currentLine = allLines[currentLineIndex];
            
            var leftSubstring = indexOfMatch > 0 ? currentLine[(indexOfMatch - 1)..indexOfMatch] : string.Empty;
            var rightSubstring = indexOfMatch + indexOffset < currentLine.Length ? currentLine[(indexOfMatch + indexOffset)..(indexOfMatch + indexOffset + 1)]: string.Empty;

            return new[] { upperLine, lowerLine, leftSubstring, rightSubstring };
        }

        private static string ExtractRelevantSubstring(string line, int indexOfMatch, int indexOffset)
        {
            var startIndex = Math.Max(0, indexOfMatch - 1);
            var length = Math.Min(line.Length - startIndex, indexOffset + 2); //offset = +2 for the -1 offset and the +1 offset
            return line.Substring(startIndex, length);
        }

        private static bool ContainsSymbol(string s)
        {
            return s.Any(IsSymbol);
        }

        private static bool IsSymbol(char c)
        {
            return !char.IsLetterOrDigit(c) && c != '.';
        }
    }
}
