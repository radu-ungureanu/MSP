using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MSP.Common
{
    static class Extensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int i = random.Next(n + 1);
                T temp = list[i];
                list[i] = list[n];
                list[n] = temp;
            }
        }

        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> itemsToAdd)
        {
            foreach (var item in itemsToAdd)
            {
                collection.Add(item);
            }
        }
    }
}
