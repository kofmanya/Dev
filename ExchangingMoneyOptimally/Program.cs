using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangingMoneyOptimally
{
    class Program
    {
        public static List<bool> used = new List<bool>();
        public static List<long> dist = new List<long>();
        public static long inf = long.MaxValue;
        public static long antiInf = long.MinValue;
        static void Main(string[] args)
        {
            Tuple<int, int> p = GetPair();
            int n = p.Item1;
            int m = p.Item2;
            Reset(n);

            List<List<Tuple<int, int>>> gr = new List<List<Tuple<int, int>>>();

            for(int i = 0; i < n; ++i)
            {
                gr.Add(new List<Tuple<int, int>>());
            }

            for(int i = 0; i < m; ++i)
            {
                Tuple<int, int, int> t = GetTriple();

                gr[t.Item1].Add(new Tuple<int, int>(t.Item2, t.Item3));
            }

            int s = Convert.ToInt32(Console.ReadLine()) - 1;

            List<long> res = new List<long>();

            dist[s] = 0;

            List<int> x = new List<int>();

            for (int t = 0; t < n; ++t)
            {
                x = new List<int>();

                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < gr[i].Count; ++j)
                    {
                        if (dist[i] < inf && dist[gr[i][j].Item1] > dist[i] + gr[i][j].Item2)
                        {
                            dist[gr[i][j].Item1] = dist[i] + gr[i][j].Item2;
                            x.Add(gr[i][j].Item1);
                        }
                    }
                }
            }

            if (x.Count() > 0)
            {
                Queue<int> q = new Queue<int>();

                for (int i = 0; i < x.Count(); ++i)
                    q.Enqueue(x[i]);

                while (q.Count != 0)
                {
                    int currV = q.Dequeue();
                    used[currV] = true;
                    dist[currV] = antiInf;

                    for (int j = 0; j < gr[currV].Count; ++j)
                    {
                        if (!used[gr[currV][j].Item1])
                            q.Enqueue(gr[currV][j].Item1);
                    }
                }
            }

            for(int i = 0; i < n; ++i)
            {
                if(dist[i] == antiInf)
                {
                    Console.WriteLine("-");
                }
                else if(dist[i] == inf)
                {
                    Console.WriteLine("*");
                }
                else
                {
                    Console.WriteLine(dist[i]);
                }
            }

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

        public static void Reset(int n)
        {
            used = new List<bool>();
            dist = new List<long>();

            for (int i = 0; i < n; ++i)
            {
                used.Add(false);
                dist.Add(inf);
            }            
        }
    }
}
