using System;
using System.IO;
using System.Threading.Tasks;

namespace AsyncDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Current thread Id: {Environment.CurrentManagedThreadId}");
            NonAsyncFunc();
            Console.WriteLine($"Current thread Id after NonAsyncFunc(): {Environment.CurrentManagedThreadId}");
            await AsyncFunc1();
            Console.WriteLine($"Current thread Id after AsyncFunc1(): {Environment.CurrentManagedThreadId}");
            await AsyncFunc2();
            Console.WriteLine($"Current thread Id after AsyncFunc2(): {Environment.CurrentManagedThreadId}");

            var t1 = Task.Run(() => Console.WriteLine($"Current thread Id in Task.Run 1: {Environment.CurrentManagedThreadId}"));
            t1.Wait();
            Console.WriteLine($"Current thread Id after Task.Run 1: {Environment.CurrentManagedThreadId}");

            await Task.Run(() => Console.WriteLine($"Current thread Id in Task.Run 2: {Environment.CurrentManagedThreadId}"));
            Console.WriteLine($"Current thread Id after Task.Run 2: {Environment.CurrentManagedThreadId}");

            await Task.Run(() =>
            {
                Task.Delay(1000);
                Console.WriteLine($"Current thread Id in Task.Run 3: {Environment.CurrentManagedThreadId}");
            }
            );
            Console.WriteLine($"Current thread Id after Task.Run 3: {Environment.CurrentManagedThreadId}");

            await Task.Run(() =>
            {
                Task.Delay(1000);
                Console.WriteLine($"Current thread Id in Task.Run 4: {Environment.CurrentManagedThreadId}");
            }
            );
            Console.WriteLine($"Current thread Id after Task.Run 4: {Environment.CurrentManagedThreadId}");
        }

        private static int NonAsyncFunc()
        {
            return 0;
        }

        private static async Task<int> AsyncFunc1()
        {
            return await Task.FromResult(0);
        }

        private static async Task<int> AsyncFunc2()
        {
            Console.WriteLine($"Current thread Id in AsyncFunc2 - 1: {Environment.CurrentManagedThreadId}");
            var r = (await File.ReadAllTextAsync("sample.txt")).Length;
            Console.WriteLine($"Current thread Id in AsyncFunc2 - 2: {Environment.CurrentManagedThreadId}");

            return r;
        }

    }
}