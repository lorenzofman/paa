using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSubsetSum
{
    public class EntryPoint
    {
        public static void Main()
        {
            List<int> list = FetchList();
            SubsetSolver solver = new SubsetSolver();
            Console.WriteLine("Value of x: ");
            int x = int.Parse(Console.ReadLine());
            solver.Solve(list, x);
        }

        private static List<int> FetchList()
        {
            Console.WriteLine("Type the collection of numbers, type any non-number to close the stream");
            List<int> list = new List<int>();
            for (; ;)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    list.Add(result);
                }
                else
                {
                    return list;
                }
            }
        }
    }
}
