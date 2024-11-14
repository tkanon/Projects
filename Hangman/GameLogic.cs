#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace Hangman
{
      public class GameLogic
      {
            private static int wrongGuesses;
            private static int correctGuesses;
            private static int uniqueLetters;
            private static List<string> targetWord = new List<string>();
            private static List<string> guessedLetters = new List<string>();
            private static string fileName = "WordList.txt";
            public static void NewGame()
            {
                  targetWord.Clear();
                  guessedLetters.Clear();
                  wrongGuesses = 0;
                  correctGuesses = 0;
                  uniqueLetters = 0;

                  string targetWordInput = GenerateWord();

                  List<string> checkedLetters = new List<string>();
                  for (int i = 0; i < targetWordInput.Length; i++)
                  {
                        string letter = Convert.ToString(targetWordInput[i]); // For clarity of code
                        targetWord.Add(letter);
                        if (!checkedLetters.Contains(letter) && letter != " ")
                        {
                              checkedLetters.Add(letter);
                              uniqueLetters++;
                        }
                  }
                  GameLoop();
            }
            private static void GameLoop()
            {
                  while ((correctGuesses < uniqueLetters) && (wrongGuesses < 7))
                  {
                        PrintLines();
                        TakeGuess();
                        if (wrongGuesses < 7)
                        {
                              Console.WriteLine($"Used letters: {string.Join(", ", guessedLetters)}");
                        }
                  }
                  if (correctGuesses == uniqueLetters)
                  {
                        Console.WriteLine($"{string.Join("", targetWord)} guessed, you won the game!");
                  }
                  else if (wrongGuesses >= 7)
                  {
                        Console.WriteLine("Too many wrong guesses, you lost the game!");
                        Console.WriteLine($"Target word was: {string.Join("", targetWord)}");
                  }
            }
            private static void PrintLines()
            {
                  Console.WriteLine();
                  foreach (string letter in targetWord)
                  {
                        if (guessedLetters.Contains(letter))
                        {
                              Console.Write(letter + " ");
                        }
                        else if (letter == " ") { Console.Write(" "); }
                        else
                        {
                              Console.Write("_ ");
                        }
                  }
                  Console.WriteLine();
                  Console.WriteLine();
            }
            private static void TakeGuess()
            {
                  Console.Write("Guess a letter: ");
                  string? guess = "";
                  while (guess.Length != 1 || string.IsNullOrWhiteSpace(guess))
                  {
                        guess = (Console.ReadLine().ToUpper());
                        if (guess.Length != 1 || string.IsNullOrWhiteSpace(guess))
                        {
                              Console.WriteLine("Guess must be 1 letter");
                        }
                        else if (guessedLetters.Contains(guess))
                        {
                              Console.WriteLine("Letter already guessed, try again");
                        }
                  }
                  Console.WriteLine();
                  guessedLetters.Add(guess);
                  if (targetWord.Contains(guess))
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
            public static string GenerateWord()
            {
                  string? targetWordInput = "";
                  Console.WriteLine("How would you like to select the target word?");
                  Console.WriteLine("1: Generate a random word");
                  Console.WriteLine("2: Create your own word");
                  string? input = Console.ReadLine();
                  while (input != "1" && input != "2")
                  {
                        Console.WriteLine("Answer must be '1' or '2'");
                        input = Console.ReadLine();
                  }
                  if (input == "1")
                  {
                        Random rnd = new Random();
                        int randomLine = rnd.Next(1, WordCountFromFile(fileName));
                        targetWordInput = File.ReadLines(fileName).Skip(randomLine).Take(1).First().ToUpper();
                  }
                  else if (input == "2")
                  {
                        Console.Write("Enter a target word: ");
                        targetWordInput = (Console.ReadLine().ToUpper());
                        while (targetWordInput.Length < 1)
                        {
                              Console.WriteLine("Target word must be atleast 1 character");
                              targetWordInput = (Console.ReadLine().ToUpper());
                        }
                  }
                  return targetWordInput;
            }
            private static int WordCountFromFile(string fileName)
            {
                  return File.ReadLines(fileName).Count();
            }
            public static bool IsWordListUnique()                 // Add to main method for checking word list file,
            {                                                     // returns true if there is no repeated words
                  var linesRead = File.ReadLines(fileName);
                  List<string> checkWords = new List<string>();
                  int row = 0;
                  int repeats = 0;
                  foreach (var line in linesRead)
                  {
                        row++;
                        if (!checkWords.Contains(line))
                        {
                              checkWords.Add(line);
                              return true;
                        }
                        else
                        {
                              Console.WriteLine("Repeat at: " + row + " " + line);
                              repeats++;
                        }
                  }
                  Console.WriteLine("Repeated word count: " + repeats);
                  return false;
            }
      }
}