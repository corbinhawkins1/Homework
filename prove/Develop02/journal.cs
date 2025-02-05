
using System;
using System.Collections.Generic;
using System.IO;


class Journal
{
    private List<Entries> entries = new List<Entries>();
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
        Console.WriteLine("What was your mood today?: ");
        string mood = Console.ReadLine();
        Console.WriteLine("\n--- Journal Prompt ---");
        Console.WriteLine(prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        Entries entry = new Entries(response, dateText, prompt, mood);
        entries.Add(entry);

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
                Console.WriteLine(entry.display());
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
                writer.WriteLine(entry.export());
            
            }
        }
        Console.WriteLine("\n✅ Journal saved successfully!");
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load (e.g., journal.txt): ");
        string filename = Console.ReadLine();

       
string[] lines = System.IO.File.ReadAllLines(filename);

foreach (string line in lines)
{
    string[] parts = line.Split("|");

    string response = parts[0];
    string prompt = parts[1];
    string date = parts[2];
    string mood = parts[3];
    Entries entry = new Entries(response, date, prompt, mood);
        entries.Add(entry);

}
    }
}