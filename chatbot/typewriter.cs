using System;
using System.Threading;

namespace CyberSecurityChatBot
{
    public static class Typewriter
    {
        public static void WriteLine(string text, int delayMs = 10)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

        public static void WriteColored(string text, ConsoleColor color, int delayMs = 10)
        {
            Console.ForegroundColor = color;
            WriteLine(text, delayMs);
            Console.ResetColor();
        }
    }
}