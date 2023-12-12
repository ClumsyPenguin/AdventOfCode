namespace AOC2023.Common;

using System;
using System.IO;
using System.Text;

public static class TextFileReader
{
    private static string BasePath => "/Users/seppegeerinckx/Projects/AdventOfCode/2023/AOC2023";

    public static MemoryStream ReadFileToMemoryStream(string relativeFilePath)
    {
        var memoryStream = new MemoryStream();
        var fullPath = Path.Combine(BasePath, relativeFilePath);

        if (!File.Exists(fullPath))
        {
            Console.WriteLine("File does not exist.");
            return memoryStream;
        }

        var fileContent = File.ReadAllText(fullPath);
        try
        {
            var bytes = Encoding.UTF8.GetBytes(fileContent);
            memoryStream.Write(bytes, 0, bytes.Length);

            memoryStream.Position = 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        return memoryStream;
    }
}

