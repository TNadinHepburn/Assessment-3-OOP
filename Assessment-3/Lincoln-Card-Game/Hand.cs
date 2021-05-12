using System;
using System.Collections.Generic;
using System.Text;

namespace Lincoln_Card_Game
{
    public class Hand : Deck
    {
        public Hand(List<Card> cards)
        {
            Cards = cards;
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i<Cards.Count;i++)
            {
                result += $"{i+1}. {Cards[i]}\n";
            }
            return result;
        }

    }
}


