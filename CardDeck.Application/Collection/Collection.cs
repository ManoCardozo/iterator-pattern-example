using System.Collections.Generic;
using CardDeck.Application.Iterator;

namespace CardDeck.Application.Collection
{
    public class Collection<TItem> : ICollection<TItem> where TItem : class
    {
        private readonly List<TItem> items = new List<TItem>();

        Iterator<TItem> ICollection<TItem>.CreateIterator()
        {
            return new Iterator<TItem>(this);
        }

        public int Count
        {
            get { return items.Count; }
        }

        public void Add(TItem item)
        {
            items.Add(item);
        }

        public TItem Get(int index)
        {
            return items[index];
        }
    }
}
