using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class WhenAllMethod
    {
        static async Task<int> DoWork(int taskId)
        {
            Console.WriteLine($"Task {taskId} started...");
            await Task.Delay(1);
            Console.WriteLine($"Task {taskId} completed...");
            return taskId * taskId;
        }

        static async Task<int> Fetch(string url)
        {
            Console.WriteLine($"Fetching {url}");
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync( url );
            String content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Fetched {url} ({content.Length} bytes)");

            return content.Length;
        }

        static async Task Main(string[] args)
        {
            // What's the difference, coz if I change the return type to just int of DoWork
            // it would still work for first call
            // My question is for the Task.Run, why it isn't Task<Task<int>>

            // The answer is that the behaviour of Task.Run method is to always 
            Task<int> task1 = Task.Run(() => DoWork(1));
            Task<int> task2 = DoWork(2);
            Task<int> task3 = DoWork(3);

            int[] result = await Task.WhenAll(task1, task2, task3);
            Console.WriteLine(string.Join(" ", result));

            Task<int> task4 = Task.Run(() => Fetch("https://www.rfc-editor.org/rfc/rfc2616"));
            Task<int> task5 = Task.Run(() => Fetch("https://www.rfc-editor.org/rfc/rfc2822"));
            Task<int> task6 = Task.Run(() => Fetch("https://www.rfc-editor.org/rfc/rfc1180"));

            int[] results = await Task.WhenAll(task4, task5, task6);
            Console.WriteLine($"Total {results.Sum()} bytes");
        }
    }
}
