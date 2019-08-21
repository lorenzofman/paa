using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class MergeSort<T> : Sorter<T> where T : IComparable
    {
        public override void Sort(T[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        protected void Sort(T[] array, int left, int right)
        {
            if (left == right)
                return;
            int middle = (left + right) / 2;
            Sort(array, left, middle);
            Sort(array, middle + 1, right);
            Merge(array, left, middle, right);
        }

        protected void Merge(T[] array, int left, int middle, int right)
        {
            T[] leftArray = new T[middle - left + 1];
            T[] rightArray = new T[right - middle];

            for (int i = 0; i < leftArray.Length; i++)
            {
                leftArray[i] = array[left + i];
            }

            for(int j = 0; j < rightArray.Length; j++)
            {
                rightArray[j] = array[middle + j + 1];
            }

            int leftIndex = 0, rightIndex = 0;

            int k = left;

            while(leftIndex < leftArray.Length && rightIndex < rightArray.Length)
            {
                array[k++] = leftArray[leftIndex].CompareTo(rightArray[rightIndex]) <= 0
                    ? leftArray[leftIndex++] 
                    : rightArray[rightIndex++];
            }

            while(leftIndex < leftArray.Length)
            {
                array[k++] = leftArray[leftIndex++];
            }

            while (rightIndex < rightArray.Length)
            {
                array[k++] = rightArray[rightIndex++];
            }
        }
    }
}
