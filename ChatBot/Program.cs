using System;
using System.Collections.Generic;

namespace MiniChatBotApp
{
    class ChatBot
    {
        private string userName = "istifadəçi";
        private Dictionary<string, List<string>> responses;

        public ChatBot()
        {
            responses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "salam", new List<string>{ "Salam! Necəsən? 😊", "Salam dostum!", "Salam, xoş gördük! 👋" } },
                { "necəsən", new List<string>{ "Əla, bəs sən? 😎", "Həmişə yaxşıyam! 👍", "Super gedir, sən necəsən?" } },
                { "adın nədir", new List<string>{ "Mənim adım MiniBot-dur 🤖", "Məni ChatBot çağır 😁" } },
                { "hava necədir", new List<string>{ "Mənim üçün hava həmişə günəşlidir ☀️", "Buludlu deyil, kodlarla işıqlıdır 🌈" } },
                { "səni kim yaratdı", new List<string>{ "Məni Zamin yaratdı 🔥", "Səni maraqlandırırsa, sən yaratdın 😅" } },
                { "sağ ol", new List<string>{ "Sən də sağ ol 👍", "Minnətdaram 🙏", "Çox sağ ol!" } },
            };
        }

        public void Start()
        {
            Console.Title = "Mini Chat Bot";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("🤖 Salam! Mən sadə bir Chat Botam. Çıxmaq üçün 'exit' yaz.\n");
            Console.ResetColor();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{userName}: ");
                string input = Console.ReadLine()?.Trim();
                Console.ResetColor();

                if (string.IsNullOrEmpty(input))
                    continue;

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                Respond(input);
            }

            Console.WriteLine("\n👋 Sağ ol! Yenidən görüşərik.");
        }

        private void Respond(string input)
        {
            // İlk dəfə istifadəçi adını soruşaq
            if (input.StartsWith("mənim adım"))
            {
                userName = input.Replace("mənim adım", "", StringComparison.OrdinalIgnoreCase).Trim();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Bot: Tanış olduq, {userName}! 😃");
                Console.ResetColor();
                return;
            }

            if (responses.ContainsKey(input))
            {
                var possibleAnswers = responses[input];
                var random = new Random();
                string answer = possibleAnswers[random.Next(possibleAnswers.Count)];

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Bot: " + answer);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bot: Bağışla, mən bu sözü anlamadım. 😅");
            }

            Console.ResetColor();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var bot = new ChatBot();
            bot.Start();
        }
    }
}
