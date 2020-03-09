using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumNumberOfFlightSegments
{
    class Program
    {
        public static List<int> dist = new List<int>();
        static void Main(string[] args)
        {
            int u = 0;
            int v = 0;

            string[] str = Console.ReadLine().Split(new char[] { ' ' });

            int n = Convert.ToInt32(str[0]);
            int m = Convert.ToInt32(str[1]);

            List<List<int>> gr = new List<List<int>>();

            for (int i = 0; i < n; ++i)
            {
                gr.Add(new List<int>());
                dist.Add(-1);
            }

            for (int i = 0; i < m; ++i)
            {
                str = Console.ReadLine().Split(new char[] { ' ' });

                u = Convert.ToInt32(str[0]) - 1;
                v = Convert.ToInt32(str[1]) - 1;

                gr[u].Add(v);
                gr[v].Add(u);
            }

            str = Console.ReadLine().Split(new char[] { ' ' });
            u = Convert.ToInt32(str[0]) - 1;
            v = Convert.ToInt32(str[1]) - 1;

            BFS(gr, u, v);

            Console.WriteLine(dist[v]);
            Console.ReadLine();
        }

        public static void BFS(List<List<int>> gr, int u, int v)
        {
            dist[u] = 0;

            Queue<int> q = new Queue<int>();
            q.Enqueue(u);

            while(q.Count() > 0)
            {
                if (dist[v] != -1)
                    break;

                int currV = q.Dequeue();

                for(int i = 0; i < gr[currV].Count; ++i)
                {
                    if (dist[gr[currV][i]] == -1)
                    {
                        q.Enqueue(gr[currV][i]);
                        dist[gr[currV][i]] = dist[currV] + 1;
                    }
                }
            }
        }
    }
}
