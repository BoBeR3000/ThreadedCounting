using System;
using System.Threading.Tasks;

namespace ThreadCounting
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var c = new ThreadedCounting();
            await c.Run();
            c.Print();
        }
    }
}
