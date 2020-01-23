using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkPacketProcessingSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(new char[] { ' ' });

            int s = Convert.ToInt32(str[0]);
            int n = Convert.ToInt32(str[1]);

            List<Packet> packets = new List<Packet>();
            
            for(int i = 0; i < n; ++i)
            {
                str = Console.ReadLine().Split(new char[] { ' ' });
                
                packets.Add(new Packet (i, Convert.ToInt32(str[0]), Convert.ToInt32(str[1])));
            }

            List<long> res = new List<long>();

            for (int i = 0; i < n; ++i)
                res.Add(-1);

            long currTime = 0;

            Queue<Packet> q = new Queue<Packet>();

            for(int i = 0; i < n; ++i)
            {
                while (!q.Empty() && currTime + q.Peek().processingTime <= packets[i].arrivalTime)
                    ProcessPacket(q.Dequeue(), ref currTime, ref res);
                
                if (q.Count() < s)
                    q.Enqueue(packets[i]);
            }

            while (!q.Empty())
                ProcessPacket(q.Dequeue(), ref currTime, ref res);
            
            for (int i = 0; i < n; ++i)
                Console.WriteLine(res[i]);

            Console.ReadLine();
        }

        public static void ProcessPacket(Packet tmp, ref long currTime, ref List<long> res)
        {
            currTime = Math.Max(currTime, tmp.arrivalTime);

            res[tmp.index] = currTime;

            currTime += tmp.processingTime;
        }

        public struct Packet
        {
            public int index;
            public int arrivalTime;
            public int processingTime; 

            public Packet(int index, int arrivalTime, int processingTime)
            {
                this.index = index;
                this.arrivalTime = arrivalTime;
                this.processingTime = processingTime;
            }
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
            int count;

            public Queue()
            {
                head = null;
                tail = null;
                count = 0;
            }

            public void Enqueue(T t)
            {
                if (head == null)
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

                count++;
            }

            public T Dequeue()
            {
                if (Empty())
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

                count--;

                return node.value;
            }

            public T Peek()
            {
                if (Empty())
                    return default(T);

                return head.next.value;
            }

            public int Count()
            {
                return count;
            }

            public bool Empty()
            {
                return head == null;
            }
        }
    }
}
