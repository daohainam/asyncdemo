
namespace CallingAsyncDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var demo = new Demo();
            await demo.RunDemoAsync();
        }
    }
}
