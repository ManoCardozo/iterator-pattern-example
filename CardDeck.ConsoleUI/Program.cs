using System;
using CardDeck.Domain.Entities;
using CardDeck.Application.Iterator;
using CardDeck.Application.Services;
using CardDeck.Application.Extensions;

namespace CardDeck.ConsoleUI
{
    class Program
    {
        private static readonly IDeckService deckService = ServiceLocator.Get<IDeckService>();

        static void Main(string[] args)
        {
            Console.Title = "Deck of Cards";
            ServiceLocator.Setup();

            var deck = deckService.Build();
            deck.Shuffle();

            var iterator = new Iterator<Card>(deck);

            var displayAll = false;
            while(iterator.HasNext() || displayAll)
            {
                var card = iterator.Next();

                Console.Clear();
                CardView.Render(card);
                RenderOptions();
                
                var input = Console.ReadKey();
                displayAll = input.KeyChar == 'a';
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void RenderOptions()
        {
            Console.WriteLine();
            Console.WriteLine("- [N]ext");
            Console.WriteLine("- Display [A]ll");
        }
    }
}
