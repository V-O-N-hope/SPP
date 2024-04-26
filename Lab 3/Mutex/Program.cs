using System;
using System.Runtime.InteropServices;
using Mutex;

public class Program
{
    static Mutex.Mutex mutex = new Mutex.Mutex();

    static Thread[] threads = new Thread[12];



    private static void Main(string[] args)
    {
        int counter = 0;

        for (int i = 0; i < 12; i++)
        {
            int number = i;
            Thread t = new Thread(() =>
            {
                Console.WriteLine($"Enter into thread number {number}");
                Thread.Sleep(10);
                mutex.Lock();
                counter++;
                Thread.Sleep(10);
                if (counter != 1)
                {
                    throw new Exception("Not working");
                }
                Thread.Sleep(10);
                counter--;
                if (counter != 0)
                {
                    throw new Exception("Not working");
                }
                mutex.Unlock();
            });
            t.IsBackground = true;
            threads[i] = t;
            t.Start();
        }

        for (int i = 0; i < 12; i++)
        {
            threads[i].Join();
        }

        Console.ReadLine();
    }
}