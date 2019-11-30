using System.Collections.Generic;
using System.Linq;

namespace Knapsack
{
    public class Knapsack
    {
        #region Class Members 

        private List<Item> m_Items;

        private Dictionary<(int, int), List<Item>> m_CachedResults = new Dictionary<(int, int), List<Item>>();

        #endregion

        #region Constructor

        public Knapsack(List<Item> items)
        {
            this.m_Items = items;
        }

        #endregion

        #region Dynamic Programming

        public List<Item> FindOptimalDynamic(int capacity, int n)
        {
            (int, int) keyTuple = (capacity, n);
            if (m_CachedResults.ContainsKey(keyTuple) == false)
            {
                m_CachedResults.Add(keyTuple, FindOptimal(capacity, n));
            }
            return m_CachedResults[keyTuple];
        }

        #endregion

        #region Knapsack
        
        public List<Item> FindOptimal(int capacity)
        {
            return FindOptimal(capacity, m_Items.Count);
        }

        private List<Item> FindOptimal(int capacity, int n)
        {
            int last = n - 1;
            if (n == 0 || capacity == 0)
            {
                return new List<Item>();
            }

            if (m_Items[last].weight > capacity)
            {
                return FindOptimalDynamic(capacity, last);
            }

            List<Item> includingCurrent = FindOptimalDynamic(capacity - m_Items[last].weight, last);
            List<Item> excludingCurrent = FindOptimalDynamic(capacity, last);

            if (includingCurrent.Sum(x => x.value) + m_Items[last].value > excludingCurrent.Sum(x => x.value))
            {
                includingCurrent.Add(m_Items[last]);
                return includingCurrent;
            }

            return excludingCurrent;
        }

        #endregion

    }
}
