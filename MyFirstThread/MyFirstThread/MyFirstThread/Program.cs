using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyFirstThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(MyThread)); //creation de l'objet Thread.
            Thread t2 = new Thread(new ThreadStart(MyThread2));
            t.Start();
            t2.Start();
            Thread.Sleep(500);
            t.Abort();
            t2.Abort();
            Console.Read();
        }

        static void MyThread()
        {
            for (int i = 0; i < 99; i++)
            {
                Console.WriteLine("Thread 1");
            }
        }

        static void MyThread2()
        {
            for (int i = 0; i < 99; i++)
            {
                Console.WriteLine("Thread 2");
            }
        }
    }
}
