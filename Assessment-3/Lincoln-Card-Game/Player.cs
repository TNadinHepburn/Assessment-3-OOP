using System;
using System.Collections.Generic;
using System.Text;

namespace Lincoln_Card_Game
{
    public abstract class Player
    {
        public Hand Hand { get; }
        public int Score { get; set; }
        public abstract int ID { get; protected set; }

        public Player(List<Card> cards)
        {
            Hand = new Hand(cards);
            Score = 0;
        }

        public abstract List<Card> PlayCards();
    }
}