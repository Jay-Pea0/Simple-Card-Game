using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssessment3
{
    class Program
    {

        static void Main(string[] args)
        {
            // Creates Deck and Hands
            Deck gameDeck = new Deck();
            PlayerHand handHuman = new PlayerHand();
            PlayerHand handComputer = new PlayerHand();

            // Creates variables counting the round number and the amount of points a round is worth
            int roundNumber = 0;
            int pointsAtPlay = 1;

            // Creates array for the two cards the user uses, and the cards drawn if it's a draw
            string[] chosenCards = new string[2];
            string[] singleCard = new string[2];

            // Adds cards to the new deck
            // Then shuffles the deck
            Console.WriteLine("Creating Deck");
            gameDeck.CreateDeck();
            Console.WriteLine("Deck Created");
            Console.WriteLine("\nShuffling Deck");
            gameDeck.Shuffle();
            Console.WriteLine("Deck Shuffled");


            // Deals the first 10 cards in the shuffled deck to the player, and the next ten to the computer
            handHuman.Cards = gameDeck.DealHand(0);
            handComputer.Cards = gameDeck.DealHand(10);


            // While no-one has won the game, and players still have cards
            while (handHuman.Score != 3 && handComputer.Score != 3 && roundNumber < 6)
            {
                // UI and user input
                Console.WriteLine("\n-=Round: " + roundNumber.ToString() + "=-\n-=CURRENT SCORE=-\nComputer: "+handComputer.Score.ToString()+ "\nPlayer: "+ handHuman.Score.ToString()+"\n\n-=YOUR HAND=-");
                handHuman.Deal();
                Console.WriteLine("\nIf you wish to EXIT, please input 'E'");
                Console.WriteLine("\nPlease input a number corresponding to a card");
                chosenCards[0] = Console.ReadLine();
                Console.WriteLine("Please input a second number corresponding to a card");
                chosenCards[1] = Console.ReadLine();
                // Error Handling
                try
                {
                    // Checks that the user has selected two different cards
                    // Gives error message if they haven't
                    if (chosenCards[0] == chosenCards[1])
                    {
                        Console.WriteLine("\nPLEASE SELECT TWO DIFFERENT CARDS\n");
                    }

                    // If User has picked two different cards then runs the program
                    else
                    {
                        // Shows cards the user has selected
                        Console.WriteLine("Selected Cards");
                        Console.WriteLine((handHuman.Cards[Int32.Parse(chosenCards[0]) - 1]).CardType);
                        Console.WriteLine((handHuman.Cards[Int32.Parse(chosenCards[1]) - 1]).CardType);

                        // Shows cards the computer plays
                        Console.WriteLine("\nComputer Plays");
                        Console.WriteLine((handComputer.Cards[0].CardType));
                        Console.WriteLine((handComputer.Cards[1].CardType));

                        // Calculates the score of the players that round
                        handHuman.CalculatePoints((handHuman.Cards[Int32.Parse(chosenCards[0]) - 1]), (handHuman.Cards[Int32.Parse(chosenCards[1]) - 1]));
                        handComputer.CalculatePoints((handComputer.Cards[0]), (handComputer.Cards[1]));

                        // UI stuff
                        Console.WriteLine("\nPlayer Score: " + handHuman.RoundPoints.ToString() + "\nComputer Score: " + handComputer.RoundPoints.ToString());

                        // Score conditions
                        // If human wins, human score increases
                        if (handHuman.RoundPoints > handComputer.RoundPoints)
                        {
                            handHuman.Score += pointsAtPlay;
                            pointsAtPlay = 1;
                            Console.WriteLine("YOU WIN THIS ROUND");
                        }
                        // If computer wins, computer score increases
                        // Coumputer also plays cards first for next round
                        else if (handHuman.RoundPoints < handComputer.RoundPoints)
                        {
                            handComputer.Score += pointsAtPlay;
                            pointsAtPlay = 1;
                            Console.WriteLine("COMPUTER WINS THIS ROUND");
                            Console.WriteLine("\n-=NEXT ROUND=-\n-=COMPUTER PLAYS: " + (handComputer.Cards[0]).CardType + " AND " + (handComputer.Cards[1]).CardType + "=-");
                        }
                        // Only other condition is draw, if draw, no score increases, points at play increases by 1
                        else
                        {
                            pointsAtPlay++;
                            Console.WriteLine("DRAW, NEXT ROUND WORTH " + pointsAtPlay.ToString() + " POINTS");
                        }

                        // Goes to next round
                        roundNumber++;
                    }
                }

                // If user doesn't input valid integers, it causes an error
                catch
                {
                    // If the user inputted 'e' or 'E', they're showing they want to exit the program
                    // This code runs, and the code is ended
                    if (chosenCards[0].ToUpper() == "E" || chosenCards[1].ToUpper() == "E")
                    {
                        Environment.Exit(1);
                    }

                    // Runs the catch error message
                    Console.WriteLine("\nPLEASE INPUT TWO VALID INTEGERS FROM CARDS GIVEN\n");
                }
            }


            // If neither player has more points, runs a while loop drawing cards until a player wins
            while (handHuman.Score == handComputer.Score)
            {
                // Deal cards to users
                singleCard[0] = gameDeck.DealCard(roundNumber + 14);
                singleCard[1] = gameDeck.DealCard(roundNumber + 15);

                //UI
                Console.WriteLine("\nYour Card: " + singleCard[0] + "\nComputer Card: " + singleCard[1]);


                // Checking which card is larger
                // If user card is larger, declares as such, and grants points
                if (PlayerHand.CardWorth(singleCard[0]) > PlayerHand.CardWorth(singleCard[1]))
                {
                    handHuman.Score += pointsAtPlay;
                    Console.WriteLine("YOU WIN THIS ROUND");

                }
                // If computer card is larger, declares as such, and grants points
                else if (PlayerHand.CardWorth(singleCard[0]) < PlayerHand.CardWorth(singleCard[1]))
                {
                    handHuman.Score += pointsAtPlay;
                    Console.WriteLine("COMPUTER WINS THIS ROUND");
                }
                // If no cards are larger, declares as such, next card worth more points
                // Only condition where it'll loop
                else
                {
                    pointsAtPlay++;
                    Console.WriteLine("DRAW, NEXT ROUND WORTH " + pointsAtPlay.ToString() + " POINTS");
                }

            }

            // When loop is over
            // If human has more points, human wins
            if (handHuman.Score > handComputer.Score)
            {
                Console.WriteLine("\n\nCOMPUTER SCORE: " + handComputer.Score.ToString() + "\nYOUR SCORE: " + handHuman.Score.ToString() + "\nYOU WIN!");
            }
            // If human hasn't won, computer has
            else
            {
                Console.WriteLine("\n\nCOMPUTER SCORE: " + handComputer.Score.ToString() + "\nYOUR SCORE: " + handHuman.Score.ToString() + "\nYOU LOSE!");
            }
        }
    }
}
