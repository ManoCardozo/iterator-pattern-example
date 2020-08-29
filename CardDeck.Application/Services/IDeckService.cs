using CardDeck.Domain.Entities;
using System.Collections.Generic;

namespace CardDeck.Application.Services
{
    public interface IDeckService
    {
        IEnumerable<Card> Build();
    }
}