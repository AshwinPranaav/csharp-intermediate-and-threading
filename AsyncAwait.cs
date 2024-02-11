using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class AsyncAwait
    {
        static async Task ShowFileContents(string fileName)
        {
            /*Task<string[]> task = File.ReadAllLinesAsync(fileName);
            task.ContinueWith(task =>
            {
                string[] lines = task.Result;
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            });
            while(!task.IsCompleted)
            {
                Console.WriteLine("Reading...");
            }*/
            string[] lines = await File.ReadAllLinesAsync(fileName);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("I won't be printed until the top one completes, but this is " +
                "not the case with using ContinueWith, as task.Result doesn't block");
        }

        /*static void Main(string[] args)
        {
            ShowFileContents("C:\\Users\\apranaa\\Documents\\PAT\\Dropwizard.txt");
            Console.Read();
        }*/
    }
}
