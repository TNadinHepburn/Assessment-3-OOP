using System;
using System.Collections.Generic;
using System.Text;

namespace Lincoln_Card_Game
{
    public class Computer : Player //inherits from player class
    {
        public override int ID { get; protected set; }

        public Computer(List<Card> cards) : base(cards)
        {
            ID = 1;
        }

        public List<Card> PlayCards()
        {
            List<Card> currentHand = new List<Card>();
            for (int i = 0; i < 2; i++)
            {
                if (!Hand.IsEmpty())
                {
                    currentHand.Add(Hand.Deal());
                }
                else
                {
                    return null;
                }
            }
            return currentHand;
        }

    }
}
