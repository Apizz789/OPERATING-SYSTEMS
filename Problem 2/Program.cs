//#3
using System;
using System.Threading;

namespace OS_Problem_02
{
    class Thread_safe_buffer
    {
        static int[] TSBuffer = new int[10];
        static int Front = 0;
        static int Back = 0;
        static int Count = 0;
        private static object _Lock = new object();

        static void EnQueue(int eq)
        {
            TSBuffer[Back] = eq;
            Back++;
            Back %= 10;
            Count += 1;
        }

        static int DeQueue()
        {
            int x = 0;
            x = TSBuffer[Front];
            Front++;
            Front %= 10;
            Count -= 1;
            return x;
        }

        static void th01()
        {
            int i = 1;
            while (i < 51)
            {
                lock (_Lock)
                {
                    if (Count < 10)
                    {
                        EnQueue(i);
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("wait 1");
                    }
                    Thread.Sleep(5);
                }
            }

        }

        static void th011()
        {
            int i = 100;

            while (i < 151)
            {
                lock (_Lock)
                {
                    if (Count < 10)
                    {
                        EnQueue(i);
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("wait 1");
                    }
                    Thread.Sleep(5);
                }
            }
        }

        static void th02(object t)
        {
            int i = 0;
            int j;

            while (i < 60)
            {
                lock (_Lock)
                {
                    if(Count > 0){
                    j = DeQueue();
                    i++;
                    Console.WriteLine("j={0}, thread:{1} count:{2}", j, t, Count);
                    }
                    Thread.Sleep(100);
                }
            }
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(th01);
            Thread t11 = new Thread(th011);
            Thread t2 = new Thread(th02);
            Thread t21 = new Thread(th02);
            Thread t22 = new Thread(th02);

            t1.Start();
            t11.Start();
            t2.Start(1);
            t21.Start(2);
            t22.Start(3);
        }
    }
}
