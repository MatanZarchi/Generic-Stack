using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Stack
{
    internal class Stack<T>
    {
        private T[] _stack;
        private T _number;
        private int NetoSize = 0, BrutoSize = 0;

        public int _BrutoSize
        {
            get
            {
                return this.BrutoSize;
            }
        }

        public Stack()
        {
            string size = "0";
            this.BrutoSize = this.validation(size);
            this._stack = new T[this.BrutoSize];
        }

        private int validation(string size)
        {
            bool isValid = false;
            Console.WriteLine("Enter size of stack > 0: ");
            while (!isValid)
            {
                size = Console.ReadLine();
                if (Int32.TryParse(size, out this.BrutoSize))
                    if (Int32.Parse(size) >= 1)
                        break;
                Console.WriteLine("Invalid input...");
            }
            return Int32.Parse(size);
        }

        private bool isEmpty()
        {
            if (this.NetoSize == 0 || this.BrutoSize == 0)
                return true;
            return false;
        }

        private bool isFull()
        {
            if (this.NetoSize == this.BrutoSize)
                throw new FormatException("Stack is full!");
            return false;
        }

        public T Top()
        {
            if (isEmpty())
            {
                Console.WriteLine("Let's push element");
                this.Push();
            }
            return this._stack[this.NetoSize - 1];
        }

        public T ConvertToGeneric<T>(string input)
        {
            try
            {
                // Convert the input to the specified type T - Generic Convert must has Try-Catch
                T value = (T)Convert.ChangeType(input, typeof(T));
                return value;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Conversion error: {e.Message}");
                return default(T);
            }
        }

        public void Push()
        {
            if (!isFull())
            {
                this.NetoSize++;
                Console.WriteLine("Enter an element to insert trough stack: ");
                string userInput = Console.ReadLine();
                this._number = this.ConvertToGeneric<T>(userInput);
                this._stack[this.NetoSize - 1] = this._number;
                Console.WriteLine("Push success...");
            }
            else
            {
                string check;
                Console.WriteLine("Sorry...Stack is full! Do you want to delete number? y/n");
                check = Console.ReadLine();
                if (check == "y")
                {
                    this.Pop();
                    this.Push();
                }
            }
        }

        public void Pop()
        {
            if (!this.isEmpty())
            {
                int index = 0;
                T[] _newStack;

                this.NetoSize--;
                _newStack = new T[this.NetoSize];

                for (int i = 0; i < this.NetoSize; ++i)
                {
                    _newStack[i] = this._stack[index++];
                }
                swapStacks(ref this._stack, ref _newStack);
                Console.WriteLine("After Pop:");
            }
        }

        private void swapStacks(ref T[] stack1, ref T[] stack2)
        {
            stack1 = stack2;
        }

        public void PrintStack()
        {
            if (!isEmpty())
            {
                Console.WriteLine("*****************");
                for (int i = this.NetoSize - 1; i >= 0; i--)
                {
                    Console.WriteLine("*\t" + this._stack[i] + "\t*");
                }
                Console.WriteLine("*****************");
            }
        }
    }
}
