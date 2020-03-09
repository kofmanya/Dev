using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeterminingAnOrderOfCources
{
    class Program
    {
        public static int time = 0;
        public static List<int> res = new List<int>();
        public static List<bool> used = new List<bool>();
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(new char[] { ' ' });

            int n = Convert.ToInt32(str[0]);
            int m = Convert.ToInt32(str[1]);

            List<List<int>> gr = new List<List<int>>();

            for(int i = 0; i < n; ++i)
            {
                List<int> row = new List<int>();
                gr.Add(row);

                used.Add(false);
            }

            for(int i = 0; i < m; ++i)
            {
                str = Console.ReadLine().Split(new char[] { ' ' });

                int u = Convert.ToInt32(str[0]) - 1;
                int v = Convert.ToInt32(str[1]) - 1;

                gr[u].Add(v);
            }

            for(int i = 0; i < n; ++i)
            {
                if(!used[i])
                {
                    DFS(gr, i);
                }
            }

            for(int i = n - 1; i >= 0; --i)
            {
                Console.Write((res[i] + 1) + " ");
            }

            Console.WriteLine();
            Console.ReadLine();
        }

        public static void DFS(List<List<int>> gr, int v)
        {
            used[v] = true;

            for(int i = 0; i < gr[v].Count(); ++i)
            {
                if (!used[gr[v][i]])
                {
                    DFS(gr, gr[v][i]);
                }
            }

            res.Add(v);
        }
    }
}
