using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace FindElements
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] expectedValues = {"", "/?", "/help", "-help", "-k key value", "-ping", "-print Inga"};
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("-print "))
                {
                    Console.WriteLine(args[i].Substring(6));
                    continue;
                }
                if (args[i].Equals(String.Empty) || args[i].StartsWith("/?") || args[i].StartsWith("/help") ||
                    args[i].StartsWith("-help"))
                {
                    Console.WriteLine("<{0}> {1}", args[i], "I can help you!");
                    continue;
                }
                if (args[i].StartsWith("-k"))
                {
                    Dictionary<string, string> keyValueDictionary = new Dictionary<string, string>();
                    char[] delimiterChars = {' ', ',', '.', ':', '\t'};
                    string[] keyValueWords = args[i].Split(delimiterChars);
                    List<string> list = new List<string>(keyValueWords);
                    if (list.Count % 2 == 0)
                    {
                        list.Add ("<null>");
                    }
                    keyValueWords = list.ToArray();
                    for (int j = 1; j < keyValueWords.Length; j=j+2)
                    {
                        keyValueDictionary.Add(keyValueWords[j], keyValueWords[j + 1]);
                        Console.WriteLine("<{0}> {1}", keyValueWords[j], keyValueWords[j + 1]);
                    }
                    continue;
                }

                switch (args[i])
                {
                    case "-ping":
                        Console.WriteLine("Pinging...");
                        break;
                    default:
                        Console.WriteLine("Command <" + args[i] + "> is not supported");
                        break;
                }

            }
            Console.ReadLine();
        }
    }

}