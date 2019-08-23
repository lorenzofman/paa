using Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSubsetSum
{
    public class SubsetSolver
    {
        public void Solve(List<int> subset, int x)
        { 
            // Sorts the array
            MergeSort<int> merge = new MergeSort<int>();
            int[] arr = subset.ToArray();
            merge.Sort(arr);
            subset = arr.ToList();
            // Creates the binary searcher for future use
            BinarySearch<int> binarySearch = new BinarySearch<int>();
            // Foreach element find the possible complement and try to find it
            // It will execute n * log n (Binary Search cost)
            for(int i = 0; i < subset.Count; i++)
            {
                int possibleComplement = x - subset[i];
                int complement = binarySearch.IndexOf(subset, possibleComplement, false);
                if (complement != -1)
                {
                    Console.WriteLine($"Pair: ({subset[i]}, {subset[complement]})");
                }
            }
        }
    }
}
