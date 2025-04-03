// Program.cs
using System;
using System.Threading;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.ForegroundColor = ConsoleColor.Cyan;
Typewriter.WriteLine("Initializing CyberGuardian Bot...\n", 30);
Thread.Sleep(500);
new ChatBot().Run();

// Typewriter.cs
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

// AsciiArt.cs
public static class AsciiArt 
{
    public static void Display() 
    {
        string[] artLines = @"
        :@%                                               #@=                   
                       @ #@@@@@@@%@#            *@#            #@%@@@@@@@# @                   
                                        @      @@@-     :@@@      @                                
                                         #@@@      %@@@%      @@@#                                 
                       @@            @@-      @@@         @@@      :@@            @@               
                      @.-@@%@        @  #@@%                   %@@#  #        @%@@= @              
                            %        @ #                           % @        @                    
                            @        @ #          %@@@@@%          % %        @                    
                            #@@@@@@@%@ #         @       @         % @@@@@@@@@%                    
                                     @ *:        #       #         % @                             
                                     @ :#      @%%%@@@@@%%%@      :# @                             
                        @%@              @  @      #           +      %  @              %%@            
                        @ @#*########### @  @      #    @ @    #      @  @ ###########**@ @            
                                     #  @      #    @ @    #      @  #                             
                                      @  *     *    *-*    +     :: @                              
                                      @  @     @%%%#####%%%@     @  @                              
                                @      @  @                     @  @      @                        
                       %@@      @       @  #@                 @%  @       @      @@%               
                       @ @%#%%%#=        @%  @@             @@  #@        :#%%%#%@ @               
                                           @=  *@         @#  :@                                   
                                             %@   *@@ @@#   @@                                     
                                            @:  @@       @@   @                                    
                               @ #@%@@@@%%@@       @@@@@       %@%@@@@@%@# @                       
                               #@@                                       %@%
        ".Split('\n');

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        foreach (string line in artLines)
        {
            Typewriter.WriteLine(line, 5);
        }
        Console.ResetColor();
    }
}

