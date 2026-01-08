Console.WriteLine("--- Calling AsyncFunc1 using await ---");

Console.WriteLine("Hello from Main (thread {0})", Environment.CurrentManagedThreadId);
// Thread ID ban đầu của hàm Main và thread ID trước khi gọi await trong hàm AsyncFunc1 sẽ giống nhau
await AsyncFunc1();
// Sau khi await trong AsyncFunc1 hoàn thành, thread ID có thể thay đổi, tuy nhiên luôn bằng với thread ID của hàm Main tại thời điểm này
Console.WriteLine("Back to Main (thread {0})", Environment.CurrentManagedThreadId);

Console.WriteLine("\n--- Calling AsyncFunc2 with await ---");
await AsyncFunc2(); // vì có await nên hàm Main sẽ chờ AsyncFunc2 hoàn thành trước khi tiếp tục
for (int i = 0; i < 5; i++)
{
    Console.WriteLine("Main iteration {0} (thread {1})", i, Environment.CurrentManagedThreadId);
    await Task.Delay(2000); // Sau await này, hàm Main có thể tiếp tục trên một thread khác
}

Console.WriteLine("\n--- Calling AsyncFunc2 without await ---");
var t = AsyncFunc2(); // Vì không có await nên hàm Main sẽ không chờ AsyncFunc2 hoàn thành mà tiếp tục thực thi các lệnh bên dưới, do vậy hai hàm sẽ chạy đồng thời
for (int i = 0; i < 5; i++)
{
    Console.WriteLine("Main iteration {0} (thread {1})", i, Environment.CurrentManagedThreadId);
    await Task.Delay(2000); // Tương tự như trên, sau await này, hàm Main có thể tiếp tục trên một thread khác
}
await t; // Ta vẫn nên await để đảm bảo AsyncFunc2 hoàn thành trước khi tiếp tục 

/*
 * Bất cứ khi nào ta gọi AsyncFunc2() thì hàm này sẽ bắt đầu thực thi trên cùng một thread với hàm gọi nó (trong trường hợp này là Main) dù có dùng await hay không.
 * Trong ví dụ "Calling AsyncFunc2 without await", hàm AsyncFunc2 vẫn chạy trên cùng thread với Main và chỉ thay đổi thread khi gặp await bên trong nó.
 * Bạn có thể kiểm chứng bằng cách bỏ ghi chú dòng Thread.Sleep(8000); trong AsyncFunc2 để thấy rằng vòng for dòng 19 chỉ tiếp tục sau khi đã sleep xong.
 */

Console.WriteLine("\n--- Calling AsyncFunc3 ---");
int threadIdBefore = Environment.CurrentManagedThreadId;
await AsyncFunc3();
if (threadIdBefore == Environment.CurrentManagedThreadId)
{
    Console.WriteLine("Thread ID did not change after awaiting AsyncFunc3.");
}
else
{
    Console.WriteLine("Thread ID changed after awaiting AsyncFunc3.");
}

Console.WriteLine("Press any key to continue...");
Console.ReadKey();

/****************************/
async Task AsyncFunc1()
{
    Console.WriteLine("In AsyncFunc1 (thread {0})", Environment.CurrentManagedThreadId); // Thread ID sẽ không thay đổi
    await Task.Delay(5000);

    // Vì 5000ms khá lâu nên ThreadId rất có thể sẽ thay đổi, tùy thuộc vào việc thread tiếp tục công việc có trùng với thread ban đầu hay không
    Console.WriteLine("In AsyncFunc1 (thread {0})", Environment.CurrentManagedThreadId); 
}
/****************************/
async Task AsyncFunc2()
{
    // Thread.Sleep(8000);
    // Thread ID ban đầu khi vào hàm AsyncFunc2 chắc chắn sẽ giống với thread gọi hàm này
    // vì trong hàm async, trước khi gặp await, code vẫn chạy đồng bộ
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine("AsyncFunc2 iteration {0} (thread {1})", i, Environment.CurrentManagedThreadId);
        await Task.Delay(1000);
    }
}
/****************************/
async Task AsyncFunc3()
{
    Console.WriteLine("In AsyncFunc3 (thread {0})", Environment.CurrentManagedThreadId); // Thread ID sẽ không thay đổi
    await Task.Delay(0);
    // Vì 0ms nên ThreadId sẽ không thay đổi
    // Lý do là vì khoảng delay quá ngắn, nên khi kiểm tra thời gian thì hàm Delay đã hoàn thành ngay lập tức và 
    // không cần thực hiện thao tác delay 
    Console.WriteLine("In AsyncFunc3 (thread {0})", Environment.CurrentManagedThreadId);
}