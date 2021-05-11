using System;
using System.Collections.Generic;
using System.Text;

namespace Lincoln_Card_Game
{
    class Deck
    {
        public List<Card> Pile { get; set; }

        public Deck()
        {

            List<string> suits = new List<string> { "Spade", "Heart", "Club", "Diamond" };
            Pile = new List<Card>();
            //creates cards from 1-13 in each suit
            foreach (string suit in suits)
            {
                for (int i = 2; i <= 14; i++)
                {
                    Pile.Add(new Card(i, suit));
                }
            }
        }

        public bool IsEmpty()
        {
            //true if deck is empty
            return Pile.Count == 0;
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            //shuffle each index of the list
            for (int i = 0; i < Pile.Count - 1; i++)
            {
                //rnd index to swap with
                int index1 = rnd.Next(Pile.Count);
                //swap
                Card temp = Pile[i];
                Pile[i] = Pile[index1];
                Pile[index1] = temp;
            }
        }

        public Card Deal()
        {
            //copy of card at first index before removing
            Card dealtCard = Pile[0];
            Pile.RemoveAt(0);
            return dealtCard;
        }
    }
}
