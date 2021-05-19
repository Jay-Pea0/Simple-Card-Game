using System;
using System.Collections.Generic;
using System.Text;

namespace OOPAssessment3
{
    public class Deck
    {
        public List<Card> Cards = new List<Card>();

        // Creates the deck of cards
        // Goes through every heart, 2 to ace
        // Then every diamond, 2 to ace
        // etc
        // Same order as enums (0 = hearts, 1 = diamond, etc)
        public void CreateDeck()
        {
            for (int i = 0; i < 52; i++)
            {
                Card.Suites suite = (Card.Suites)(Math.Floor((decimal)i / 13));
                int val = i % 13 + 2;
                Cards.Add(new Card(val, suite));
            }
        }

        // Deals the entire deck in the current order
        public void Deal()
        {
            foreach (Card card in this.Cards)
            {
                Console.WriteLine(card.CardType);
            }
        }

        // Deals a single card, starting at the given place in deck, and working down
        public string DealCard(int PlaceInDeck)
        {
            string[] ArrayOfDeck = new string[52];
            int i = 0;
            foreach (Card card in this.Cards)
            {
                ArrayOfDeck[i] = card.CardType;
                i++;
            }
            return ArrayOfDeck[PlaceInDeck];
        }

        // Deals Hand to a player
        public List<Card> DealHand(int PlaceInDeck)
        {
            List<Card> TenCards = this.Cards.GetRange(PlaceInDeck, 10);
            return TenCards;
        }

        // Shuffles the deck of cards
        public void Shuffle()
        {
            Random rand = new Random();
            Card temp;
            for (int TimesShuffled = 0; TimesShuffled < 100; TimesShuffled++)
            {
                for (int i = 0; i < 52; i++)
                {
                    int ShuffledCard = rand.Next(13);
                    temp = Cards[i];
                    Cards[i] = Cards[ShuffledCard];
                    Cards[ShuffledCard] = temp;
                }
            }
        }

        // Checks if the deck of cards is empty
        public bool IsEmpty(int cardsDealt)
        {
            if (cardsDealt >= 52)
            {
                return true;
            }
            return false;
        }
    }
}
