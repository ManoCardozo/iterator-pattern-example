using CardDeck.Application.Iterator;

namespace CardDeck.Application.Collection
{
    public interface ICollection<TItem> where TItem : class
    {
        Iterator<TItem> CreateIterator();
    }
}
