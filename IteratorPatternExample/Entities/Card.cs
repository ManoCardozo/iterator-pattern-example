using CardDeck.Domain.Enums;

namespace CardDeck.Domain.Entities
{
    public class Card
    {
        public string Rank { get; set; }

        public CardSuit Suit { get; set; }
    }
}
