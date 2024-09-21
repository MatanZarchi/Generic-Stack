using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> s1 = new Stack<string>();
            bool isValid = false;

            while (!isValid)
            {
                try
                {
                    for (int i = 0; i < s1._BrutoSize; i++)
                    { s1.Push(); }
                    s1.PrintStack();
                    Console.WriteLine($"Top element: {s1.Top()}\n");
                    s1.Pop();
                    s1.PrintStack();
                    Console.WriteLine("Bye Bye");
                    System.Threading.Thread.Sleep(10000);
                    isValid = true;
                }
                catch (Exception error)
                {
                    Console.WriteLine($"{error.Message}");
                }
            }
        }
    }
}
