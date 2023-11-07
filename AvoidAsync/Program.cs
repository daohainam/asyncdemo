using System.Diagnostics;

namespace AvoidAsync
{
    internal class Program
    {
        static async Task Main()
        {
            await TimeAsync(InnerFunc);
        }

        static async Task InnerFunc()
        {
            Console.WriteLine("Enter");
            await Task.Delay(TimeSpan.FromSeconds(3));
            Console.WriteLine("Exit");
        }

        static async Task TimeAsync(Func<Task> action)
        {
            Console.WriteLine("Timing...");
            Stopwatch sw = Stopwatch.StartNew();
            await action();
            Console.WriteLine($"...done timing: {sw.Elapsed}");
        }
    }
}