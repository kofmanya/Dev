using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddingExitToAMaze
{
    class Program
    {
        public static List<int> color = new List<int>();

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

                color.Add(-1);
            }

            for(int i = 0; i < m; ++i)
            {
                str = Console.ReadLine().Split(new char[] { ' ' });

                int u = Convert.ToInt32(str[0]) - 1;
                int v = Convert.ToInt32(str[1]) - 1;

                gr[u].Add(v);
                gr[v].Add(u);
            }

            int c = 1;

            for(int i = 0; i < n; ++i)
            {
                if(color[i] == -1)
                {
                    DFS(gr, i, c);
                    c++;
                }
            }

            Console.WriteLine(c - 1);
            Console.ReadLine();
        }

        public static void DFS(List<List<int>> gr, int v, int c)
        {
            color[v] = c;

            for(int i = 0; i < gr[v].Count; ++i)
            {
                if(color[gr[v][i]] == -1)
                {
                    DFS(gr, gr[v][i], c);
                }
            }
        }
    }
}
