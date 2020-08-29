using CardDeck.Application.Collection;

namespace CardDeck.Application.Iterator
{
    public class Iterator<TItem> : IIterator<TItem> where TItem : class
    {
        private readonly Collection<TItem> collection;
        private int current = 0;

        public Iterator(Collection<TItem> collection)
        {
            this.collection = collection;
        }

        public TItem Next()
        {
            current++;

            var next = !IsCompleted
                ? collection.Get(current)
                : null;

            return next;
        }

        private bool IsCompleted
        {
            get { return current >= collection.Count; }
        }
    }
}
