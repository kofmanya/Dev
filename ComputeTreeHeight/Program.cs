using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputeTreeHeight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            string[] str = Console.ReadLine().Split(new char[] { ' ' });

            List<int> parents = new List<int>();

            foreach (string s in str)
                parents.Add(Convert.ToInt32(s));

            List<List<int>> matrix = new List<List<int>>();

            for (int i = 0; i < n; ++i)
                matrix.Add(new List<int>());

            int root = -1;

            for(int i = 0; i < n; ++i)
            {
                if (parents[i] == -1)
                    root = i;
                else
                {
                    matrix[parents[i]].Add(i);
                }
            }

            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            q.Enqueue(new Tuple<int, int>(root, 1));

            int res = 1;

            while(!q.Empty())
            {
                Tuple<int, int> tmp = q.Dequeue();

                res = tmp.Item2;

                for (int i = 0; i < matrix[tmp.Item1].Count; ++i)
                    q.Enqueue(new Tuple<int, int>(matrix[tmp.Item1][i], res + 1));
            }

            Console.WriteLine(res);
            Console.ReadLine();
        }

        public class Node<T>
        {
            public Node(T value, Node<T> next)
            {
                this.value = value;
                this.next = next;
            }

            public T value;
            public Node<T> next;
        }

        public class Queue<T>
        {
            Node<T> head;
            Node<T> tail;

            public Queue()
            {
                head = null;
                tail = null;
            }

            public void Enqueue(T t)
            {
                if(head == null)
                {
                    Node<T> node = new Node<T>(t, null);
                    head = new Node<T>(default(T), node);
                    tail = new Node<T>(default(T), node);
                }
                else
                {
                    Node<T> node = tail.next;
                    Node<T> newNode = new Node<T>(t, null);
                    tail.next = newNode;
                    node.next = newNode;
                }
            }

            public T Dequeue()
            {
                if(Empty())
                {
                    throw new IndexOutOfRangeException("The Queue is empty.");
                }

                Node<T> node = head.next;

                if (node.next == null)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    head.next = node.next;
                }

                return node.value;
            }

            public bool Empty()
            {
                return head == null;
            }
        }
    }
}
