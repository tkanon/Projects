#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace Hangman
{
      public class GameLogic
      {
            private static int wrongGuesses;
            private static int correctGuesses;
            private static int uniqueLetters;
            private static List<string> target = new List<string>();
            private static List<string> guessedLetters = new List<string>();
            public static void NewGame()
            {
                  target.Clear();
                  guessedLetters.Clear();
                  wrongGuesses = 0;
                  correctGuesses = 0;
                  uniqueLetters = 0;

                  Console.WriteLine("What is your target word?");
                  string targetWord = (Console.ReadLine().ToUpper());
                  while (targetWord.Length == 0)
                  {
                        Console.WriteLine("Target word must be atleast 1 character");
                        targetWord = (Console.ReadLine().ToUpper());
                  }

                  List<string> checkedLetters = new List<string>();
                  for (int i = 0; i < targetWord.Length; i++)
                  {
                        string letter = Convert.ToString(targetWord[i]); // For clarity of code
                        target.Add(letter);
                        if (!checkedLetters.Contains(letter))
                        {
                              checkedLetters.Add(letter);
                              uniqueLetters++;
                        }
                  }
                  GameLoop();
            }
            public static void GameLoop()
            {
                  while ((correctGuesses < uniqueLetters) && (wrongGuesses < 7))
                  {
                        TakeGuess();
                        if (wrongGuesses < 7)
                        {
                              PrintLines();
                        }
                  }
                  if (correctGuesses == uniqueLetters)
                  {
                        Console.WriteLine($"{string.Join("", target)} guessed, you won the game!");
                  }
                  else if (wrongGuesses == 7)
                  {
                        Console.WriteLine("Too many wrong guesses, you lost the game!");
                  }
            }
            public static void PrintLines()
            {
                  foreach (string letter in target)
                  {
                        if (guessedLetters.Contains(letter))
                        {
                              Console.Write(letter + " ");
                        }
                        else
                        {
                              Console.Write("_ ");
                        }
                  }
                  Console.WriteLine();
            }
            public static void TakeGuess()
            {
                  Console.Write("Guess a letter: ");
                  string? guess = "";
                  while (guess.Length != 1 || guessedLetters.Contains(guess))
                  {
                        guess = (Console.ReadLine().ToUpper());
                        if (guess.Length != 1)
                        {
                              Console.WriteLine("Guess must be 1 letter");
                        }
                        else if (guessedLetters.Contains(guess))
                        {
                              Console.WriteLine("Letter already guessed, try again");
                        }
                  }
                  guessedLetters.Add(guess);
                  if (target.Contains(guess))
                  {
                        correctGuesses++;
                        Console.WriteLine($"Letter {guess} is correct");
                  }
                  else
                  {
                        wrongGuesses++;
                        Console.WriteLine($"Guessed wrong, {wrongGuesses} mistakes made (max 7)");
                  }
            }
      }
}