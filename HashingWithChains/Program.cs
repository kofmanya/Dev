using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashingWithChains
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = Convert.ToInt32(Console.ReadLine());
            int n = Convert.ToInt32(Console.ReadLine());

            HashTable ht = new HashTable(1000000007, m, 263);

            for (int i = 0; i < n; ++i)
            {
                string[] str = Console.ReadLine().Split(new char[] { ' ' });

                if (str[0] == "add")
                {
                    ht.Add(str[1]);
                }
                else if (str[0] == "del")
                {
                    ht.Remove(str[1]);
                }
                else if(str[0] == "find")
                {
                    Console.WriteLine(ht.Find(str[1]));
                }
                else
                {
                    ht.Check(Convert.ToInt32(str[1]));
                }
            }

            Console.ReadLine();
        }

        public class Node
        {
            public Node()
            {
                this.value = null;
            }

            public Node(string value)
            {
                this.value = value;
            }

            public string value;
            public Node next;
        }

        public class LinkedList
        {
            public Node head;

            public LinkedList()
            {
                this.head = new Node();
            }

            public void Add(string value)
            {
                Node newNode = new Node(value);
                
                if(head.next != null)
                {
                    Node currNode = head.next;
                    head.next = newNode;
                    newNode.next = currNode;
                }
                else
                {
                    head.next = newNode;
                }
            }

            public void Remove(string value)
            {
                if(head.next != null)
                {
                    Node prevNode = head;
                    Node currNode = prevNode.next;

                    while(currNode != null)
                    {
                        if(currNode.value == value)
                        {
                            prevNode.next = currNode.next;
                            return;
                        }

                        prevNode = currNode;
                        currNode = currNode.next;
                    }
                }
            }

            public string Find(string value)
            {
                string ret = "no";

                Node currNode = head.next;

                while(currNode != null)
                {
                    if(currNode.value == value)
                    {
                        ret = "yes";
                        break;
                    }

                    currNode = currNode.next;
                }

                return ret;
            }

            public void Print()
            {
                if(head.next == null)
                {
                    Console.WriteLine();
                    return;
                }

                Node currNode = head.next;

                while(currNode != null)
                {
                    Console.Write(currNode.value + " ");
                    currNode = currNode.next;
                }

                Console.WriteLine();
            }
        }


        public class HashTable
        {
            int p;
            int m;
            int x;

            List<LinkedList> hash;

            public HashTable(int p, int m, int x)
            {
                this.p = p;
                this.m = m;
                this.x = x;

                this.hash = new List<LinkedList>();

                for(int i = 0; i < m; ++i)
                {
                    hash.Add(new LinkedList());
                }
            }

            public int CalculateHash(string value)
            {
                long res = 0;
                long xPowerMod = 1;

                for(int i = 0; i < value.Length; ++i)
                {
                    res += ((long)value[i] * xPowerMod) % p;
                    res %= p;
                    
                    xPowerMod *= x;
                    xPowerMod %= p;
                }

                return (int)(res %= m);
            }

            public void Add(string value)
            {
                if (Find(value) == "yes")
                    return;

                int index = CalculateHash(value);
                hash[index].Add(value);
            }

            public void Remove(string value)
            {
                int index = CalculateHash(value);
                hash[index].Remove(value);
            }

            public string Find(string value)
            {
                int index = CalculateHash(value);
                return hash[index].Find(value);
            }

            public void Check(int i)
            {
                hash[i].Print();
            }
        }
    }
}
