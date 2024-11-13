#pragma warning disable CS8602 // Dereference of a possibly null reference.
using System;
using System.Collections.Generic;

namespace Hangman
{
      public class Program
      {
            static void Main(string[] args)
            {
                  while (true)
                  {
                        GameLogic.NewGame();
                        Console.WriteLine("Do you want to play again? Y/N");
                        string input = "";
                        while ((input != "Y") && input != "N")
                        {
                              input = Console.ReadLine().ToUpper();
                              if (input == "Y") { break; }
                              else if (input == "N")
                              {
                                    Console.WriteLine("Thanks for playing!");
                                    break;
                              }
                              Console.WriteLine("Invalid input, type Y or N");
                        }
                        if (input == "N") { break; }
                  }
                  Console.WriteLine("This window will automatically close in 5 seconds...");
                  System.Threading.Thread.Sleep(5000);
            }
      }
}