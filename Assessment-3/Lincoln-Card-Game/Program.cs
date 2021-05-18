using System;
using System.Collections.Generic;
using System.Text;

namespace Lincoln_Card_Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int choice = 0;
            while (!(choice == 2))
            {
                choice = 0;
                Console.WriteLine($"Lincoln Card Game");
                while(choice!=1 && choice != 2)
                {
                    Console.Write("1. Play\n2. Quit\n->");
                    choice = CheckInt(Console.ReadLine());
                    if (choice!=1 && choice != 2)
                    {
                        Console.WriteLine("Please enter 1 to play or 2 to quit");
                    }
                }
                switch (choice)
                {
                    case 1:Game();break;
                    case 2:Quit();break;
                }
            }

        }

        public static int CheckInt(string input)
        {
                try
                {
                return int.Parse(input);
                }
                catch
                {
                Console.WriteLine("Please enter a number");
                return -1;
                }

            
        }

        public static void Game()
        {
            int turnScore = 1;
            Deck deck = new Deck();
            deck.Shuffle();
            Human h = new Human(deck.DealHand());
            Computer c = new Computer(deck.DealHand());
            while(!h.Hand.IsEmpty() && !c.Hand.IsEmpty())
            {
                turnScore = PlayHand(h,c,turnScore);
            }
            while (h.Score == c.Score || turnScore>1)
            {
                if (!deck.IsEmpty())
                {
                h.Hand.Cards.Add(deck.Deal());
                c.Hand.Cards.Add(deck.Deal());
                turnScore = Draw(h, c);
                }
                else
                {
                    Console.WriteLine("No more cards in deck!");
                }
            }
            Results(h,c);
        }

        public static int PlayHand(Human human, Computer computer,int addScore)
        {
            List<Card> computerCards = computer.PlayCards();
            Console.WriteLine("-Your Cards-");
            List<Card> humanCards = human.PlayCards();
            int humanTotal = humanCards[0] + humanCards[1];
            int computerTotal = computerCards[0] + computerCards[1];
            Console.WriteLine($"Human Played: {humanCards[0]} and {humanCards[1]}\nComputer played: {computerCards[0]} and {computerCards[1]}");

            if (humanTotal > computerTotal)
            {
                Console.WriteLine("The Human won the hand");
                human.Score+=addScore;
            }
            else if(computerTotal> humanTotal)
            {
                Console.WriteLine("The Computer won the hand");
                computer.Score+=addScore;
            }
            else
            {
                Console.WriteLine("Hand is a draw");
                return ++addScore;
            }
            return 1;

        }

        public static int Draw(Human human, Computer computer)
        {
            Card humanCard = human.Hand.Cards[0];
            Card computerCard = computer.Hand.Cards[0];
            int humanTotal = humanCard.Value;
            int computerTotal = computerCard.Value;
            Console.WriteLine($"Human Played: {humanCard}\nComputer played: {computerCard}");
            if (humanTotal > computerTotal)
            {
                Console.WriteLine("The Human won the hand");
                human.Score ++;
            }
            else if (computerTotal > humanTotal)
            {
                Console.WriteLine("The Computer won the hand");
                computer.Score ++;
            }
            else
            {
                Console.WriteLine("Hand is a draw");
                return 2;
            }
            return 1;
        }
        public static void Results(Human h, Computer c)
        {
            string winner;
            if (h.Score > c.Score)
            {
                winner = "Human";
            }
            else
            {
                winner = "Computer";
            }
            Console.WriteLine($"Results\nHuman scored: {h.Score}\nComputer scored: {c.Score}\nCongratulations to {winner}!");
        }

        public static void Quit()
        {
            Console.WriteLine("Thanks for playing");
        }
    }


}
