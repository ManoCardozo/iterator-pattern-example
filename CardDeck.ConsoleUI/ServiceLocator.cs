using CardDeck.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CardDeck.ConsoleUI
{
    public static class ServiceLocator
    {
        public static ServiceProvider Services { get; set; }

        public static void Setup()
        {
            Services = new ServiceCollection()
                .AddTransient<IDeckService, DeckService>()
                .BuildServiceProvider();
        }

        public static TService Get<TService>()
        {
            return Services.GetService<TService>();
        }
    }
}
