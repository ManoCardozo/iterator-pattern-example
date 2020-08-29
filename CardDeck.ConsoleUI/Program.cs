using System;
using CardDeck.Domain.Entities;
using CardDeck.Application.Iterator;
using CardDeck.Application.Services;

namespace CardDeck.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Deck of Cards";
            ServiceLocator.Setup();

            var deckService = ServiceLocator.Get<IDeckService>();
            var deck = deckService.Build();
            var iterator = new Iterator<Card>(deck);

            while(iterator.HasNext())
            {
                var card = iterator.Next();

                Display(card);
            }

            Console.ReadLine();
        }

        private static void Display(Card card)
        {
            Console.WriteLine(card.Rank);
            Console.WriteLine(card.Suit);
        }
    }
}
