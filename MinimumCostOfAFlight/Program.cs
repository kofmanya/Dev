using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumCostOfAFlight
{
    class Program
    {
        public static int inf = 999999999;
        public static List<int> dist = new List<int>();
        public static List<bool> used = new List<bool>();
        static void Main(string[] args)
        {
            Tuple<int, int> p = GetPair();

            int n = p.Item1;
            int m = p.Item2;

            List<List<Tuple<int, int>>> gr = new List<List<Tuple<int, int>>>();

            for(int i = 0; i < n; ++i)
            {
                gr.Add(new List<Tuple<int, int>>());
                dist.Add(inf);
                used.Add(false);
            }

            int u = -1;
            int v = -1;
            int w = -1;

            for(int i = 0; i < m; ++i)
            {
                Tuple<int, int, int> edge = GetTriple();

                u = edge.Item1 - 1;
                v = edge.Item2 - 1;
                w = edge.Item3;

                gr[u].Add(new Tuple<int, int>(v, w));
            }

            p = GetPair();
            u = p.Item1 - 1;
            v = p.Item2 - 1;

            dist[u] = 0;

            for(int i = 0; i < n; ++i)
            {
                int currV = GetMin();

                if (currV == -1)
                    break;

                used[currV] = true;

                for(int j = 0; j < gr[currV].Count; ++j)
                {
                    dist[gr[currV][j].Item1] = Math.Min(dist[gr[currV][j].Item1], dist[currV] + gr[currV][j].Item2);
                }

                if (currV == v)
                    break;
            }

            Console.WriteLine(used[v] ? dist[v] : -1);
            Console.ReadLine();
        }

        public static Tuple<int, int> GetPair()
        {
            string[] str = Console.ReadLine().Split(new char[] { ' ' });

            return new Tuple<int, int>(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]));
        }

        public static Tuple<int, int, int> GetTriple()
        {
            string[] str = Console.ReadLine().Split(new char[] { ' ' });

            return new Tuple<int, int, int>(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]), Convert.ToInt32(str[2]));
        }

        public static int GetMin()
        {
            int ret = -1;
            int minValue = inf;

            for(int i = 0; i < dist.Count(); ++i)
            {
                if (!used[i] && dist[i] < minValue)
                {
                    minValue = dist[i];
                    ret = i;
                }
            }

            return ret;
        }
    }
}
