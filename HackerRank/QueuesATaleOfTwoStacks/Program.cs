using System;
using System.Collections.Generic;

namespace QueuesATaleOfTwoStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<int> queue = new MyQueue<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                int type = int.Parse(line[0]);

                if (type == 1)
                { // enqueue
                    queue.Enqueue(int.Parse(line[1]));
                }
                else if (type == 2)
                { // dequeue
                    queue.Dequeue();
                }
                else if (type == 3)
                { // print/peek
                    Console.WriteLine(queue.Peek());
                }
            }
        }
    }

    public class MyQueue<T>
    {
        Stack<T> stackNewestOnTop = new Stack<T>();
        Stack<T> stackOldestOnTop = new Stack<T>();

        public void Enqueue(T value)
        { // Push onto newest stack
            stackNewestOnTop.Push(value);
        }

        public T Peek()
        {
            while (stackOldestOnTop.Count == 0)
            {
                stackOldestOnTop.Push(stackNewestOnTop.Pop());
            }

            return stackOldestOnTop.Peek();
        }

        public T Dequeue()
        {
            while (stackOldestOnTop.Count == 0)
            {
                stackOldestOnTop.Push(stackNewestOnTop.Pop());
            }

            return stackOldestOnTop.Pop();
        }
    }
}
