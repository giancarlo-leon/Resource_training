using System;
using System.Threading;

namespace Problem_2
{
    internal class Program
    {
        static Semaphore semaphore = new Semaphore(1,10);
        static int counter = 1;

        const int THREAD_NUMBER = 10;


        static void Main(string[] args)
        {
            Thread[] threads = new Thread[THREAD_NUMBER];


            for (int i = 0; i < THREAD_NUMBER; i++)
            {
                threads[i] = new Thread(() =>
                {
                    for(int i = 0; i < 10; i++)
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
    }
}
