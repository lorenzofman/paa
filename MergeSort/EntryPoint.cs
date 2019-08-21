using Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class EntryPoint
{
    public static void Main()
    {
        MergeSort<int> sorter = new MergeSort<int>();
        int[] array = new int[] { 1, 4, 3, 7, 2, 0, 5, 6, 9 };
        sorter.Sort(array);
    }
}
