using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCards;

namespace ProgrammingAssignment2
{
    // IMPORTANT: Only add code in the section
    // indicated below. The code I've provided
    // makes your solution work with the 
    // automated grader on Coursera

    /// <summary>
    /// Programming Assignment 2
    /// </summary>
    class Program
    {
        /// <summary>
        /// Implements Nothing Like Blackjack functionality
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // loop while there's more input
            string input = Console.ReadLine();
            while (input[0] != 'q')
            {

                // Add your code between this comment
                // and the comment below. You can of
                // course add more space between the
                // comments as needed

                // declare a deck variables and create a deck object
                // DON'T SHUFFLE THE DECK
                Deck deck = new Deck();
                // deal 2 cards each to 4 players (deal properly, dealing
                // the first card to each player before dealing the
                // second card to each player)
                Card p1c1 = deck.TakeTopCard();
                Card p2c1 = deck.TakeTopCard();
                Card p3c1 = deck.TakeTopCard();
                Card p4c1 = deck.TakeTopCard();
                Card p1c2 = deck.TakeTopCard();
                Card p2c2 = deck.TakeTopCard();
                Card p3c2 = deck.TakeTopCard();
                Card p4c2 = deck.TakeTopCard();
                // deal 1 more card to players 2 and 3
                Card p2c3 = deck.TakeTopCard();
                Card p3c3 = deck.TakeTopCard();
                // flip all the cards over
                p1c1.FlipOver();
                p2c1.FlipOver();
                p3c1.FlipOver();
                p4c1.FlipOver();
                p1c2.FlipOver();
                p2c2.FlipOver();
                p3c2.FlipOver();
                p4c2.FlipOver();
                p2c3.FlipOver();
                p3c3.FlipOver();
                // print the cards for player 1
                Console.WriteLine(p1c1.Rank+","+p1c1.Suit);
                Console.WriteLine(p1c2.Rank + "," + p1c2.Suit);
                // print the cards for player 2
                Console.WriteLine(p2c1.Rank + "," + p2c1.Suit);
                Console.WriteLine(p2c3.Rank + "," + p2c2.Suit);
                Console.WriteLine(p2c3.Rank + "," + p2c3.Suit);
                // print the cards for player 3
                Console.WriteLine(p3c1.Rank + "," + p3c1.Suit);
                Console.WriteLine(p3c3.Rank + "," + p3c2.Suit);
                Console.WriteLine(p3c3.Rank + "," + p3c3.Suit);
                // print the cards for player 4
                Console.WriteLine(p4c1.Rank + "," + p4c1.Suit);
                Console.WriteLine(p4c2.Rank + "," + p4c2.Suit);
                // Don't add or modify any code below
                // this comment
                input = Console.ReadLine();
            }
        }
    }
}
