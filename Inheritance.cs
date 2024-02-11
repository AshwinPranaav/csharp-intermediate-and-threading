using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class Person
    {
        public string Name { get; set; }
    }

    class Employee : Person
    {
        public string JobTitle { get; set; }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    /*public class MainClass : I1, I2
    {
        public 
        static void Main(string[] args)
        {
                Employee employee = new Employee()
                {
                    Name = "John Doe",
                    JobTitle = "C# Developer"
                };

                Person person = employee;
                Console.WriteLine(person);
            String str = "some string";
            Console.WriteLine(str);
            }
    }*/
}
