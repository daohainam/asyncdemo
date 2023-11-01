using System.Diagnostics;

namespace AvoidAsync
{
    internal class Program
    {
        static void Main()
        {
            Time(async () =>
            {
                Console.WriteLine("Enter");
                await Task.Delay(TimeSpan.FromSeconds(10));
                Console.WriteLine("Exit");
            });
        }
        static void Time(Action action)
        {
            Console.WriteLine("Timing...");
            Stopwatch sw = Stopwatch.StartNew();
            action();
            Console.WriteLine($"...done timing: {sw.Elapsed}");
        }
    }
}