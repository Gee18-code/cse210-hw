using System;
using System.Collections.Generic;
using System.IO;
 
public class Journal
{
    public List<Entry> _entries = new List<Entry>();
 
    public void AddEntry(Entry newentry)
    {
        _entries.Add(newentry);
    }
 
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is currently empty.");
            return;
        }
 
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
 
   
}
 
public void SaveToFile(string file)
{
    using (StreamWriter outputFile = new StreamWriter(file))
    {
        foreach (Entry entry in _entries)
        {
            string sanitizedPrompt = entry._promptText.Replace("|", " ");
            string sanitizedEntry = entry._entryText.Replace("|", " ");
            outputFile.WriteLine($"{entry._date}|{sanitizedPrompt}|{sanitizedEntry}");
        }
    }
    Console.WriteLine("Journal saved successfully.");
}
 
public void LoadFromFile(string file)
{
    if (!File.Exists(file))
    {
        Console.WriteLine("Error: the file does not exist.");
        return;
    }
 
    _entries.Clear();
     string[] lines = File.ReadAllLines(file);
 
     foreach (string line in lines)
     {
         string[] parts = line.Split('|');
         if (parts.Length == 3)
         {
             Entry entry = new Entry();
             entry._date = parts[0];
             entry._promptText = parts[1];
             entry._entryText = parts[2];
             _entries.Add(entry);
         }
     }
     Console.WriteLine("Journal loaded successfully.");
 
    }
 
}