namespace CardDeck.Application.Iterator
{
    public interface IIterator<TItem> where TItem : class
    {
        bool HasNext();

        TItem Next();
    }
}
