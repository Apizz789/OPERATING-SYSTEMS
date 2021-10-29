// using System;
// using System.Threading;

// namespace Lab_OS_Concurrency{
//     class Program
//     {
//         static int resource = 10000;
//         static void TestThread1()
//         {
//             Console.WriteLine("Thread# 1 i={0}", resource);
//         }
//         static void TestThread2()
//         {
//             Console.WriteLine("Thread# 2 i={0}", resource);
//         }
//         static void Main(string[] args)
//         {
//             Thread th1 = new Thread(ThreadThread1);
//             Thread th2 = new Thread(ThreadThread2);
//             th1.Start();
//             th2.Start();

//         }

//         private static void ThreadThread2(object obj)
//         {
//             throw new NotImplementedException();
//         }

//         private static void ThreadThread1(object obj)
//         {
//             throw new NotImplementedException();
//         }
//     }
// }