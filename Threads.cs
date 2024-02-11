using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Threads
    {
        static void DoWork(object? someString1)
        {
            Console.WriteLine(someString1);
            Thread.Sleep(5000);
        }

        static void DoAnothoerWork(string someString1, string someString2)
        {
            Console.WriteLine($"{someString1} {someString2}");
            Thread.Sleep(1000);
        }

        static void DoBackgroundProcess()
        {
            Thread.Sleep(10000);
            Console.WriteLine("Background process");
        }

        static void ThreadPoolMethod(string url)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(url).Result;
            Console.WriteLine(response.StatusCode);
        }

        static int GetRandomNumber()
        {
            Thread.Sleep(1000);
            var random = new Random().Next(1, 10);
            Console.WriteLine(random);
            return random;
        }

        /*public static void Main(string[] args)
        {
            var t1 = new Thread(DoWork);
            var t2 = new Thread(DoWork);
            t1.Start("Thread 1");
            t2.Start("Thread 2");

            // This doesn't work only single param that too object
            *//*t1.Start("Thread 1", "Some String");
            t2.Start("Thread 2", "Some String");*//*
            var t4 = new Thread(() => DoBackgroundProcess());
            t4.IsBackground = true;
            t4.Start();


            var t3 = new Thread(() => DoAnothoerWork("str1", "str2"));
            t3.Start();

            // all these are foreground threads, you can also have background threads. It is just that the main thread Main doesn't stop till the background thread finishes

            // thread pool
            List<string> urls = new List<string>()
            {
                "https://www.google.com/",
                "https://www.duckduckgo.com/",
                "https://www.yahoo.com/",
            };

            foreach(string url in urls)
            {
                ThreadPool.QueueUserWorkItem((state) => ThreadPoolMethod(url));
            }

            Task task = new Task(() => GetRandomNumber());
            task.Start();

        }*/
    }
}
