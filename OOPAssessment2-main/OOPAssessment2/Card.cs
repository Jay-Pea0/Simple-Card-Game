using System;
using System.Collections.Generic;
using System.Text;

namespace OOPAssessment3
{
    // CARD CLASS
    public class Card
    {
        // Creates enum for suits
        // 0 = hearts
        // 1 = diamonds
        // etc
        public enum Suites
        {
            Hearts = 0,
            Diamonds,
            Clubs,
            Spades
        }

        // Gets the value of the current card
        public int Value
        {
            get;
            set;
        }

        // Gets the suit of the current card
        public Suites Suite
        {
            get;
            set;
        }

        public string SuitValue
        {
            get
            {
                // Card number is an integer
                // Numbers 2-10 get converted into string
                // Numbers 11-4 don't exist on cards, so get converted to the equvilent
                // 11 = jack
                // 12 = queens
                // etc
                string CardType = string.Empty;
                switch (Value)
                {
                    case (14):
                        CardType = "Ace";
                        break;
                    case (13):
                        CardType = "King";
                        break;
                    case (12):
                        CardType = "Queen";
                        break;
                    case (11):
                        CardType = "Jack";
                        break;
                    default:
                        CardType = Value.ToString();
                        break;
                }

                return CardType;
            }
        }

        // Creates the Card
        public string CardType
        {
            get
            {
                return SuitValue + " of " + Suite.ToString();
            }
        }

        public Card(int Value, Suites Suite)
        {
            this.Value = Value;
            this.Suite = Suite;
        }

        
    }
}
