using System;
using System.Collections.Generic;
using System.Text;

namespace Inversions
{
    public class Inversions
    {
        public void BruteForceInversions(List<int> list)
        {
            int inversions = 0;
            Console.WriteLine("# Brute Force Inversions #");
            for (int i = 0; i < list.Count; i++)
            {
                for(int j = i + 1; j < list.Count; j++)
                {
                    if(list[i] > list[j])
                    {
                        inversions++;
                    }
                }
            }
            Console.WriteLine($"Inversions: {inversions}");
        }

        public void FastInversions(List<int> list)
        {
            Console.WriteLine("# O(n*log n) Inversions #");
            FastInv(list.ToArray());
        }



        private void FastInv(int[] array)
        {
            int inversions = FastInv(array, 0, array.Length - 1);
            Console.WriteLine($"Inversions: {inversions}");
        }

        protected int FastInv(int[] array, int left, int right)
        {
            if (left == right)
                return 0;
            int middle = (left + right) / 2;
            int inversions = 0;
            inversions += FastInv(array, left, middle);
            inversions += FastInv(array, middle + 1, right);
            return inversions + Merge(array, left, middle, right);
        }

        protected int Merge(int[] array, int left, int middle, int right)
        {
            int inversions = 0;
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];

            for (int i = 0; i < leftArray.Length; i++)
            {
                leftArray[i] = array[left + i];
            }

            for (int j = 0; j < rightArray.Length; j++)
            {
                rightArray[j] = array[middle + j + 1];
            }

            int leftIndex = 0, rightIndex = 0;

            int k = left;

            while (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
            {
                if (leftArray[leftIndex].CompareTo(rightArray[rightIndex]) <= 0)
                {
                    array[k++] = leftArray[leftIndex++];
                }
                else
                {
                    inversions += leftArray.Length - leftIndex;
                    array[k++] = rightArray[rightIndex++];
                }
            }

            while (leftIndex < leftArray.Length)
            {
                array[k++] = leftArray[leftIndex++];
            }

            while (rightIndex < rightArray.Length)
            {
                array[k++] = rightArray[rightIndex++];
            }
            return inversions;
        }
    }
}
