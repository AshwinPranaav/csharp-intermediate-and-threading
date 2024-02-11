using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class DeadLock
    {
        static object lock1 = new object();
        static object lock2 = new object();

        static object lock3 = new object();
        static object lock4 = new object();

        static void AcquireLocks1()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            lock (lock1)
            {
                Console.WriteLine($"Thread {threadId} acquired lock 1");
                //Thread.Sleep( 1000 );
                lock (lock2)
                {
                    Console.WriteLine($"Thread {threadId} aquired lock 2");
                }
            }
        }

        static void AcquireLocks2()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            lock (lock2)
            {
                Console.WriteLine($"Thread {threadId} acquired lock 2");
                //Thread.Sleep(1000);
                lock (lock1)
                {
                    Console.WriteLine($"Thread {threadId} aquired lock 1");
                }
            }
        }

        static void AcquireLocks3()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            while (true)
            {
                if(Monitor.TryEnter(lock3, 1000)) // this second param is to just get within one second, not to release in one second
                {

                    try
                    {
                        Console.WriteLine($"Thread {threadId} acquired lock 3");
                        Thread.Sleep(1000);
                        Console.WriteLine($"Thread {threadId} attempted to acquire lock 4");

                        if(Monitor.TryEnter(lock4 , 1000)) // this second param is to just get within one second, not to release in one second
                        {
                            try
                            {
                                Console.WriteLine($"Thread {threadId} acquired lock 4");
                                break;
                            }
                            finally
                            {
                                Monitor.Exit(lock4); // this will actually release the lock
                            }
                        }
                    }
                    finally
                    {
                        Monitor.Exit(lock3);
                    }
                } 
            }
        }

        static void AcquireLocks4()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            while (true)
            {
                if (Monitor.TryEnter(lock4, 1000)) // this second param is to just get within one second, not to release in one second
                {

                    try
                    {
                        Console.WriteLine($"Thread {threadId} acquired lock 4");
                        Thread.Sleep(1000);
                        Console.WriteLine($"Thread {threadId} attempted to acquire lock 3");

                        if (Monitor.TryEnter(lock3, 1000)) // this second param is to just get within one second, not to release in one second
                        {
                            try
                            {
                                Console.WriteLine($"Thread {threadId} acquired lock 3");
                                break;
                            }
                            finally
                            {
                                Monitor.Exit(lock3); // this will actually release the lock
                            }
                        }
                    }
                    finally
                    {
                        Monitor.Exit(lock4);
                    }
                }
            }
        }

        /*static void Main(string[] args)
        {
            Thread t1 = new Thread(AcquireLocks1);
            Thread t2 = new Thread(AcquireLocks2);
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Thread t3 = new Thread(() => AcquireLocks3());
            Thread t4 = new Thread(() => AcquireLocks4());

            t3.Start();
            t4.Start();
            
            t3.Join();
            t4.Join();

            Console.WriteLine("Finished");
            Console.ReadLine();
        }*/
    }
}
