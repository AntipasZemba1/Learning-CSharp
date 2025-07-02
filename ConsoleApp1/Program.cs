using System;
using System.IO;

class DiaryApp
{
    static string filePath = "diary.txt";

    static void Main()
    {
        Console.WriteLine("📔 Welcome to Your Diary");
        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. View all entries");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice (1-3): ");

            string input = Console.ReadLine();
            Console.Clear();

            switch (input)
            {
                case "1":
                    WriteEntry();
                    break;
                case "2":
                    ViewEntries();
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void WriteEntry()
    {
        Console.WriteLine("📝 Write your diary entry below:");
        string entry = Console.ReadLine();

        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        string fullEntry = $"\n[{timestamp}] {entry}";

        try
        {
            File.AppendAllText(filePath, fullEntry);
            Console.WriteLine("✅ Entry saved!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error saving entry: " + ex.Message);
        }
    }

    static void ViewEntries()
    {
        try
        {
            if (File.Exists(filePath))
            {
                Console.WriteLine("📖 Your Diary Entries:\n");
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("📭 No entries found yet.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error reading diary: " + ex.Message);
        }
    }
}