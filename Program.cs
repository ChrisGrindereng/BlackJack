

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack


{
    class Program
    {
        static void Main(string[] args)
        {
            dealNewHand();
            

            //Dispaying first dealer and player cards for debug purposes

            //Console.WriteLine("-------------------------------------------------");
            //Console.WriteLine("Your Hand:");
            //Console.Write(me.Hand[0].rank.ToString());
            //Console.WriteLine(me.Hand[0].suit.ToString());
            //Console.Write(me.Hand[1].rank.ToString());
            //Console.WriteLine(me.Hand[1].suit.ToString());
            //Console.WriteLine("Score = {0}", me.getScore());

            //Console.WriteLine("-------------------------------------------------");
            //Console.WriteLine("Dealer Hand:");
            //Console.Write(dealer.dealerHand[0].rank.ToString());
            //Console.WriteLine(dealer.dealerHand[0].suit.ToString());
            //Console.Write(dealer.dealerHand[1].rank.ToString());
            //Console.WriteLine(dealer.dealerHand[1].suit.ToString());

            //Console.WriteLine("-------------------------------------------------");


            //int c = 2;
            //int v = 2;
            //while (userPrompt() == "y")
            //{
            //    me.getHand(newdeck.Deal(turns), c);
            //    c++;
            //    turns++;
            //    displayHand(me);
            //    displayScore(me);
            //    checkBust(me, dealer);
            //}


            //while (dealer.getDealerScore() < 17)
            //{
            //    dealer.getDealerHand(newdeck.Deal(turns), v);
            //    v++;
            //    turns++;
            //    displayDealerHand(dealer);
            //    displayDealerScore(dealer);
            //    checkBust(me, dealer);

            //}

            //for (int i = 0; i < newdeck.cards.Length; i++)   //displaying the whole deck for debug purposes
            //{
            //    Console.Write(newdeck.cards[i].rank.ToString());
            //    Console.WriteLine(newdeck.cards[i].suit.ToString());
            //}

            Console.ReadLine();
        }
        public static string userPrompt()
        {
            Console.WriteLine("Hit(y) or Stay(n)");
            string userChoice = Console.ReadLine();
            return userChoice;
        }
        public static void displayHand(Player player)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Your Hand:");

            for (int i = 0; i < player.Hand.Length; i++)
            {
                if (player.Hand[i] != null)
                {
                    Console.Write(player.Hand[i].rank.ToString());
                    Console.WriteLine(player.Hand[i].suit.ToString());
                }
                else
                {
                    Console.Write("---");
                }
            }
        }
        public static void displayScore(Player player)
        {
            Console.WriteLine("Score = {0}", player.getScore());

        }
        public static void displayDealerHand(Dealer dealer)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Dealer Hand:");
           
            for (int i = 0; i < dealer.dealerHand.Length; i++)
            {
                if (dealer.dealerHand[i] != null )
                {
                    Console.Write(dealer.dealerHand[i].rank.ToString());
                    Console.WriteLine(dealer.dealerHand[i].suit.ToString());
                }
                else
                {
                    Console.Write("---");
                }
            }
        }
        public static void displayDealerScore(Dealer dealer)
        {
            Console.WriteLine("Dealer Score = {0}", dealer.getDealerScore());
        }
        public static void checkBust(Player player, Dealer dealer)
        {
            if (player.getScore() > 21)
            {
                displayDealerHand(dealer);
                displayDealerScore(dealer);
                Console.WriteLine("*****  Player Busts.... You Lose!  ******");
                playAgain();
            }
            else if (dealer.getDealerScore() > 21)
            {
                displayDealerHand(dealer);
                displayDealerScore(dealer);
                Console.WriteLine("!!!!!!!!!  Dealer Busts! You WIN :)  !!!!!!!!!!!");
                playAgain();
            }

        }
        
      public static void BlackJack(Player player, Dealer dealer)
        {   
            if (player.getScore() == 21)
            {
                displayDealerHand(dealer);
                displayDealerScore(dealer);
                displayHand(player);
                displayScore(player);
                Console.WriteLine("$$$$$$$$$$$$$$  BlackJack!! You WIN!!!  $$$$$$$$$$$$$$");
                playAgain();
            }
        }
      public static void win(Player player, Dealer dealer)
       {
            if (player.getScore() == 21 && dealer.getDealerScore() == 21)
            {
                displayDealerHand(dealer);
                displayDealerScore(dealer);
                displayHand(player);
                displayScore(player);
                Console.WriteLine("_______The BlackJack for everyone!! It's a Push_______");
                playAgain();

            }
            else if (player.getScore() == 21)
            {
                displayDealerHand(dealer);
                displayDealerScore(dealer);
                displayHand(player);
                displayScore(player);
                Console.WriteLine("$$$$$$$$$$$$$$  BlackJack!! You WIN!!!  $$$$$$$$$$$$$$");
                playAgain();
            }
             else if (dealer.getDealerScore() == 21)
            {
                displayDealerHand(dealer);
                displayDealerScore(dealer);
                displayHand(player);
                displayScore(player);
                Console.WriteLine("????????????  BlackJack for the Dealer..... Dealer Wins :(  ????????????");
                playAgain();

            }
            else if (player.getScore() < 21 && player.getScore() > dealer.getDealerScore())
            {
                displayDealerHand(dealer);
                displayDealerScore(dealer);
                displayHand(player);
                displayScore(player);
                Console.WriteLine("################   You WIN!!!!!   ##############");
                playAgain();
            }
            else if (dealer.getDealerScore() < 21 && player.getScore() < dealer.getDealerScore())
            {
                displayDealerHand(dealer);
                displayDealerScore(dealer);
                displayHand(player);
                displayScore(player);
                Console.WriteLine("<<<<<<<<  What?? Dealer Wins   >>>>>>>>>");
                playAgain();
            }
        }

      public static void playAgain()
        {
            Console.WriteLine("Play Again? yes(y) or no(n)");
            if (Console.ReadLine() == "y")
            {
                dealNewHand();
            }
            else
            {
                Environment.Exit(0);
            }
        }

      public static void dealNewHand()
        {
            Deck newdeck = new BlackJack.Deck();
            Player me = new BlackJack.Player();
            Dealer dealer = new BlackJack.Dealer();

            newdeck.getrandomized();
            int turns = 0;
            Console.WriteLine("Lets play Black Jack");


            for (int i = 0; i < 2; i++)
            {

                me.getHand(newdeck.Deal(turns), i);
                turns++;

                dealer.getDealerHand(newdeck.Deal(turns), i);
                turns++;

            }

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Dealer Hand:");
            Console.Write(dealer.dealerHand[0].rank.ToString());
            Console.WriteLine(dealer.dealerHand[0].suit.ToString());
            Console.WriteLine("?????????");

            displayHand(me);
            displayScore(me);
            BlackJack(me, dealer);

            int c = 2;
            int v = 2;
            while (userPrompt() == "y")
            {
                me.getHand(newdeck.Deal(turns), c);
                c++;
                turns++;
                displayHand(me);
                displayScore(me);
                checkBust(me, dealer);

            }


            while (dealer.getDealerScore() < 17)
            {
                dealer.getDealerHand(newdeck.Deal(turns), v);
                v++;
                turns++;
                displayDealerHand(dealer);
                displayDealerScore(dealer);
                checkBust(me, dealer);
            }

            win(me, dealer);

        }
    }
}
