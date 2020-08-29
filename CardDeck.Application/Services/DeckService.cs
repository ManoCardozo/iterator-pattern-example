using System;
using System.Linq;
using CardDeck.Domain.Enums;
using CardDeck.Domain.Entities;
using System.Collections.Generic;

namespace CardDeck.Application.Services
{
    public class DeckService : IDeckService
    {
        public IEnumerable<Card> Build()
        {
            var suits = Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>();
            var ranks = Enum.GetValues(typeof(CardRank)).Cast<CardRank>();

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    yield return new Card(suit, rank);
                }
            }
        }
    }
}
