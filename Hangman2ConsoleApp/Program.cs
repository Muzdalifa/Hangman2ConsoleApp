using System;
using System.Text;

namespace Hangman2ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string guessedWord = GuessWord();

            char[] guessWordArray = new char[guessedWord.Length];

            int numberOfGuesses = 0;

            int count = 0;

            System.Text.StringBuilder failGuess = new StringBuilder("", guessedWord.Length);
            System.Text.StringBuilder correctGuess = new StringBuilder("", guessedWord.Length);


            Console.WriteLine("Guess this word : ");
            Console.WriteLine(guessedWord); //to be deleted1 for testing purposes

            for (int i = 0; i < guessedWord.Length; i++)
            {
                //initialize array of charater(_) which will be replaced by letters later on
                guessWordArray.SetValue('_', i);

                Console.Write("_ \t");
            }           
            Console.WriteLine();

            do
            {
                //getting user string
                string userInput = GetUserInput();
                if(userInput.Length == 1)
                {
                    //GuessSpecificLetter(guessedWord, userInput);
                    char userInputChar = Convert.ToChar(userInput);
                    Console.WriteLine(userInputChar);
                   


                }
                else
                {
                    if(userInput == guessedWord)
                    {
                        GuessCorrect(guessedWord);
                        break;
                    }
                    else
                    {
                        
                        DrawHangman(count++);
                    }
                    
                }


                numberOfGuesses++;
            } while (numberOfGuesses < 10);
        }

        private static string GuessWord()
        {
            //string[] words = new string[] { "Keyboard", "People", "Machine", "School", "Lucky", "Geogerous","Football" };
            string[] words = new string[] { "Ky", "Pe", "Mas" };

            Random randObj = new Random();
            var randomIndex = randObj.Next(0, words.Length);
            return words[randomIndex].ToLower();
        }

        private static string GetUserInput()
        {
            Console.Write("Enter word or character to guess : ");
            return Console.ReadLine();
        }

        private static void GuessCorrect(string word)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"CONGRATULATION!! YOUR GUESS WAS CORRECT! {word}");
            Console.ResetColor();
        }

        private static void DrawHangman(int hangmanLength)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong");
            string[] hangman = new string[]{"________",
                                    "________ \n | \n |\n |\n |",
                                    "________ \n | \n |\n |\n |\n ----------- ",
                                    "________ \n |     |\n |\n |\n |\n -----------",
                                    "________ \n |     |\n |     o\n |\n |\n -----------",
                                    "________ \n |     |\n |     o\n |    /|\\\n |\n -----------",
                                    "________ \n |     |\n |     o\n |    /|\\\n |   _/ \\_\n -----------",
                                    "________ \n |     |\n |     o\n |    /|\\\n |   _/ \\_\n |\n-----------",
                                    "________ \n |     |\n |     o\n |    /|\\\n |   _/ \\_\n |\n|\n-----------",
                                    "________ \n |     |\n |     o\n |    /|\\\n |   _/ \\_\n | Ooooh NO!\n-----------"};

            Console.WriteLine($@"{hangman[hangmanLength]}");
            Console.ResetColor();
        }
        private static void GuessSpecificLetter(string guessedWord, string userInput)
        {

        }

        private static void GuessWholeWord()
        {

        }
    }
}
