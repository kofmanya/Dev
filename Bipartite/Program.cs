using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bipartite
{
    class Program
    {
        public static List<int> color = new List<int>();
        public static bool success = true;
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(new char[] { ' ' });
            int n = Convert.ToInt32(str[0]);
            int m = Convert.ToInt32(str[1]);

            List<List<int>> gr = new List<List<int>>();
            
            for(int i = 0; i < n; ++i)
            {
                gr.Add(new List<int>());

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

            for (int i = 0; i < n; ++i)
            {
                if(color[i] == -1)
                    BFS(gr, i);

                if (!success)
                    break;
            }

            Console.WriteLine(success ? 1 : 0);
            Console.ReadLine();
        }

        public static void BFS(List<List<int>> gr, int u)
        {
            color[u] = 0;

            Queue<int> q = new Queue<int>();
            q.Enqueue(u);

            while(q.Count() > 0)
            {
                u = q.Dequeue();

                for(int i = 0; i < gr[u].Count; ++i)
                {
                    if(color[gr[u][i]] == -1)
                    {
                        color[gr[u][i]] = (color[u] == 1 ? 0 : 1);
                        q.Enqueue(gr[u][i]);
                    }
                    else if(color[u] == color[gr[u][i]])
                    {
                        success = false;
                        break;
                    }
                }
            }
        }
    }
}
