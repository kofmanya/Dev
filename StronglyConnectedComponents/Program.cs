using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StronglyConnectedComponents
{
    class Program
    {
        public static List<bool> used = new List<bool>();
        public static List<int> res = new List<int>();
        public static int count = 0;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(new char[] { ' ' });

            int n = Convert.ToInt32(str[0]);
            int m = Convert.ToInt32(str[1]);

            List<List<int>> gr = new List<List<int>>();
            List<List<int>> grt = new List<List<int>>();

            for (int i = 0; i < n; ++i)
            {
                gr.Add(new List<int>());
                grt.Add(new List<int>());

                used.Add(false);
            }

            for(int i = 0; i < m; ++i)
            {
                str = Console.ReadLine().Split(new char[] { ' ' });

                int u = Convert.ToInt32(str[0]) - 1;
                int v = Convert.ToInt32(str[1]) - 1;

                gr[u].Add(v);
                grt[v].Add(u);
            }

            for(int i = 0; i < n; ++i)
            {
                if (!used[i])
                    DFS(gr, i);
            }

            for (int i = 0; i < n; ++i)
                used[i] = false;

            for(int i = n - 1; i >= 0; --i)
            {
                if(!used[res[i]])
                {
                    DFSComponent(grt, res[i]);
                    count++;
                }
            }

            Console.WriteLine(count);
            Console.ReadLine();
        }

        public static void DFS(List<List<int>> gr, int v)
        {
            used[v] = true;

            for(int i = 0; i < gr[v].Count; ++i)
            {
                if (!used[gr[v][i]])
                    DFS(gr, gr[v][i]);
            }

            res.Add(v);
        }

        public static void DFSComponent(List<List<int>> gr, int v)
        {
            used[v] = true;

            for(int i = 0; i < gr[v].Count; ++i)
            {
                if (!used[gr[v][i]])
                    DFSComponent(gr, gr[v][i]);
            }
        }
    }
}
