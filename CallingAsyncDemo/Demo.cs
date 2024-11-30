using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallingAsyncDemo
{
    internal class Demo
    {
        public async Task<string> ReadFileContentWithAwait(string file)
        {
            var content = await File.ReadAllTextAsync(file);

            return content;
        }

        public Task<string> ReadFileContentWithoutAwait(string file)
        {
            return File.ReadAllTextAsync(file);
        }

        public async Task RunDemoAsync()
        {
            var t1 = ReadFileContentWithAwait("datafile.txt");
            var t2 = ReadFileContentWithoutAwait("datafile.txt");

            var content1 = await t1;
            var content2 = await t2;

            Console.WriteLine(content1);
            Console.WriteLine(content2);

            if (content1 == content2)
            {
                Console.WriteLine("The content is the same.");
            }
            else
            {
                Console.WriteLine("The content is different.");
            }
        }
    }
}
