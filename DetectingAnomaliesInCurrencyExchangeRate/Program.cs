using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectingAnomaliesInCurrencyExchangeRate
{
    class Program
    {
        public static List<bool> used = new List<bool>();
        public static List<int> dist = new List<int>();
        public static int inf = 999999999;

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

            for(int i = 0; i < m; ++i)
            {
                Tuple<int, int, int> t = GetTriple();

                int u = t.Item1;
                int v = t.Item2;
                int w = t.Item3;

                gr[u].Add(new Tuple<int, int>(v, w));
            }

            bool hasNegativeCircle = false;

            for(int s = 0; s < n; ++s)
            {
                Reset();
                dist[s] = 0;

                for(int i = 0; i < n; ++i)
                {
                    int currV = GetMin();

                    if (currV == -1)
                        break;

                    used[currV] = true;

                    for (int j = 0; j < gr[currV].Count; ++j)
                    {
                        dist[gr[currV][j].Item1] = Math.Min(dist[gr[currV][j].Item1], dist[currV] + gr[currV][j].Item2);
                    }

                    if(dist[s] < 0)
                    {
                        hasNegativeCircle = true;
                        break;
                    }
                }

                if (hasNegativeCircle)
                    break;
            }

            Console.WriteLine(hasNegativeCircle ? 1 : 0);
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

            return new Tuple<int, int, int>(Convert.ToInt32(str[0]) - 1, Convert.ToInt32(str[1]) - 1, Convert.ToInt32(str[2]));
        }

        public static void Reset()
        {
            for(int i = 0; i < dist.Count; ++i)
            {
                dist[i] = inf;
                used[i] = false;
            }
        }

        public static int GetMin()
        {
            int min = -1;
            int minValue = inf;

            for(int i = 0; i < dist.Count; ++i)
            {
                if(!used[i] && dist[i] < minValue)
                {
                    minValue = dist[i];
                    min = i;
                }
            }

            return min;
        }
    }
}
