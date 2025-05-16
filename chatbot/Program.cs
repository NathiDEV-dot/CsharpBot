using System;
using System.Threading;

namespace CyberSecurityChatBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Typewriter.WriteLine("Initializing CyberGuardian Bot...\n", 30);
            Thread.Sleep(500);
            new ChatBot().Run();
        }
    }
}