class Hangman_Game
{
    static void Main(string[] args)
    {
        List<string> worlist = new List<string> { "dog", "cat", "butterfly" }; // All words should be lowercae

        Random random = new Random();
        string selectedWord = worlist[random.Next(worlist.Count)]; // random select

        char[] displayWord = new string('_', selectedWord.Length).ToCharArray();

        //int incorrectGuess = 0;
        List<char> incorrectLetters = new List<char>();

        //int tryTimes = selectedWord.Length + 6;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome...");
            Console.WriteLine($"Word to guess: {new string(displayWord)}");
            Console.WriteLine($"Incorrect letters: {string.Join(" ", incorrectLetters)}");

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
                //incorrectGuess++;
                incorrectLetters.Add(guessedLetter);
            }

            //Display Hangman

            if (!displayWord.Contains('_'))
            {
                Console.WriteLine("You WIN!");
                break;
            }
            //else if ()
            //{
            //    // LOSE
            //}
        }

        Console.WriteLine($"The word is {selectedWord}");
    }
}