class Hangman_Game
{
    static List<string> wordlist = new List<string> { "dog", "cat", "butterfly" }; // All words should be lowercae

    static void Main(string[] args) // Game Menu Page
    {
        Console.WriteLine("==============================================================");
        Console.WriteLine("██╗    ██╗███████╗ ██████╗██╗      ██████╗ ███╗   ███╗███████╗");
        Console.WriteLine("██║    ██║██╔════╝██╔════╝██║     ██╔═══██╗████╗ ████║██╔════╝");
        Console.WriteLine("██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗  ");
        Console.WriteLine("██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝  ");
        Console.WriteLine("╚███╔███╔╝███████╗╚██████╗███████╗╚██████╔╝██║ ╚═╝ ██║███████╗");
        Console.WriteLine(" ╚══╝╚══╝ ╚══════╝ ╚═════╝╚══════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝");
        Console.WriteLine("==============================================================");
        Console.WriteLine("                 Welcome to Hangman Game!");
        Console.WriteLine("\n                 Press any key to continue");
        Console.ReadKey(); // Allow player to reade message

        while (true)
        {
            Console.Clear();
            Console.WriteLine("==============Game Menu==============");
            Console.WriteLine("           1. Start Game");
            Console.WriteLine("           2. Add Word");
            Console.WriteLine("           3. Remove Word");
            Console.WriteLine("           4. Exit");
            Console.WriteLine("=====================================");

            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    PlayHangman();
                    break;
                case "2":
                    AddWord();
                    break;
                case "3":
                    RemoveWord();
                    break;
                case "4":
                    Console.WriteLine("\nExiting the game...");
                    Console.WriteLine("Thanks for plyaing!");
                    return;
                default:
                    Console.WriteLine("\nInvalid choice. Please enter a valid option.");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void PlayHangman() // Core Game
    {
        Random random = new Random();
        string selectedWord = wordlist[random.Next(wordlist.Count)]; // random select

        char[] displayWord = new string('_', selectedWord.Length).ToCharArray();

        int incorrectGuess = 0;
        List<char> incorrectLetters = new List<char>();

        int tryTimes = 5; // (slectedWord.Length + a number). If want dynamic difficulty

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Word to guess: {new string(displayWord)}");
            DrawHangman(incorrectLetters.Count);
            Console.WriteLine($"Incorrect letters: {string.Join(" ", incorrectLetters)}");
            Console.WriteLine($"Remaining attempts: {tryTimes - incorrectGuess}");

            Console.Write("Enter your guess (one letter): ");
            string playerInput = Console.ReadLine().ToLower(); // lowercase

            if (playerInput.Length != 1 || !char.IsLetter(playerInput[0]))
            {
                Console.WriteLine("\nInvalid input. Please enter a single letter.");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
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

            if (!displayWord.Contains('_'))
            {
                Console.Clear();
                Console.WriteLine("=============================");
                Console.WriteLine("         YOU WIN!");
                Console.WriteLine("=============================");
                Console.WriteLine($"The word is {selectedWord}");
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
                break;
            }
            else if (incorrectGuess > tryTimes)
            {
                Console.WriteLine("\n=============================");
                Console.WriteLine("         YOU LOSE!");
                Console.WriteLine("=============================");
                Console.WriteLine($"The word is {selectedWord}");
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
                break;
            }
        }
    }


    static void DrawHangman(int incorrectLetters)
    {
        Console.WriteLine("                                    /n+---+");
        Console.WriteLine(incorrectLetters >= 1 ? "                                     O  |" : "                                        |");
        Console.WriteLine(incorrectLetters >= 2 ? "                                     |  |" : "                                        |");
        Console.WriteLine(incorrectLetters >= 3 ? "                                    /|\\ |" : "                                        |");
        Console.WriteLine(incorrectLetters >= 4 ? "                                     |  |" : "                                        |");
        Console.WriteLine(incorrectLetters >= 5 ? "                                    / \\ |" : "                                        |");
        Console.WriteLine("                                       ===");
    }

    static void AddWord()
    {
        Console.Clear();
        Console.Write("Enter a world to add: ");
        string newWord = Console.ReadLine().Trim().ToLower(); // delete the space and convert to lowercase
        if (!wordlist.Contains(newWord) && newWord.All(Char.IsLetter))
        {
            wordlist.Add(newWord);
            Console.WriteLine($"'{newWord}' has been added!");
        }
        else
        {
            Console.WriteLine("Invalid word or already exists in list.");
        }
        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
    }

    static void RemoveWord()
    {
        Console.Clear();
        Console.WriteLine("Notice: If you accidentally click in. You can return to the menu by using the Enter key twice.\n");
        Console.WriteLine("Current word list: ");
        for (int i = 0; i < wordlist.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {wordlist[i]}");
        }
        Console.WriteLine("Choose which word do you want to remove");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= wordlist.Count)
        {
            string wordToRemove = wordlist[index - 1];
            wordlist.RemoveAt(index - 1);
            Console.WriteLine($"'{wordToRemove}' has been removed.");
        }
        else
        {
            Console.WriteLine("Invalid chose.");
        }
        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
    }
}