// ChatBot.cs
using System;
using System.Collections.Generic;
using System.Linq;

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

        // 2. Phishing
        _responses.Add(new BotResponse(
            new[] { "phishing", "scam" },
            "Fraudulent attempts to obtain sensitive information",
            "Email claiming your Netflix account is locked",
            "Link goes to netf1ix-login.com (fake site)",
            FormatResponse("🎣 Phishing Red Flags:", new[]
            {
                "• Urgent threats ('Account will be closed!')",
                "• Mismatched sender addresses",
                "• Hover to inspect links before clicking",
                "• Requests for passwords/SMS codes"
            }, ConsoleColor.Red)
        ));

        // 3. Ransomware
        _responses.Add(new BotResponse(
            new[] { "ransomware" },
            "Malware that encrypts files for ransom",
            "Accounting department opens infected invoice attachment",
            "WannaCry attack (2017) encrypted 200k+ systems",
            FormatResponse("💀 Ransomware Protection:", new[]
            {
                "• Maintain offline backups (3-2-1 rule)",
                "• Disable Office macros by default",
                "• Use application whitelisting",
                "• Train staff to recognize suspicious attachments"
            }, ConsoleColor.DarkRed)
        ));

        // 4. VPN
        _responses.Add(new BotResponse(
            new[] { "vpn" },
            "Encrypted tunnel for secure communication",
            "Working from coffee shop WiFi",
            "NordVPN/ProtonVPN for public networks",
            FormatResponse("🛡️ VPN Best Practices:", new[]
            {
                "• Always enable on public WiFi",
                "• Verify kill switch functionality",
                "• Avoid free VPN services",
                "• Use WireGuard or OpenVPN protocols"
            }, ConsoleColor.Blue)
        ));

        // 5. DDoS
        _responses.Add(new BotResponse(
            new[] { "ddos" },
            "Overwhelming systems with traffic floods",
            "Your website becomes unresponsive during product launch",
            "Mirai botnet (2016) took down major sites",
            FormatResponse("🌊 DDoS Mitigation:", new[]
            {
                "• Implement rate limiting",
                "• Use cloud-based protection (Cloudflare, Akamai)",
                "• Maintain excess bandwidth capacity",
                "• Deploy scrubbing centers"
            }, ConsoleColor.Magenta)
        ));

        // 6-15. Additional topics (abbreviated)
        _responses.AddRange(new[]
        {
            CreateResponse("zero-day", "Unknown vulnerability with no patch",
                "Attackers exploit unpatched firewall vulnerability",
                "Log4Shell (2021) affected millions of systems",
                new[] { "• Patch within 24 hours for critical systems", "• Use intrusion prevention systems", "• Network segmentation" }),

            CreateResponse("firewall", "Network traffic filter",
                "Brute force attacks detected on port 22",
                "Configure pfSense/iptables rules",
                new[] { "• Default deny policies", "• Regular rule audits", "• GeoIP blocking" }),

            CreateResponse("social engineering", "Psychological manipulation",
                "Caller claims to be from IT needing your password",
                "Twitter Bitcoin scam (2020) compromised verified accounts",
                new[] { "• Verify identities through second channels", "• Never share credentials via phone", "• Report suspicious requests" }),

            CreateResponse("iot", "Insecure smart devices",
                "Hacked baby monitor used for eavesdropping",
                "Mirai botnet recruited IoT devices",
                new[] { "• Change default credentials", "• Segment IoT networks", "• Disable UPnP" }),

            CreateResponse("dark web", "Unindexed internet layers",
                "Your company's credentials appear on dark web markets",
                "HaveIBeenPwned monitors for exposed data",
                new[] { "• Regular dark web monitoring", "• Assume breach mentality", "• Threat intelligence feeds" }),

            CreateResponse("biometrics", "Fingerprint/face authentication",
                "Fake fingerprints bypass phone security",
                "Deepfake videos tricking facial recognition",
                new[] { "• Multi-factor authentication", "• Liveness detection", "• Fallback to strong passwords" }),

            CreateResponse("supply chain", "Compromised vendor software",
                "Malicious update from a trusted software provider",
                "SolarWinds attack (2020) affected government agencies",
                new[] { "• Software bill of materials", "• Vendor security assessments", "• Isolate critical systems" }),

            CreateResponse("insider threat", "Malicious employees",
                "Disgruntled IT admin deletes critical files",
                "Edward Snowden NSA data leak",
                new[] { "• Principle of least privilege", "• User behavior analytics", "• Exit procedures for departing staff" }),

            CreateResponse("cryptojacking", "Secret cryptocurrency mining",
                "Website visitors' CPUs spike to 100%",
                "Coinhive script mined Monero without consent",
                new[] { "• Monitor CPU usage spikes", "• Browser extensions to block mining", "• Network traffic analysis" }),

            CreateResponse("ai security", "LLM prompt injections",
                "Chatbot reveals sensitive data through clever prompts",
                "Microsoft's Tay chatbot manipulated (2016)",
                new[] { "• Input sanitization", "• Output filtering", "• Rate limiting", "• Human oversight" })
        });
    }

    private static BotResponse CreateResponse(string keyword, string definition,
        string scenario = "", string example = "", string[] tips = null)
    {
        return new BotResponse(
            new[] { keyword },
            definition,
            scenario,
            example,
            FormatResponse($"📚 {definition.ToUpperInvariant()}", new[]
            {
                $"🚨 Scenario: {scenario}",
                $"💡 Example: {example}",
                "🛡️ Best Practices:",
                string.Join("\n", tips ?? Array.Empty<string>())
            }, ConsoleColor.Cyan)
        );
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
        _userName = Console.ReadLine()?.Trim() ?? "User";

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