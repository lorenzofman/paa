using System;
using System.Collections.Generic;
using System.Linq;

namespace Knapsack
{
    public class Knapsack
    {
        #region Class Members 

        private readonly List<Item> m_Items;

        private readonly Dictionary<(int, int), List<Item>> m_CachedResults = new Dictionary<(int, int), List<Item>>();
        private readonly bool m_UseCache;

        #endregion

        #region Constructor
        /// <summary>
        /// Everytime the items change the constructor shall be called, preventing previous cached incorrect entries
        /// </summary>
        /// <param name="items"></param>
        public Knapsack(List<Item> items, bool useCache = true)
        {
            this.m_Items = items;
            m_UseCache = useCache;
            if(useCache)
            {
                m_CachedResults = new Dictionary<(int, int), List<Item>>();
            }
        }

        #endregion

        #region Dynamic Programming
        /// <summary>
        /// Works for dynamic programming and not based whether useCache is true or false
        /// </summary>
        public List<Item> FindOptimalDynamic(int capacity, int n)
        {
            if(m_UseCache == false)
            {
                return FindOptimal(capacity, n);
            }
            /* Indexing is done using a tuple of capacity and n */
            /* The result won't change if the capacity, n and the data is the same */
            (int, int) keyTuple = (capacity, n);
            if (m_CachedResults.ContainsKey(keyTuple) == false)
            { 
                m_CachedResults.Add(keyTuple, FindOptimal(capacity, n));
            }
            return m_CachedResults[keyTuple];
        }

        #endregion

        #region Knapsack
        
        /// <summary>
        /// Find optimal sack with a given capacity
        /// </summary>
        public List<Item> FindOptimal(int capacity)
        {
            return FindOptimal(capacity, m_Items.Count);
        }

        private List<Item> FindOptimal(int capacity, int n)
        {
            /* Current analyzed element */
            int last = n - 1;

            /* Base case (reach start or capacity is zero)*/
            if (n == 0 || capacity == 0)
            {
                return new List<Item>();
            }

            /* If the current element is greater than the capacity which the function is trying it doesn't make sense to include it, so just return the collection without it */
            if (m_Items[last].weight > capacity)
            {
                return FindOptimalDynamic(capacity, last);
            }

            /* Find optimal sub solutions both including the current element and not including it */
            List<Item> includingCurrent = FindOptimalDynamic(capacity - m_Items[last].weight, last);
            List<Item> excludingCurrent = FindOptimalDynamic(capacity, last);

            /* If including the current element the value is greater than without including it, add it to the collection */
            if (includingCurrent.Sum(x => x.value) + m_Items[last].value > excludingCurrent.Sum(x => x.value))
            {
                /* Copy the list to avoid changing the cache */
                List<Item> copyList = new List<Item>(includingCurrent)
                {
                    m_Items[last]
                };
                return copyList;
            }

            /* Else return the collection without the current one (which has greater value) */
            return excludingCurrent;
        }

        #endregion

    }
}
