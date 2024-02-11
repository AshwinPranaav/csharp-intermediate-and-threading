using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TaskExceptionHandling
    {
        static int Divide(int a, int b)
        {
            Thread.Sleep(1000);
            return a / b;
        }

        /*static void Main(string[] args)
        {
            try
            {
                Task<int> task = Task.Run(() => Divide(6, 0));
                int result = task.Result;
            }
            catch(AggregateException ex)
            {
                ex.Handle(e =>
                {
                    if(e is DivideByZeroException)
                    {
                        Console.WriteLine(e.Message);
                        return true;
                    }
                    else
                    {
                        throw e;
                    }
                });
            }

        }*/
    }
}
