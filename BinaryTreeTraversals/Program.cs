using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTraversals
{
    class Program
    {
        public static string inOrder = "";
        public static string preOrder = "";
        public static string postOrder = "";
        public static StringBuilder sb = new StringBuilder("");
        
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            List<Tuple<int, int, int>> vertices = new List<Tuple<int, int, int>>(); 

            for(int i = 0; i < n; ++i)
            {
                string[] str = Console.ReadLine().Split(new char[] { ' ' });

                vertices.Add(new Tuple<int, int, int>(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]), Convert.ToInt32(str[2])));
            }

            InOrderTraversal(vertices, 0);
            Console.WriteLine(sb);
            sb = new StringBuilder();

            PreOrderTravrsal(vertices, 0);
            Console.WriteLine(sb);
            sb = new StringBuilder();

            PostOrderTraversal(vertices, 0);
            Console.WriteLine(sb);
            
            Console.ReadLine();
        }

        public static void InOrderTraversal(List<Tuple<int, int, int>> v, int i)
        {
            if (i == -1)
                return;

            InOrderTraversal(v, v[i].Item2);
            sb.Append(v[i].Item1 + " ");
            InOrderTraversal(v, v[i].Item3);
        }

        public static void PreOrderTravrsal(List<Tuple<int, int, int>> v, int i)
        {
            if (i == -1)
                return;

            sb.Append(v[i].Item1 + " ");
            PreOrderTravrsal(v, v[i].Item2);
            PreOrderTravrsal(v, v[i].Item3);
        }

        public static void PostOrderTraversal(List<Tuple<int, int, int>> v, int i)
        {
            if (i == -1)
                return;

            PostOrderTraversal(v, v[i].Item2);
            PostOrderTraversal(v, v[i].Item3);
            sb.Append(v[i].Item1 + " ");
        }
    }
}
