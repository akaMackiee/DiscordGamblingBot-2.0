using System.Collections.Generic;
using System;
using System.IO;

namespace DiscordGamblingBot
{
    class BlackJack
    {
        public void HandCards()
        {
            var deck = new GetDeck();
            List<Card> cards = new List<Card>();
            cards.Add(deck.DrawACard());
            foreach(Card onscreen in cards)
            {
                Console.WriteLine($"FACE: {onscreen.Face} | SUIT: {onscreen.Suit} | VALUE: {onscreen.Value}");
            }
        }
    }

    public enum Suit
    {
        Heart,
        Diamond,
        Spade,
        Club
    }

    public enum Face
    {
        Ace,
        Two,
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
        King,
    }

    public class Card
    {
        public Suit Suit { get; set; }
        public Face Face { get; set; }
        public int Value { get; set; }
    }

    class GetDeck
    {
        private List<Card> cards;
        public List<Card> Initialize()
        {
            cards = new List<Card>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    cards.Add(new Card() { Suit = (Suit)i, Face = (Face)j });

                    if (j <= 8)
                        cards[cards.Count - 1].Value = j + 1;
                    else 
                        cards[cards.Count - 1].Value = 10;
                }
            }
            return cards;
        }

        public void Shuffle()
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card card = cards[k];
                cards[k] = cards[n];
                cards[n] = card;
            }
        }

        public Card DrawACard()
        {
            if (cards.Count <= 0)
            {
                this.Initialize();
            }
            this.Shuffle();
            Card cardToReturn = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return cardToReturn;
        }
    }
}