using System;
using System.Collections.Generic;
using System.Text;

namespace Lincoln_Card_Game
{
    class Card
    {
        public string Suit { get; }
        public int Value { get; }

        public Card(int value, string suit)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            //outputs the value and suit of a card e.g Value: 6 Suit: Heart
            return $"{ValueToStr(Value)} ({Value}) of {Suit}'s";
        }

        private string ValueToStr(int value)
        {
            string[] strValues =
            {
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven",
                "Eight",
                "Nine",
                "Ten",
                "Jack",
                "Queen",
                "King",
                "Ace"
            };
            return strValues[value - 2];
        }
    }
}
