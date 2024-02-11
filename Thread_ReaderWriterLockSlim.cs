using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Thread_ReaderWriterLockSlim
    {
        static int counter = 0;
        
        static ReaderWriterLockSlim _lock = new();
        
        static void Read()
        {
            while(true)
            {
                try
                {
                    _lock.EnterReadLock();
                    Console.WriteLine($"R: Thread {Thread.CurrentThread.ManagedThreadId} is reading: {counter}");
                }
                finally
                {
                    _lock.ExitReadLock();
                }
                Thread.Sleep(500);
            }
        }

        static void Write()
        {
            while(true)
            {
                try
                {
                    _lock.EnterWriteLock();
                    Console.WriteLine($"R: Thread {Thread.CurrentThread.ManagedThreadId} is writing: {counter++}");
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
                Thread.Sleep(2000);
            }
        }
        
        /*static async Task Main(string[] args)
        {
            // this creates five reader threads
            for(int i = 0; i < 5; i++)
            {
                //var t = new Thread(Read);
                //t.IsBackground = true;
                //t.Start();
                await Task.Run(Read); //this would not start, the program just stops
            }

            // this creates two writer threads
            for(int i = 0;i < 2; i++)
            {
                //var t = new Thread(Read);
                //t.IsBackground = true;
                //t.Start();
                Task.Run(Write); //this would not start, the program just stops
            }
            //Console.ReadLine();
        }*/
    }
}
