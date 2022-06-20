using System;
using System.Linq;
using System.Collections.Generic;

namespace Hangman
{
    public class Player
    {
        public List<string> guessed { get; set; } = new List<string>();
        public int guesses { get; set; } = 0;
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player();
            Player p2 = new Player();
            Console.WriteLine("Player 1 please enter your name.");
            p1.Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Player 2 please enter your name.");
            p2.Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"{p1.Name} please enter your word.");
            string toGuess = Console.ReadLine().ToLower();
            Console.Clear();
            bool guessed = false;
            while(p2.guesses <= 5)
            {
                Console.WriteLine($"{p2.Name} please guess a letter in the word: {ShowWord(toGuess, p2)}");
                string guess = Console.ReadLine();
                p2.guessed.Add(guess);
                if(ShowWord(toGuess, p2) == toGuess)
                {
                    guessed = true;
                    break;
                } else
                {
                    if (toGuess.Contains(guess))
                    {
                        Console.WriteLine("That is in the word!");
                    }
                    else
                    {
                        Console.WriteLine("That isn't in the word!");
                        p2.guesses++;
                    }
                }
            }
            if(guessed)
            {
                Console.WriteLine($"Well done {p2.Name}, you guessed it correctly!");
            } else {
                Console.WriteLine($"Unlucky {p2.Name}, the word was {toGuess}.");
            }
        }
        static string ShowWord(string word, Player p2)
        {
            string toReturn = "";
            foreach(string letter in word.ToCharArray().Select(i => i.ToString().ToLower()))
            {
                if(p2.guessed.Contains(letter))
                {
                    toReturn += letter;
                } else
                {
                    toReturn += "_";
                }
            }
            return toReturn;
        }
    }
}
