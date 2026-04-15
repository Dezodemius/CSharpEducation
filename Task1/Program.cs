using System;

namespace Task1;

class Program
{
    static void Main(string[] args)
    {
        // if (args.Length == 0)
            // return;
        static void GetHelloMessage(out string input)
        {
            input = $"Привет! Сейчас: {DateTime.Now}";
        }
        var name = "Егор";
        GetHelloMessage(out name);
        Console.WriteLine(name);
    }
    
    public static void GetHelloMessage(out string input)
    {
        input = $"Привет! Сейчас: {DateTime.Now}";
    }
    
    public static void GetHelloMessage1(out string input)
    {
        input = $"Привет! Сейчас: {DateTime.Now}";
    }
    
    public static void GetHelloMessage(out int input)
    {
        input = $"Привет! Сейчас: {DateTime.Now}";
    }
}  
