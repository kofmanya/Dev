using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            List<Tuple<int, int>> points = new List<Tuple<int, int>>(); 

            for(int i = 0; i < n; ++i)
            {
                string[] str = Console.ReadLine().Split(new char[] { ' ' });
                points.Add(new Tuple<int, int>(Convert.ToInt32(str[0]), Convert.ToInt32(str[1])));
            }

            int s = Convert.ToInt32(Console.ReadLine());

            List<int> p = new List<int>();
            List<List<int>> l = new List<List<int>>();

            for(int i = 0; i < n; ++i)
            {
                p.Add(i);
                l.Add(new List<int>() { i });
            }

            List<Tuple<double, int, int>> edges = new List<Tuple<double, int, int>>();

            for(int i = 0; i < n; ++i)
            {
                for(int j = i + 1; j < n; ++j)
                {
                    double dist = Math.Sqrt((points[i].Item1 - points[j].Item1) * (points[i].Item1 - points[j].Item1) + (points[i].Item2 - points[j].Item2) * (points[i].Item2 - points[j].Item2));
                    edges.Add(new Tuple<double, int, int>(dist, i, j));
                }
            }

            edges = edges.OrderBy(e => e.Item1).ToList();

            int groupsCount = n;
            int lastIndex = 0;

            for(int i = 0; i < edges.Count; ++i)
            {
                if (groupsCount == s)
                    break;

                int left = edges[i].Item2;
                int right = edges[i].Item3;
                
                if(p[left] != p[right])
                {
                    Union(ref p, ref l, left, right);
                    groupsCount--;
                    lastIndex = i;
                }
            }

            double res = edges[lastIndex].Item1;

            for (int i = lastIndex + 1; i < edges.Count; ++i)
            {
                int left = edges[i].Item2;
                int right = edges[i].Item3;

                if (p[left] != p[right])
                {
                    res = edges[i].Item1;
                    break;
                }
            }

            Console.WriteLine("{0:0.0000000}", res);
            Console.ReadLine();
        }

        public static void Union(ref List<int> p, ref List<List<int>> l, int i, int j)
        {
            int left = p[i];
            int right = p[j];

            if(l[left].Count > l[right].Count)
            {
                l[left].AddRange(l[right]);

                for (int k = 0; k < l[right].Count; ++k)
                    p[l[right][k]] = left;

            }
            else
            {
                l[right].AddRange(l[left]);

                for (int k = 0; k < l[left].Count; ++k)
                    p[l[left][k]] = right;
            }

            //if(l[i].Count > l[j].Count)
            //{
            //    l[i].AddRange(l[j]);

            //    for (int k = 0; k < l[j].Count; ++k)
            //        p[l[j][k]] = p[i];
            //}
            //else
            //{
            //    l[j].AddRange(l[i]);

            //    for (int k = 0; k < l[i].Count; ++k)
            //        p[l[i][k]] = p[j];
            //}
        }
    }
}
