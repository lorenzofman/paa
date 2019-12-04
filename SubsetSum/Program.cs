using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SubsetSum
{
    class Program
    {
        static Dictionary<(int, int), bool> results = new Dictionary<(int, int), bool>();

        // Returns true if there is a subset of set[] with sum 
        // equal to given sum 
        static bool IsSubsetSumOptimized(int[] set, int n, int sum)
        {
            // Base Cases 
            if (sum == 0)
            {
                return true;
            }
            if (n == 0 && sum != 0)
            {
                return false;
            }
            // If last element is greater than sum,  
            // then ignore it 
            if (set[n - 1] > sum)
            {
                if (results.ContainsKey((n - 1, sum)) == false)
                {
                    results[(n - 1, sum)] = IsSubsetSumOptimized(set, n - 1, sum);
                }
                return results[(n - 1, sum)];
            }

            /* else, check if sum can be obtained  
            by any of the following 
            (a) including the last element 
            (b) excluding the last element */

            if (results.ContainsKey((n - 1, sum)) == false)
            {
                results[(n - 1, sum)] = IsSubsetSumOptimized(set, n - 1, sum);
            }

            if (results.ContainsKey((n - 1, sum - set[n - 1])) == false)
            {
                results[(n - 1, sum - set[n - 1])] = IsSubsetSumOptimized(set, n - 1, sum - set[n - 1]);
            }
            return results[(n - 1, sum - set[n - 1])] || results[(n - 1, sum - set[n - 1])];

        }

        static bool IsSubsetSum (int[] set, int n, int sum)
        {
            // Base Cases 
            if (sum == 0)
                return true;
            if (n == 0 && sum != 0)
                return false;

            // If last element is greater than sum,  
            // then ignore it 
            if (set[n - 1] > sum)
                return IsSubsetSum(set, n - 1, sum);

            /* else, check if sum can be obtained  
            by any of the following 
            (a) including the last element 
            (b) excluding the last element */
            return IsSubsetSum(set, n - 1, sum) ||
                           IsSubsetSum(set, n - 1, sum - set[n - 1]);

        }

        // Driver program  
        public static void Main()
        {
            for (int i = 0; i < 10; i++)
            {
                Random random = new Random();
                int min = 0, max = 20;
                int[] set = Enumerable.Repeat(min, max).Select(_ => random.Next(min, max)).ToArray();
                int sum = max * max / 2;
                int n = set.Length;
                Stopwatch sw = new Stopwatch();
                sw.Start();
                if (IsSubsetSum(set, n, sum) == true)
                {
                    Console.WriteLine("Found a subset with given sum");
                }
                else
                {
                    Console.WriteLine("No subset with given sum");
                }
                Console.WriteLine($"{sw.ElapsedMilliseconds} ms");

                sw.Restart();
                if (IsSubsetSumOptimized(set, n, sum) == true)
                {
                    Console.WriteLine("Found a subset with given sum");
                }
                else
                {
                    Console.WriteLine("No subset with given sum");
                }
                Console.WriteLine($"{sw.ElapsedMilliseconds} ms");
            }
        }
    }
}
