using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadCounting
{
    public class ThreadedCounting
    {
        private ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>();

        public Task Run()
        {
            return Task.WhenAll(Count(1), Count(2), Count(3));

        }

        public void Print()
        {
            Console.WriteLine("Item - ThreadId");
            foreach (var item in cd)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }

        private Task Count(int stasrt)
        {
            return Task.Run(() =>
            {
                for (int i = stasrt; i <= 100; i += 3)
                {
                    cd.TryAdd(i, Thread.CurrentThread.ManagedThreadId);
                }
            });
        }
    }
}
