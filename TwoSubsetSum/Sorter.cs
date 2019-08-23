using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public abstract class Sorter<T> where T: IComparable
    {
        public abstract void Sort(T[] array);
    }
}
