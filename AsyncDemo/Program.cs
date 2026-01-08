using System;
using System.IO;
using System.Threading.Tasks;

namespace AsyncDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Thread ID của hàm Main là 1
            Console.WriteLine($"Current thread Id: {Environment.CurrentManagedThreadId}");
            NonAsyncFunc();
            // Hàm NonAsyncFunc không async nên không có gì xảy ra, Thread ID vẫn bằng 1
            Console.WriteLine($"Current thread Id after NonAsyncFunc(): {Environment.CurrentManagedThreadId}");
            await AsyncFunc1(); // xem comment trong phần khai báo hàm
            // Vì AsyncFunc1() không có async nào xảy ra nên Thread ID vẫn là 1
            Console.WriteLine($"Current thread Id after AsyncFunc1(): {Environment.CurrentManagedThreadId}");

            int i = 1;
            while (i < 100000)
            {
                var r = await AsyncFunc2(); // xem comment trong phần khai báo hàm
                                            // Sau khi lời gọi async trong AsyncFunc2 kết thúc, nó sẽ tiếp tục thực thi như một hàm sync bình thường
                                            // Do vậy Thread ID in ra ở vị trí này sẽ giống với Thread ID trong AsyncFunc2 - 2
                Console.WriteLine($"Current thread Id after AsyncFunc2(): {Environment.CurrentManagedThreadId}");

                if (Environment.CurrentManagedThreadId != r)
                {
                    Console.WriteLine($"Thread ID is different ({i})");
                    break;
                }
            }

            // Task.Run luôn gọi hàm action bên trong nó với một thread mới, 
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
            // khi gọi FromResult, chúng ta thực sự đã có kết quả sẵn, nên chẳng có async nào xảy ra cả, 
            // awaiter.IsCompleted sẽ trả về True ngay từ lần gọi đầu tiên
            return await Task.FromResult(0);
        }

        private static async Task<int> AsyncFunc2()
        {
            // Một hàm async chỉ [có thể] bắt đầu gọi async, tức sử dụng đến State Machine khi nó gọi đến
            // hàm async khác, tức là khi nó sử dụng await, do vậy chỗ này Thread ID vẫn là 1
            Console.WriteLine($"Current thread Id in AsyncFunc2 - 1: {Environment.CurrentManagedThreadId}");
            // Hàm ReadAllTextAsync() thread hiện tại (Thread ID 1) sẽ gửi một lệnh đến controller của
            // đĩa (thông qua OS, device driver...) và kết thúc hoạt động, không có bất kỳ thread nào chạy
            // để phục vụ cho quá trình đọc từ đĩa
            var r = (await File.ReadAllTextAsync("sample.txt")).Length;
            // Khi dữ liệu từ đĩa đã được chuyển vào bộ nhớ và sẵn sàng để sử dụng, .NET (OS) sẽ đánh dấu 
            // luồng xử lý hiện tại (đoạn code ngay sau lời gọi ReadAllTextAsync) đã sẵn sàng để chạy tiếp,
            // một thread nào đó (trong thread pool) sẽ bắt đầu xử lý. Lúc này Thread ID sẽ là ID của thread
            // mới (về lý thuyết nó vẫn có thể là 1 nếu như thread 'mới' này lại trúng ngay thread 'cũ').
            Console.WriteLine($"Current thread Id in AsyncFunc2 - 2: {Environment.CurrentManagedThreadId}");

            return Environment.CurrentManagedThreadId;
        }

    }
}