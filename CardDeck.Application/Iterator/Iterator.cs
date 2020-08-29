using System.Collections.Generic;

namespace CardDeck.Application.Iterator
{
    public class Iterator<TItem> : IIterator<TItem> where TItem : class
    {
        private readonly IList<TItem> collection;
        private int current = 0;

        public Iterator(IList<TItem> collection)
        {
            this.collection = collection;
        }

        public TItem Next()
        {
            var next = HasNext()
                ? collection[current]
                : null;

            current++;

            return next;
        }

        public bool HasNext()
        {
            return current < collection.Count;
        }
    }
}
