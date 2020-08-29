using System;
using System.Linq;
using System.Collections.Generic;

namespace CardDeck.Application.Extensions
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> self)
        {
            var random = new Random();
            int count = self.Count();

            while (count > 1)
            {
                count--;
                int index = random.Next(count + 1);
                T value = self[index];
                self[index] = self[count];
                self[count] = value;
            }
        }
    }
}
