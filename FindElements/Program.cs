using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace FindElements
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hi, welcome to my test task");
            var checker = new Checkers();
            var inputParams = args;
            while (true)
            {

                bool isChecked = false;
                for (int i = 0; i < inputParams.Length; i++)
                {
                    if (inputParams[i].Equals("quit"))
                    {
                        Console.WriteLine("Goodbye");
                        return;
                    }
                    isChecked = checker.CheckForPrint(inputParams[i]) ? true : false;
                    isChecked = isChecked || checker.CheckForHelp(inputParams[i]) ? true : false;
                    isChecked = isChecked || checker.CheckForK(inputParams[i]) ? true : false;
                    isChecked = isChecked || checker.CheckForPing(inputParams[i]) ? true : false;
                    isChecked = isChecked || checker.CheckIsCommandCorrect(inputParams[i]) ? true : false;

                }

                inputParams = Console.ReadLine().SplitInputValue();
            }
        }
    }

    public static class StringExtensions
    {
        public static string[] SplitInputValue(this string str)
        {
            var output = new List<string>();
            var symbols = str.ToCharArray();
            var builder = new StringBuilder();
            for (int i = 0; i < symbols.Length; i++)
            {
                // check for ' " ' symbol
                if (symbols[i] == '"')
                {
                    i++;
                    while (symbols[i] != '"')
                    {
                        builder.Append(symbols[i]);
                        i++;
                        if (i >= symbols.Length) break;
                    }
                }
                else
                {
                    while (symbols[i] != ' ')
                    {
                        builder.Append(symbols[i]);
                        i++;
                        if (i >= symbols.Length) break;
                    }
                }


                output.Add(builder.ToString());
                builder.Clear();
            }
            return output.ToArray();
        }
    }
}


