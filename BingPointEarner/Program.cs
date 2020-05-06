using System;
using System.Collections.Generic;
using System.Threading;

namespace BingPointEarner
{
    class Program
    {
        static void Main(string[] args)
        {
            var bing = "https://www.bing.com/search?q=";
            var wordList = System.IO.File.ReadAllText(@"/home/r/Programming/C#/BingPointEarner/wordlist.txt");
            var wordsArray = wordList.Split(" ");
            var wordsUsed = new List<string>();
            var rand = new Random();
            var iterate = 1;
            string search;
            bool badChar = false;

            ConsoleKeyInfo userSelection;

            while (wordsUsed.Count <= 29)
            {
                var word = wordsArray[rand.Next(0, wordsArray.Length - 2)];
                if (word.Length >= 5 && wordsUsed.Contains(word) == false)
                {
                    foreach (char letter in word)
                    {
                        if (Char.IsLetter(letter) == false)
                        {
                            badChar = true;
                            break;
                        }
                        else
                        {
                            badChar = false;
                        }
                    }
                    if (badChar == false)
                    {
                        wordsUsed.Add(word);
                    }
                }
            }
            System.Console.WriteLine("The following words were chosen");
            System.Console.WriteLine("_________________________________________"); 
            System.Console.WriteLine("");
            foreach (var term in wordsUsed)
            {
                System.Console.WriteLine($"{iterate}. {term}");
                iterate++;
            }

            System.Console.WriteLine("");
            System.Console.WriteLine("Would you like to search for these terms?");
            System.Console.WriteLine("Y/N:");
            userSelection = Console.ReadKey();
            switch(userSelection.Key)
            {
                case ConsoleKey.Y:
                {
                    foreach(var term in wordsUsed)
                    {
                        search = $"{bing}{term}";
                        System.Diagnostics.Process.Start("firefox", search);
                    }
                    Console.Clear();
                    System.Console.WriteLine("Completed, press [Enter] to exit!");
                    Console.ReadKey();
                    break;
                }
                case ConsoleKey.N:
                {
                    Console.Clear();
                    System.Console.WriteLine("Closing application...");
                    break;
                }
                default:
                {
                    System.Console.WriteLine("You didn't make a valid selection");
                    System.Console.WriteLine("Closing application");
                    break;
                }
            }
        }
    }
}
