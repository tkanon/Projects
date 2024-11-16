#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace Hangman
{
      public class GameLogic
      {
            private static int wrongGuesses;
            private static int correctGuesses;
            private static int uniqueLetters;
            private static List<char> targetWord = new List<char>();
            private static List<char> guessedLetters = new List<char>();
            private static string fileName = "WordList.txt";
            public static void NewGame()
            {
                  targetWord.Clear();
                  guessedLetters.Clear();
                  wrongGuesses = 0;
                  correctGuesses = 0;
                  uniqueLetters = 0;

                  string targetWordInput = GenerateWord();

                  List<char> checkedLetters = new List<char>();
                  for (int i = 0; i < targetWordInput.Length; i++)
                  {
                        char character = targetWordInput[i]; // For clarity of code
                        targetWord.Add(character);
                        if (!checkedLetters.Contains(character) && character != ' ')
                        {
                              checkedLetters.Add(character);
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
                        if (wrongGuesses < 7) Console.WriteLine($"Used letters: {string.Join(", ", guessedLetters)}");
                  }
                  if (correctGuesses == uniqueLetters) Console.WriteLine($"{string.Join("", targetWord)} guessed, you won the game!");
                  else if (wrongGuesses >= 7)
                  {
                        Console.WriteLine("Too many wrong guesses, you lost the game!");
                        Console.WriteLine($"Target word was: {string.Join("", targetWord)}");
                  }
            }
            private static void PrintLines()
            {
                  Console.WriteLine();
                  foreach (char letter in targetWord)
                  {
                        if (guessedLetters.Contains(letter))
                        {
                              Console.Write(letter + " ");
                        }
                        else if (letter == ' ') { Console.Write(" "); }
                        else Console.Write("_ ");
                  }
                  Console.WriteLine();
                  Console.WriteLine();
            }
            private static void TakeGuess()
            {
                  char guess = ' ';
                  while (true)
                  {
                        Console.Write("Guess a letter: ");
                        string? input = Console.ReadLine();
                        if (input.Length == 1 && !string.IsNullOrEmpty(input))
                        {
                              guess = Convert.ToChar(input.ToUpper());
                              if (guessedLetters.Contains(guess))
                              {
                                    Console.WriteLine("Letter already guessed, try again");
                              }
                              else break;
                        }
                        else Console.WriteLine("Guess must be 1 letter");
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
            private static int WordCountFromFile(string fileName) { return File.ReadLines(fileName).Count(); }
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