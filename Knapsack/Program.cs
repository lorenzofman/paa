using System;
using System.Collections.Generic;
using System.Linq;

namespace Knapsack
{
    class Program
    {
        static void Main()
        {
            List<Item> items = new List<Item>()
            {
                new Item(index: 0, weight: 10, value: 90),
                new Item(index: 1, weight: 20, value: 100),
                new Item(index: 2, weight: 30, value: 120)
            };

            Knapsack knapsack = new Knapsack(items);
            List<Item> optimalSack = knapsack.FindOptimal(capacity: 50);

            optimalSack.ForEach(item => Console.WriteLine(item));
            Console.WriteLine($"Total weight: {optimalSack.Sum(x => x.weight)}");
            Console.WriteLine($"Total value: {optimalSack.Sum(x => x.value)}");
        }
    }
}
