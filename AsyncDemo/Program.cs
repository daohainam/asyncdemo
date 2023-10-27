using System;
using System.IO;
using System.Threading.Tasks;

namespace AsyncDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await AsyncFunc2();
        }
        private static async Task<int> AsyncFunc2()
        {
            var r = (await File.ReadAllTextAsync("sample.txt")).Length;
            return r;
        }

    }
}