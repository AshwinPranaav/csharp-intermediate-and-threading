using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{   
    internal class CancellationTokenExample
    {
        static List<int> Square(int max, CancellationToken token)
        {
            List<int> list = new List<int>();
            for(int i = 0; i < max; i++)
            {
                Thread.Sleep(1000);

                if(token.IsCancellationRequested)
                {
                    Console.WriteLine("Cancellation Requested...");
                    //token.ThrowIfCancellationRequested();
                    break;
                }
                Console.WriteLine(i * i);
                list.Add(i * i);
            }
            return list;
        }

        /*static void Main(string[] args)
        {
            CancellationTokenSource cts = new();

            Task<List<int>> task = Task.Run(() => Square(10, cts.Token));

            task.ContinueWith(task =>
            {
                List<int> sqaures = task.Result;
                Console.WriteLine("The sqaured numbers are: ");
                foreach (int square in sqaures)
                {
                    Console.WriteLine($"{square}");
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            Console.WriteLine("Press 'c' to cancel");
            while(true)
            {
                var keyInfo = Console.ReadKey(true);
                if (keyInfo.KeyChar == 'c')
                {
                    if(task.Status == TaskStatus.Running) // you can use !task.IsCompleted as the state is just made as Task.Cancelled
                    {
                        cts.Cancel(); // this is make the status as Cancelled
                        Console.WriteLine("Cancelling the task...");
                        task.Wait();
                        break;
                    }
                }
                if(task.Status == TaskStatus.RanToCompletion)
                {
                    break;
                }
            }
        }*/
    }
}
