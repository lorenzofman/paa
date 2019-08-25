using System;
using System.Collections.Generic;

namespace Inversions
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            Inversions inversions = new Inversions();
            List<int> randomList = RandomList(elements: 800, maxValue: 100);
            PrintList(randomList);
            inversions.BruteForceInversions(randomList);
            inversions.FastInversions(randomList);
        }

        static List<int> RandomList(int elements, int maxValue)
        {
            List<int> list = new List<int>(elements);
            Random random = new Random();
            for(int i = 0; i < elements; i++)
            {
                list.Add(random.Next() % maxValue);
            }
            return list;
        }

        static void PrintList<T>(IReadOnlyList<T> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i} - {list[i]}");
            }
        }
    }
}
