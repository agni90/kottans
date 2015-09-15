using System;
using System.Collections.Generic;
using System.Linq;

namespace FindElements
{
    public class Checkers
    {
        static string[] expectedValues = { "", "/?", "/help", "-help", "-k key value", "-ping", "-print Inga" };
        public Boolean CheckForPrint(string print)
        {
            if (!print.StartsWith("-print"))
            {
                return false;
            }
            var parsedMessage = print.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
            if (parsedMessage.Length > 1)
            {
                for (var i = 1; i < parsedMessage.Length; i++)
                {
                    Console.WriteLine(parsedMessage[i]);
                }
                return true;
            }
            else
            {
                if (parsedMessage[0] == "-print")
                {
                    Console.WriteLine("Message is empty");
                    return true;
                }
            }
            return false;
        }

        public Boolean CheckForHelp(string help)
        {
            if (help.Equals(String.Empty) || help.Equals("/?") || help.Equals("/help") ||
                help.Equals("-help"))
            {
                Console.WriteLine("<{0}> {1}", help, "\nSupported commands:\n\" \", /?, /help, -help - вызов помощи"+
                    "\n\"-print <message>\" - печатает сообщение <message>\n-ping - издает звуковой сигнал"+
                    "\n\"-key value\" - выводит на экран таблицу ключ-значение\n-quit - выход с программы");
                return true;
            }
            return false;
        }

        public Boolean CheckForK(string k)
        {
            if (k.StartsWith("-k"))
            {
                Dictionary<string, string> keyValueDictionary = new Dictionary<string, string>();
                char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
                string[] keyValueWords = k.Split(delimiterChars);
                List<string> list = new List<string>(keyValueWords);
                if (list.Count % 2 == 0)
                {
                    list.Add("null");
                }
                keyValueWords = list.ToArray();
                for (int j = 1; j < keyValueWords.Length; j = j + 2)
                {
                    keyValueDictionary.Add(keyValueWords[j], keyValueWords[j + 1]);
                    Console.WriteLine("<{0}> <{1}>", keyValueWords[j], keyValueWords[j + 1]);
                }
                return true;
            }
            return false;
        }

        public Boolean CheckForPing(string ping)
        {
            if (ping.Equals("-ping"))
            {
                System.Media.SystemSounds.Beep.Play();
                Console.WriteLine("Pinging...");
                return true;
            }
            return false;
        }

        public Boolean CheckIsCommandCorrect(string command)
        {
            Console.WriteLine("Command <" + command + "> is not supported");
            return true;
        }
    }
}
