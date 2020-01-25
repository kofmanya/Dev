using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumInSlidingWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            string[] str = Console.ReadLine().Split(new char[] { ' ' });

            int m = Convert.ToInt32(Console.ReadLine());

            List<int> numbers = new List<int>();

            for(int i = 0; i < n; ++i)
            {
                numbers.Add(Convert.ToInt32(str[i]));
            }

            List<int> res = new List<int>();

            Stack s1 = new Stack();
            Stack s2 = new Stack();

            for(int i = 0; i < n; ++i)
            {
                if(i == 0)
                {
                    s2 = new Stack();

                    for(int j = i + m - 1; j >= i; --j)
                    {
                        s1.Push(numbers[j]);
                    }

                    i += m - 1;
                    res.Add(s1.Max());
                }
                else
                {
                    s1.Pop();
                    s2.Push(numbers[i]);

                    res.Add(Math.Max(s1.Empty() ? -1 : s1.Max(), s2.Max()));

                    if(s1.Empty())
                    {
                        while (!s2.Empty())
                        {
                            s1.Push(s2.Pop());
                        }
                    }
                }
            }

            for(int i = 0; i < res.Count(); ++i)
            {
                Console.Write(res[i] + " ");
            }

            Console.WriteLine();
            Console.ReadLine();
        }
    }

    public class Node
    {
        public int value;
        public Node next;

        public Node(int t)
        {
            value = t;
        }
    }

    public class Stack
    {
        Node head;
        Stack auxiliaryStack;

        public Stack()
        {
            head = null;
        }

        public void Push(int t)
        {
            if (Empty())
            {
                head = new Node(default(int));
                Node newNode = new Node(t);
                head.next = newNode;

                auxiliaryStack = new Stack();
                auxiliaryStack.head = new Node(default(int));
                Node auxiliaryNewNode = new Node(t);
                auxiliaryStack.head.next = auxiliaryNewNode;
            }
            else
            {
                Node prevNode = head.next;
                Node newNode = new Node(t);
                head.next = newNode;
                newNode.next = prevNode;

                Node auxiliaryRrevNode = auxiliaryStack.head.next;
                Node auxiliaryNewNode = new Node(Math.Max(t, auxiliaryStack.Top()));
                auxiliaryStack.head.next = auxiliaryNewNode;
                auxiliaryNewNode.next = auxiliaryRrevNode;
            }
        }

        public int Pop()
        {
            if (Empty())
            {
                throw new IndexOutOfRangeException("Stack is empty.");
            }

            int ret = head.next.value;

            if (head.next.next == null)
            {
                head = null;
            }
            else
            {
                head.next = head.next.next;
            }

            if (auxiliaryStack.head.next == null)
            {
                auxiliaryStack.head = null;
            }
            else
            {
                auxiliaryStack.head.next = auxiliaryStack.head.next.next;
            }

            return ret;
        }

        public int Top()
        {
            if (Empty())
            {
                throw new Exception("Stack is empty.");
            }

            return head.next.value;
        }

        public int Max()
        {
            if (Empty())
            {
                throw new IndexOutOfRangeException("Stack is empty.");
            }

            return auxiliaryStack.Top();
        }

        public bool Empty()
        {
            return head == null;
        }
    }
}
