using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BlackJack
{
    public enum Suit
    {
        Hearts,
        Clubs,
        Diamonds,
        Spades
    }

    public enum Rank
    {
        
        Ace,
        Deuce,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public class Card
    {
        public Suit suit;
        public Rank rank;

        public Card(Suit s, Rank r)
        {
            suit = s;
            rank = r;
        }
        public static int cardValue(Rank r)
        {
            if (r == Rank.Deuce)
            { return 2; }
            else if (r == Rank.Three)
            { return 3; }
            else if (r == Rank.Four)
            { return 4; }
            else if (r == Rank.Five)
            { return 5; }
            else if (r == Rank.Six)
            { return 6; }
            else if (r == Rank.Seven)
            { return 7; }
            else if (r == Rank.Eight)
            { return 8; }
            else if (r == Rank.Nine)
            { return 9; }
            else if (r == Rank.Ten)
            { return 10; }
            else if (r == Rank.Jack)
            { return 10; }
            else if (r == Rank.Queen)
            { return 10; }
            else if (r == Rank.King)
            { return 10; }
            else if (r == Rank.Ace)
            { return 11; }
            else { return 0; }
        }

        public static int tallyPoints(Card[] newHand)
        {
            int[] cardValues = new int[8];
            int score = 0;

            for (int i = 0; i < newHand.Length; i++)
            {

                if (newHand[i] != null)
                {
                    cardValues[i] = cardValue(newHand[i].rank); 
                    score = cardValues[i] + score;
                }
                else
                {
                    i = newHand.Length;
                }

            }
            return score;
        }

}



    public class Deck
    {
        public Card[] cards;
        public Deck()
        {
            cards = new Card[52];
            int i = 0; // 1
            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                int j = 0;
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    cards[i * 4 + j] = new Card(s, r);
                    j++;
                }
                i++;
            }


        }
        public Card[] getrandomized()
        {
            Random r = new Random();

            Card firstCard;

            for (int i = 0; i < cards.Length; i++)
            {
                int randomNumber = r.Next(i, cards.Length);
                firstCard = cards[i];
                cards[i] = cards[randomNumber];
                cards[randomNumber] = firstCard;
            }
            return cards;

        }
        public Card Deal(int counter)
        {
            return cards[counter];
        }


    }

    public class Player
    {

        public Card[] Hand = new Card[8];

        public Card[] getHand(Card delt, int counter)
        {

            Hand[counter] = delt;
            return Hand;
        }
        public int getScore()
        {
            return Card.tallyPoints(Hand);
        
        }

    }

    public class Dealer
    { 
        public Card[] dealerHand = new Card[8];
    
        public Card[] getDealerHand(Card delt, int counter)
        {
            dealerHand[counter] = delt;
            return dealerHand;
        }
        public int getDealerScore()
        {
            return Card.tallyPoints(dealerHand);
        }
     }

}

   
