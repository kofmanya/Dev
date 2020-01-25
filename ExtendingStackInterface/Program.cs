using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendingStackInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            Stack s = new Stack();

            for(int i = 0; i < n; ++i)
            {
                string[] str = Console.ReadLine().Trim().Split(new char[] { ' ' });

                if(str.Length == 2)
                {
                    s.Push(Convert.ToInt32(str[1]));
                }
                else if(str[0] == "pop")
                {
                    s.Pop();
                }
                else
                {
                    if (!s.Empty())
                        Console.WriteLine(s.Max());
                }
            }

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
            if(Empty())
            {
                throw new IndexOutOfRangeException("Stack is empty.");
            }

            int ret = head.next.value;

            if(head.next.next == null)
            {
                head = null;
            }
            else
            {
                head.next = head.next.next;
            }

            if(auxiliaryStack.head.next == null)
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
            if(Empty())
            {
                throw new Exception("Stack is empty.");
            }

            return head.next.value;
        }

        public int Max()
        {
            if(Empty())
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
