using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberSecurityChatBot
{
    public class ChatBot
    {
        private string _userName = "Guest";
        private readonly List<BotResponse> _responses = new();

        public ChatBot() => InitializeResponses();

        private void InitializeResponses()
        {
            // 1. Passwords
            _responses.Add(new BotResponse(
                new[] { "password", "credentials" },
                "Authentication strings that verify user identity",
                "Your password 'Summer2023' appears in a data breach",
                "Use 'Xk2!9$pLq*Wn' with a password manager",
                FormatResponse("🔐 Strong passwords should:", new[]
                {
                    "• Be 12+ characters long",
                    "• Include upper/lowercase + numbers + symbols",
                    "• Never be reused across sites",
                    "• Use passphrases: 'PurpleTiger$Eats_8Pizzas'"
                }, ConsoleColor.Yellow)
            ));

            // [Rest of your responses...]
        }

        private static string FormatResponse(string header, string[] content, ConsoleColor color)
        {
            ConsoleColor original = Console.ForegroundColor;
            Console.ForegroundColor = color;
            string result = $"\n{header}\n{string.Join("\n", content)}\n";
            Console.ResetColor();
            return result;
        }

        public void Run()
        {
            Console.Clear();
            AsciiArt.Display();

            Typewriter.WriteColored("\nWhat's your name? ", ConsoleColor.Green);
            _userName = Console.ReadLine()?.Trim() ?? string.Empty;

            Typewriter.WriteColored($"\nWelcome {_userName}! Type 'help' for options or 'exit' to quit.", 
                ConsoleColor.Green, 20);

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\n{_userName}> ");
                Console.ForegroundColor = ConsoleColor.Gray;
                var input = Console.ReadLine()?.ToLower() ?? "";

                if (string.IsNullOrWhiteSpace(input)) continue;
                if (input == "exit") break;
                if (input == "help") ShowHelp();

                string response = GetResponse(input);
                Typewriter.WriteLine(response, 10);
            }

            Typewriter.WriteColored("\nSession secured. Goodbye!", ConsoleColor.Green);
        }

        private void ShowHelp()
        {
            Typewriter.WriteColored("\nAvailable topics:", ConsoleColor.Yellow);
            var categories = _responses
                .SelectMany(r => r.Keywords)
                .Distinct()
                .OrderBy(k => k);

            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var category in categories)
            {
                Console.WriteLine($"• {category}");
            }
            Console.ResetColor();
        }

        private string GetResponse(string input)
        {
            var response = _responses.FirstOrDefault(r => r.Matches(input));
            return response != null
                ? response.Answer
                : "I didn't understand. Type 'help' to see available topics.";
        }
    }

    public class BotResponse
    {
        public string[] Keywords { get; }
        public string Answer { get; }

        public BotResponse(string[] keywords, string definition,
            string scenario, string example, string response)
        {
            Keywords = keywords;
            Answer = $"\n📚 {definition.ToUpperInvariant()}\n\n" +
                    $"🚨 Scenario: {scenario}\n" +
                    $"💡 Example: {example}\n\n" +
                    $"{response}";
        }

        public bool Matches(string input) =>
            Keywords.Any(k => input.Contains(k, StringComparison.OrdinalIgnoreCase));
    }
}