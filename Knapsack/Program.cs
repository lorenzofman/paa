using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Knapsack
{
    class Program
    {
        static void Main()
        {
            Stopwatch withCacheStopwatch = new Stopwatch(), withoutCacheStopwatch = new Stopwatch();
            // Create items
            List<Item> items = new List<Item>()
            {
                new Item(index: 0, weight: 10, value: 90),
                new Item(index: 1, weight: 20, value: 100),
                new Item(index: 2, weight: 30, value: 120),
                new Item(index: 3, weight: 15, value: 30),
                new Item(index: 4, weight: 10, value: 40),
                new Item(index: 5, weight: 5, value: 85),
                new Item(index: 6, weight: 1, value: 75),
                new Item(index: 7, weight: 100, value: 80),
                new Item(index: 8, weight: 50, value: 90),
                new Item(index: 9, weight: 100, value: 35),
                new Item(index: 10, weight: 120, value: 140),
                new Item(index: 11, weight: 25, value: 200),
                new Item(index: 12, weight: 30, value: 300),
                new Item(index: 13, weight: 20, value: 42),
                new Item(index: 14, weight: 20, value: 42),
                new Item(index: 15, weight: 30, value: 44),
                new Item(index: 16, weight: 10, value: 12),

            };

            // Create Knapsack instance
            Knapsack knapsack = new Knapsack(items, false);
            Knapsack knapsackCache = new Knapsack(items, true);


            // Find the most valuable possible sack
            withoutCacheStopwatch.Start();
            List<Item> optimalSack = knapsack.FindOptimal(capacity: 10000);
            withoutCacheStopwatch.Stop();

            withCacheStopwatch.Start();
            List<Item> optimalSackCache = knapsackCache.FindOptimal(capacity: 10000);
            withCacheStopwatch.Stop();

            Console.WriteLine($"\n({withoutCacheStopwatch.ElapsedMilliseconds} ms)Result without cache:");

            // Print items, total weight and total value
            optimalSack.ForEach(item => Console.WriteLine(item));
            Console.WriteLine($"Total weight: {optimalSack.Sum(x => x.weight)}");
            Console.WriteLine($"Total value: {optimalSack.Sum(x => x.value)}");
            Console.WriteLine($"\n({withCacheStopwatch.ElapsedMilliseconds} ms)Result with cache:");

            // Print items, total weight and total value
            optimalSackCache.ForEach(item => Console.WriteLine(item));
            Console.WriteLine($"Total weight: {optimalSackCache.Sum(x => x.weight)}");
            Console.WriteLine($"Total value: {optimalSackCache.Sum(x => x.value)}");
        }
    }
}
