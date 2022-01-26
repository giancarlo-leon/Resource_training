using System;
using System.Threading;
using System.Threading.Tasks;

namespace Problem3
{
    class Program
    {
        static Semaphore semaphore = new Semaphore(1, 10);
        static int counter = 1;

        const int THREAD_NUMBER = 10;
        public delegate void Del();
        static void CreateThreads()
        {
            Thread[] threads = new Thread[THREAD_NUMBER];


            for (int i = 0; i < THREAD_NUMBER; i++)
            {
                threads[i] = new Thread(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (counter < 100)
                        {
                            semaphore.WaitOne();
                            Console.WriteLine($"{counter} printed by Thread : {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                            counter++;
                            semaphore.Release();
                        }
                    }

                });
                threads[i].Start();
            }
        }



        static void Main(string[] args)
        {
            Del thFunction = CreateThreads;
            Task task = Task.Run(() => thFunction.Invoke());
            task.Wait();
        }
    }
}
