using System;
using System.Collections.Generic;
using System.Text;

namespace Lincoln_Card_Game
{
    public class Card
    {
        public string Suit { get; }
        public int Value { get; }

        public Card(int value, string suit)
        {
            Suit = suit;
            Value = value;
        }
        public static int operator +(Card a, Card b)
        {
            return a.Value + b.Value;
        }

        public override string ToString()
        {
            //outputs the value and suit of a card e.g Six of Heart's
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
