using CardDeck.Domain.Enums;
using CardDeck.Domain.Entities;
using System.Collections.Generic;

namespace CardDeck.Application.Services
{
    public class DeckService : IDeckService
    {
        public IList<Card> Build()
        {
            return new List<Card>
            {
                new Card { Rank = "2", Suit = CardSuit.Clubs },
                new Card { Rank = "3", Suit = CardSuit.Clubs }
            };
        }
    }
}
