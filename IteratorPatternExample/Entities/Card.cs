using CardDeck.Domain.Enums;

namespace CardDeck.Domain.Entities
{
    public class Card
    {
        public Card(CardSuit suit, CardRank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public CardRank Rank { get; set; }

        public CardSuit Suit { get; set; }
    }
}
