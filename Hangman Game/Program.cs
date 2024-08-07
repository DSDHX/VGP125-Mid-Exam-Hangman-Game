class Hangman_Game
{
    static void Main(string[] args)
    {
        List<string> worlist = new List<string> { "dog", "cat", "butterfly" }; // All words should be lowercae

        Random random = new Random();
        string selectedWord = worlist[random.Next(worlist.Count)]; // random select

        char[] displayWord = new string('_', selectedWord.Length).ToCharArray();

        int incorrectGuess = 0;
        List<char> incorrectLetters = new List<char>();

        int tryTimes = 5; //

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome...");
            Console.WriteLine($"Word to guess: {new string(displayWord)}");
            DrawHangman(incorrectLetters.Count);
            Console.WriteLine($"Incorrect letters: {string.Join(" ", incorrectLetters)}");
            Console.WriteLine($"Remaining attempts: {tryTimes - incorrectGuess}");

            Console.Write("Enter your guess: ");
            string playerInput = Console.ReadLine().ToLower(); // lowercase
            
            if (playerInput.Length != 1 || !char.IsLetter(playerInput[0]))
            {
                Console.WriteLine("Invalid input. Please enter a single letter.");
                // Add information later
                Console.ReadKey(); // Allow player to reade error message
                continue;
            }

            char guessedLetter = playerInput[0];

            if (selectedWord.Contains(guessedLetter))
            {
                for (int i = 0; i < selectedWord.Length; i++)
                {
                    if (selectedWord[i] == guessedLetter)
                    {
                        displayWord[i] = guessedLetter;
                    }
                }
            }
            else
            {
                incorrectGuess++;
                incorrectLetters.Add(guessedLetter);
            }

            //Display Hangman

            if (!displayWord.Contains('_'))
            {
                Console.Clear();
                Console.WriteLine("You WIN!");
                Console.WriteLine($"The word is {selectedWord}");
                //
                Console.ReadKey();
                break;
            }
            else if (incorrectGuess > tryTimes)
            {
                Console.WriteLine("YOU LOSE!");
                Console.WriteLine($"The word is {selectedWord}");
                //
                Console.ReadKey();
                break;
            }
        }
    }

    static void DrawHangman(int incorrectLetters)
    {
        Console.WriteLine("/n+---+");
        Console.WriteLine(incorrectLetters >= 1 ? " O  |" : "    |");
        Console.WriteLine(incorrectLetters >= 2 ? " |  |" : "    |");
        Console.WriteLine(incorrectLetters >= 3 ? "/|\\ |" : "    |");
        Console.WriteLine(incorrectLetters >= 4 ? " |  |" : "    |");
        Console.WriteLine(incorrectLetters >= 5 ? "/ \\ |" : "    |");
        Console.WriteLine("   ===");
    }
}