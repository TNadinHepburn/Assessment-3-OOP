using System;
using System.Collections.Generic;
using System.Text;

namespace Lincoln_Card_Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Shuffle();
            Human h = new Human(GetHand(deck, 10));
            Computer c = new Computer(GetHand(deck, 10));
            Console.WriteLine(deck.Cards.Count);
            int scoreAdd = 1;
            Console.WriteLine(h.Hand);
            Console.WriteLine(c.Hand);

            while (!h.Hand.IsEmpty() && !c.Hand.IsEmpty())
            {
                for (int i = 0; i < c.Hand.Cards.Count/2; i++)
                {
                    if ((c.Hand.Cards[i*2]+c.Hand.Cards[i*2+1]) < (h.Hand.Cards[i*2] + h.Hand.Cards[i*2+1]))
                    {
                        Console.WriteLine($"human wins hand with {h.Hand.Cards[i*2]} and {h.Hand.Cards[i*2+1]}");
                        h.Score += scoreAdd;
                        scoreAdd = 1;
                    }
                    else if ((c.Hand.Cards[i*2] + c.Hand.Cards[i*2+1]) > (h.Hand.Cards[i*2] + h.Hand.Cards[i*2+1]))
                    {
                        Console.WriteLine($"computer wins hand with {c.Hand.Cards[i*2]} and {c.Hand.Cards[i*2+1]}");
                        c.Score+=scoreAdd;
                        scoreAdd = 1;
                    }
                    else
                    {
                        Console.WriteLine($"Hand is a draw - computer:{c.Hand.Cards[i * 2]} and {c.Hand.Cards[i * 2 + 1]} human:{h.Hand.Cards[i * 2]} and {h.Hand.Cards[i * 2 + 1]}");
                        scoreAdd++;
                    }
                }
                break;
            }
            Console.WriteLine($"Scores\nComputer: {c.Score}\nHuman: {h.Score}");
        }


        public static List<Card> GetHand(Deck deck, int handSize)
        {
            List<Card> result = new List<Card>();
            for (int i = 0; i < handSize; i++)
            {
                result.Add(deck.Deal());
            }
            return result;
        }




    }


}
