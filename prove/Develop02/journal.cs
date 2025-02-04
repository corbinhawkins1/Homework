// using System;
// using System.Collections.Generic;
// using System.IO;

// class JournalEntry
// {
//     public DateTime Date { get; set; }
//     public string Content { get; set; }
//     public JournalEntryEntry(string content)
// {
//     Date = DateTime.Now;
//     Content = content;
// }
// public override string ToString()
// {
//     return $"{Date:G}\n"
// }
// }
// class Journal
// {
//     private List<JournalEntry> entries = new List<JournalEntry










// }

// {
//     static void Main(string[] args)
// { 
//     DisplayWelcomMessage();


// }


// Console.writeLine("Journal Program")


using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public JournalEntry(string prompt, string response)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"{Date} | {Prompt} | {Response}";
    }
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];

        Console.WriteLine("\n--- Journal Prompt ---");
        Console.WriteLine(prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        entries.Add(new JournalEntry(prompt, response));
        Console.WriteLine("\n✅ Entry added successfully!");
    }

    public void DisplayEntries()
    {
        Console.Clear();
        Console.WriteLine("\n====== Journal Entries ======\n");

        if (entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
        }
        else
        {
            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
                Console.WriteLine("--------------------------------");
            }
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save (e.g., journal.txt): ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine(entry);
            }
        }
        Console.WriteLine("\n✅ Journal saved successfully!");
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load (e.g., journal.txt): ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("\n⚠️ File not found.");
            return;
        }

        entries.Clear();
        foreach (var line in File.ReadLines(filename))
        {
            Console.WriteLine(line);
        }

        Console.WriteLine("\n✅ Journal loaded successfully!");
    }
}

class Program
{
    static void Main()
    {
        Journal myJournal = new Journal();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("========= JOURNAL MENU =========");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. View Journal");
            Console.WriteLine("3. Save Journal to File");
            Console.WriteLine("4. Load Journal from File");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    myJournal.AddEntry();
                    break;
                case "2":
                    myJournal.DisplayEntries();
                    Console.WriteLine("\nPress any key to return...");
                    Console.ReadKey();
                    break;
                case "3":
                    myJournal.SaveToFile();
                    Console.WriteLine("\nPress any key to return...");
                    Console.ReadKey();
                    break;
                case "4":
                    myJournal.LoadFromFile();
                    Console.WriteLine("\nPress any key to return...");
                    Console.ReadKey();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("\nGoodbye!");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
