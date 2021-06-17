using System;
using System.Text;

namespace Hangman2ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string guessedWord = GuessWord();

            char[] userGuessArray = new char[guessedWord.Length];

            int numberOfGuesses = 0;

            int count = 0;
            bool runFlag = true;

            System.Text.StringBuilder failGuess = new StringBuilder("", guessedWord.Length);
            System.Text.StringBuilder correctGuess = new StringBuilder("", guessedWord.Length);


            Console.WriteLine("Guess this word : ");
            Console.WriteLine(guessedWord); //to be deleted1 for testing purposes

            for (int i = 0; i < guessedWord.Length; i++)
            {
                //initialize array of charater(_) which will be replaced by letters later on
                userGuessArray.SetValue('_', i);

                Console.Write("_ \t");
            }           
            Console.WriteLine();

            do
            {
                //getting user string
                string userInput = GetUserInput();
                //if user guess single character
                if (userInput.Length == 1)
                {
                    //GuessSpecificLetter(guessedWord, userInput);
                    char userInputChar = Convert.ToChar(userInput);
                    Console.WriteLine(userInputChar);
                    //char[] guessedWordArray = guessedWord.ToCharArray();
                    //for(int i = 0; i<guessedWordArray.Length; i++)
                    //{
                    //    if
                    //}
                    //if user guess correct letter
                    if (guessedWord.Contains(userInput))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Congratualtions! {userInput}");
                        int[] guessedWordIndex;
                        char[] guessedWordArray = guessedWord.ToCharArray();
                        for (int i = 0; i < guessedWordArray.Length; i++)
                        {
                            //if it found the character
                            if (userInputChar == guessedWordArray[i])
                            {
                                //Replace _ by the character
                                userGuessArray.SetValue(userInputChar, i);
                                //if all the character is replaced, break the code
                                if (new string(userGuessArray).Equals(guessedWord)) //be carefull when converting string! 
                                {
                                    GuessCorrect(guessedWord);
                                    runFlag = false;
                                    break;

                                }

                            }
                        }

                        Console.WriteLine(userGuessArray);


                        Console.ResetColor();
                    }
                    else//if user guess wrong letter
                    {
                        DrawHangman(count++);
                    }



                }
                else //if user guess whole word
                {
                    if (userInput == guessedWord)
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
            } while (numberOfGuesses < 10 && runFlag == true); ;
        }

        private static string GuessWord()
        {
            //string[] words = new string[] { "Keyboard", "People", "Machine", "School", "Lucky", "Geogerous","Football" };
            string[] words = new string[] { "Ky", "Pe", "Maas" };

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
