using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckBracketsInTheCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            int res = Check(str);

            Console.WriteLine(res == -1 ? "Success" : res.ToString());

            Console.ReadLine();
        }

        public static int Check(string str)
        {
            int res = -1;

            int n = str.Length;

            Stack<Tuple<char, int>> st = new Stack<Tuple<char, int>>();

            for(int i = 0; i < n; ++i)
            {
                if (str[i] == '(' || str[i] == '{' || str[i] == '[')
                    st.Push(new Tuple<char, int>(str[i], i + 1));
                else if(str[i] == ')' || str[i] == '}' || str[i] == ']')
                {
                    if (st.Empty() ||
                       (str[i] == ')' && st.Top().Item1 != '(') ||
                       (str[i] == '}' && st.Top().Item1 != '{') ||
                       (str[i] == ']' && st.Top().Item1 != '['))
                    {
                        res = i + 1;
                        break;
                    }
                    else
                        st.Pop();
                }
            }

            if(res == -1 && !st.Empty())
            {
                Tuple<char, int> tmp = st.Pop();

                while (!st.Empty())
                {
                    tmp = st.Pop();
                }

                res = tmp.Item2;
            }

            return res;
        }
    }

    /// <summary>
    /// Single Node of a Stack
    /// </summary>
    public class Node<T>
    {
        public Node()
        {
            value = default(T);
            next = null;
        }
        public Node(T t)
        {
            value = t;
        }

        // Value of a Node
        public T value;
        // Pointer to the next Node
        public Node<T> next;
    }

    /// <summary>
    /// Implementation of a Stack of <T> using linked list
    /// </summary>
    public class Stack<T>
    {
        public Stack()
        {
            head = new Node<T>();
        }

        Node<T> head;

        /// <summary>
        /// Insert a new Node in a Stack
        /// </summary>
        /// <param name="c">Value</param>
        public void Push(T t)
        {
            Node<T> currNode = new Node<T>(t);

            currNode.next = head.next;

            head.next = currNode;
        }
            
        /// <summary>
        /// Return a value of a top Node
        /// </summary>
        public T Top()
        {
            return head.next == null ? default(T) : head.next.value;
        }

        /// <summary>
        /// Delete a top Node and returns its value
        /// </summary>
        public T Pop()
        {
            T ret = Top(); 
            
            head.next = head.next?.next;

            return ret;
        }

        /// <summary>
        /// Check if a Stack is Empty
        /// </summary>
        public bool Empty()
        {
            return head.next == null;
        }
    }


}
