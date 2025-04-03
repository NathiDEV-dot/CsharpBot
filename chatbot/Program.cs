using System;

class Program 
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Enable special characters
        new ChatBot().Run();
    }
}