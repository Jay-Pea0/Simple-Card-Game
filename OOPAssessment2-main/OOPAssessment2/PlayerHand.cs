using System;
using System.Collections.Generic;
using System.Text;

namespace OOPAssessment3
{
    public class PlayerHand
    {
        public List<Card> Cards = new List<Card>();
        public int Score = 0;
        public int RoundPoints = 0;

        // Outputs the cards in the list
        // Displays with [X] in front of it, to help with user input
        public void Deal()
        {
            int i = 1;

            foreach (Card card in this.Cards)
            {
                Console.WriteLine("["+i.ToString()+"] "+ card.CardType);
                i++;
            }
        }

        // Calculates the value of the selected hand
        public void CalculatePoints(Card Card1, Card Card2)
        {
            // Score equals the value of the two cards added together
            RoundPoints = CardWorth(Card1.CardType) + CardWorth(Card2.CardType);

            // Removes played cards from hand
            Cards.Remove(Card1);
            Cards.Remove(Card2);
        }


        // Determines how many points a single card is worth
        // Static/Global because used in PlayerHand.cs and Program.cs
        public static int CardWorth(string givenCard)
        {
            int cardValue = 0;
            string cardSize = givenCard.Split(' ')[0];

            try
            {
                // Converts integer part of the card to an integer value
                cardValue = Int32.Parse(cardSize);
            }
            // Causes error when card is a picture card, so runs the catch
            catch
            {
                // Checks if givenCard is a king and sets value to 13
                if (cardSize == "King")
                {
                    cardValue = 13;
                }
                // Checks if givenCard is a queen and sets value to 12
                else if (cardSize == "Queen")
                {
                    cardValue = 12;
                }
                // Checks if givenCard is a jack and sets value to 11
                else if (cardSize == "Jack")
                {
                    cardValue = 11;
                }
                // If not a number, jack, queen, or king, must be an ace
                // Sets value to 14
                else
                {
                    cardValue = 14;
                }
            }
            return cardValue;
        }

    }
}
