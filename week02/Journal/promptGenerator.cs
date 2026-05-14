using System;
using System.Collections.Generic;
 
public class PromptGenerator
{
    public List<string> _prompts = new List<string>();
 
    public PromptGenerator()
    {
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("Who did I help today?");
        _prompts.Add("What did I learn today?");
        _prompts.Add("What made me feel happy today?");
        _prompts.Add("What challenge did I face today?");
        _prompts.Add("What am I grateful for today?");
    }
 
    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
 
        int index = randomGenerator.Next(_prompts.Count);
 
        return _prompts[index];
    }
}