using System;
using System.Collections.Generic;
using System.Linq;

namespace EventScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            (int idx, int start, int end)[] eventTimes = new (int, int, int)[]
            {
                (0, 0, 6),
                (1, 6, 10),
                (2, 3, 5),
                (3, 5, 9),
                (4, 8, 11),
                (5, 2, 13),
                (6, 1, 4),
                (7, 12, 14),
                (8, 3, 8),
                (9, 8, 12),
                (10, 4, 7)
            };

            List<(int index, int start, int end)> orderedEvents = eventTimes.OrderBy(evt => evt.end).ToList();

            List<(int index, int start, int end)> events = new List<(int index, int start, int end)> { orderedEvents[0] };
            int i = 0;
            for (int m = 1; m < orderedEvents.Count; m++)
            {
                if(orderedEvents[m].start >= orderedEvents[i].end)
                {
                    events.Add(orderedEvents[m]);
                    i = m;
                }
            }

            Console.WriteLine("Max Events:");
            events.ForEach(x => Console.WriteLine($"Event {x.index} [{x.start}, {x.end})"));
        }
    }
}
