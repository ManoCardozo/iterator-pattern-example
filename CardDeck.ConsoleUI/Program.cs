using System;
using System.Linq;
using System.Threading.Tasks;
using CardDeck.Domain.Entities;
using CardDeck.Application.Iterator;
using CardDeck.Application.Services;
using CardDeck.Application.Extensions;

namespace CardDeck.ConsoleUI
{
    class Program
    {
        private static readonly IDeckService deckService = ServiceLocator.Get<IDeckService>();

        static async Task Main(string[] args)
        {
            Console.Title = "Deck of Cards";
            ServiceLocator.Setup();

            var deck = deckService
                .Build()
                .ToList();

            deck.Shuffle();

            var iterator = new Iterator<Card>(deck);

            var displayAll = false;
            while(iterator.HasNext() || displayAll)
            {
                var card = iterator.Next();

                Console.Clear();
                CardView.Render(card);
                
                if (displayAll)
                {
                    RenderDisplayAllInfo();
                    await Task.Delay(2000);
                }
                else
                {
                    RenderOptions();
                    var input = Console.ReadKey();
                    displayAll = input.KeyChar == 'a';
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void RenderDisplayAllInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Displaying next card every 2 seconds...");
        }

        private static void RenderOptions()
        {
            Console.WriteLine();
            Console.WriteLine("- [N]ext");
            Console.WriteLine("- Display [A]ll");
        }
    }
}
