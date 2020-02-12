using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable ht = new HashTable(10000019, 1000, 34, 2);

            int n = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < n; ++i)
            {
                string[] str = Console.ReadLine().Split(new char[] { ' ' });

                if(str[0] == "add")
                {
                    ht.Add(Convert.ToInt32(str[1]), str[2]);
                }
                else if(str[0] == "del")
                {
                    ht.Remove(Convert.ToInt32(str[1]));
                }
                else
                {
                    Console.WriteLine(ht.Find(Convert.ToInt32(str[1])));
                }
            }
            
            Console.ReadLine();
        }

        public class Node
        {
            public Node()
            {
                this.value = new Tuple<int, string>(-1, "");
                this.next = null;
            }

            public Node(int value, string name)
            {
                this.value = new Tuple<int, string>(value, name);
            }

            public Tuple<int, string> value;
            public Node next;
        }

        public class LinkedList
        {
            public Node head;
            
            public LinkedList()
            {
                head = new Node();
            }

            public void Add(int value, string name)
            {
                Node currNode = head;

                while(currNode.next != null)
                {
                    currNode = currNode.next;

                    if(currNode.value.Item1 == value)
                    {
                        currNode.value = new Tuple<int, string>(value, name);
                        return;
                    }
                }
             
                Node newNode = new Node(value, name);
                newNode.next = head.next;
                head.next = newNode;
            }

            public void Remove(int value)
            {
                if (head.next == null)
                    return;

                Node prevNode = head;
                Node node = head.next;

                while(!(node.next == null))
                {
                    if (node.value.Item1 == value)
                        break;

                    prevNode = node;
                    node = node.next;
                }

                if(node.value.Item1 == value)
                {
                    prevNode.next = node.next;
                }
            }

            public string Find(int value)
            {
                string ret = "not found";

                if(head.next != null)
                {
                    Node currNode = head.next;

                    while(currNode != null)
                    {
                        if (currNode.value.Item1 == value)
                            return currNode.value.Item2;

                        currNode = currNode.next;
                    }
                }

                return ret;
            }

            public void Print()
            {
                if (head.next == null)
                {
                    Console.WriteLine();
                    return;
                }

                Node t = head.next;

                while(t.next != null)
                {
                    Console.Write(t.value + " ");
                    t = t.next;
                }

                Console.Write(t.value);
                Console.WriteLine();
            }
        }
        
        public class HashTable
        {
            public int p;
            public int m;
            public int a = 34;
            public int b = 2;

            public List<LinkedList> hash;

            public HashTable(int p, int m, int a, int b)
            {
                this.p = p;
                this.m = m;
                this.a = a;
                this.b = b;

                hash = new List<LinkedList>();

                for (int i = 0; i < m; ++i)
                    hash.Add(new LinkedList());
            }

            public int CalculatreHash(int value)
            {
                return (value * a + b) % p % m;
            }

            public void Add(int value, string name)
            {
                int index = CalculatreHash(value);
                hash[index].Add(value, name);
            }

            public void Remove(int value)
            {
                int index = CalculatreHash(value);
                hash[index].Remove(value);       
            }

            public string Find(int value)
            {
                int index = CalculatreHash(value);
                return hash[index].Find(value);
            }
        }
    }
}
