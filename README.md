# Introduction

This program is a simple word guessing game, based on the C#. The program allows the player to add the words they want, or delete the current word. And the game called “Hangman Game”.

# Code Introduction

The first part of the game starts with the display of a welcome screen. The player needs to press a key to get access to the game menu, here we will have the option to start the game, add words, remove words, and exit the game. If the player enters a number along with letters or characters, the program will display a message saying “invalid input” or “Invalid word”. This action will result in the player being redirected to the game's main menu, in the current game, the player has to press a key and type a single letter. 

Selecting option one will bring you to the game where players must guess a specific word. Each player has 5 attempts to guess the word and will lose one attempt for each wrong letter. If the player runs out of 5 attempts without guessing the word, a message will be displayed that says “You Lose”, showing the correct word and offering an option to return to the main menu of the game. 

The code involves basic C#. The core part is that a new string is created by a ***new string('_', selectedWord.Length)***.  The string contains ***selectedWord.Length*** underscores. Then, use the ***ToCharArray()*** method to convert it into an array of characters. When the player guesses the letter correctly. The underscores will turn into the correct letter.

# Credit

Narda Limon Lagunas (2342884)

Haoxi Dong (2343873)
