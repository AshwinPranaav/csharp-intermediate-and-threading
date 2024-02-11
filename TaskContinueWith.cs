using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TaskContinueWith
    {
        static int GetRandomNumber(int min, int max)
        {
            if(min > max)
            {
                throw new ArgumentException($"{min} is less than {max}");
            }
            Thread.Sleep( 1000 );
            return new Random().Next( min, max );
        }

        static int GetInt(string message)
        {
            int n = 0;
            while(true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if(int.TryParse(input, out n))
                {
                    return n;
                }
            }
        }

        /*static void Main(string[] args)
        {
            int min = GetInt("Enter min number: ");
            int max = GetInt("Enter max number: ");
            Task<int> task = Task.Run(() => GetRandomNumber(min, max));
            task.ContinueWith(task => { Console.WriteLine(task.Result); }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(task => { Console.WriteLine(task.Result); }, TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(task => { Console.WriteLine(task.Result); }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(task => { Console.WriteLine(task.Result);}, TaskContinuationOptions.OnlyOnFaulted);
            Console.Read();
        }*/
    }
}
    