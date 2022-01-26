using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace Problem1
{
    public static class ThreadLogic
    {
        private static int GenerateRandomNumber()
        {
            Random rng = new Random();

            return rng.Next(1,5);
        }

        public static void CreateThread(Action<string> write_ui)
        {
            int numberThreads = GenerateRandomNumber();
            Thread[] rndthreads = new Thread[numberThreads];

            for (int i = 0; i < numberThreads; i++)
            {
                rndthreads[i] = new Thread(() =>
                {
                    write_ui($"Hello, My Thread ID is : {Thread.CurrentThread.ManagedThreadId}");
                });

                rndthreads[i].Start();
            }
            numberThreads = 0;
        }

    }
}
