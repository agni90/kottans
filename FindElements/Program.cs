using System;
using System.Collections.Generic;
using System.Text;

/*Вот наши замечания:
- Программа не рабочая, к примеру, когда ввожу -print test, говорит что команда не найдена, потому что в CheckForPrint идут затрименые параметры. 
  По-хорошему неплохо было бы распарсить на массив состоящий из команды-параметров и уже идти по этому массиву, пытаясь выполнить команды
 * Метод CheckForPrint доработан. Если команда состоит из нескольких слов - ее необходимо вводить в " ".
 ___________________________________________________________
- -ping должен издавать звуковой сигнал
 * Метод доработан, звуковой сигнал издается.
 ___________________________________________________________
- -help должен выдавать список возможных команд, а не просто "I can help you!"
 * Метод CheckForHelp доработан и выводит список команд.
 ___________________________________________________________
+ юнит-тесты
- NUnit лучше подключать в проект с юнит-тестами, а не с самой программой. Кроме того, для юнит-тестов почему-то юзается MS Unit Tests
 * NUnit был подключен случайно. Убрала
___________________________________________________________ 
- Непонятно зачем нужен объект класса Checkers, если он не хранит состояния, все методы можно сделать статическими
 *
- Почему нужно было писать свою имплементацию метода Split, если есть уже готовая?
 */

namespace FindElements
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hi, welcome to my test task.\nPlease, input commands, that contains multiple words in quote marks\nExample: \" -print test\"");
            var checker = new Checkers();
            var inputParams = args;
            while (true)
            {

                bool isChecked = false;
                for (int i = 0; i < inputParams.Length; i++)
                {
                    if (inputParams[i].Equals("-quit"))
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

                //the next line splits string to array
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


