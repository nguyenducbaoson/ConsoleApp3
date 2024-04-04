using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static Dictionary<int, int> CalculateEntries(List<int> licensePlateList)
    {
        Dictionary<int, int> entriesCount = new Dictionary<int, int>();
        foreach (int plate in licensePlateList)
        {
            if (entriesCount.ContainsKey(plate))
                entriesCount[plate]++;
            else
                entriesCount.Add(plate, 1);
        }
        return entriesCount;
    }

    static void WriteToTextFile(Dictionary<int, int> entryCounts, string outputFile)
    {
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (KeyValuePair<int, int> entry in entryCounts)
            {
                writer.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }

    static void Main()
    {
        string filePath = @"D:\.NET\ConsoleApp3\in.txt";
        string outputFilePath = @"D:\.NET\ConsoleApp3\out.txt";

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            List<int> licensePlateList = new List<int>();

            foreach (string line in lines)
            {
                if (int.TryParse(line, out int plateNumber))
                {
                    licensePlateList.Add(plateNumber);
                }
                else
                {
                    Console.WriteLine($"Invalid plate number: {line}");
                }
            }
            Dictionary<int, int> entriesCount = CalculateEntries(licensePlateList);
            Console.WriteLine("Total number of entries for each vehicle throughout the month:");
            foreach (KeyValuePair<int, int> entry in entriesCount)
            {
                Console.WriteLine($"License Plate: {entry.Key}, Entries: {entry.Value}");
                WriteToTextFile(entriesCount, outputFilePath);
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
