using System;
using System.Collections.Generic;
using System.Text;

namespace Lincoln_Card_Game
{
    public class Deck
    {
        public List<Card> Cards { get; protected set; }

        public Deck()
        {
            List<string> suits = new List<string> { "Spade", "Heart", "Club", "Diamond" };
            Cards = new List<Card>();
            //creates cards with values 2-14 in each suit
            foreach (string suit in suits)
            {
                for (int i = 2; i <= 14; i++)
                {
                    Cards.Add(new Card(i, suit));
                }
            }
        }

        public bool IsEmpty()
        {
            //true if deck is empty
            return Cards.Count == 0;
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            //shuffle each index of the list
            for (int i = 0; i < Cards.Count; i++)
            {
                //rnd index to swap with
                int index1 = rnd.Next(Cards.Count);
                //swap
                Card temp = Cards[i];
                Cards[i] = Cards[index1];
                Cards[index1] = temp;
            }
        }

        public Card Deal()
        {
            //copy of card at first index before removing
            Card dealtCard = Cards[0];
            Cards.RemoveAt(0);
            return dealtCard;
        }
        public List<Card> DealHand()
        {
            List<Card> dealtCards = new List<Card>();
            for(int i = 0; i < 10; i++)
            {
                //copy of card at first index before removing
                dealtCards.Add(Deal());
            }
            return dealtCards;
        }

        public List<Card> GetCards(int size)
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < size; i++)
            {
                cards.Add(Deal());
            }
            return cards;
        }
    }
}