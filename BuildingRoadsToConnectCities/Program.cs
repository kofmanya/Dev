using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingRoadsToConnectCities
{
    class Program
    {
        static void Main(string[] args)
        {
            double inf = 999999999;
            int n = Convert.ToInt32(Console.ReadLine());
            List<Tuple<int, int>> points = new List<Tuple<int, int>>();
            List<bool> used = new List<bool>();
            List<double> minEdge = new List<double>();
            List<int> selected = new List<int>();

            for(int i = 0; i < n; ++i)
            {
                string[] str = Console.ReadLine().Split(new char[] { ' ' });
                points.Add(new Tuple<int, int> (Convert.ToInt32(str[0]), Convert.ToInt32(str[1])));
                used.Add(false);
                minEdge.Add(inf);
                selected.Add(-1);
            }

            List<List<double>> gr = new List<List<double>>();

            for(int i = 0; i < n; ++i)
            {
                gr.Add(new List<double>());

                for(int j = 0; j < n; ++j)
                {
                    gr[i].Add(Math.Sqrt((points[i].Item1 - points[j].Item1) * (points[i].Item1 - points[j].Item1) + (points[i].Item2 - points[j].Item2) * (points[i].Item2 - points[j].Item2)));
                }
            }

            double res = 0;
            minEdge[0] = 0;

            for(int i = 0; i < n; ++i)
            {
                int v = -1;

                for(int j = 0; j < n; ++j)
                {
                    if (!used[j] && (v == -1 || minEdge[j] < minEdge[v]))
                    {
                        v = j;
                    }
                }

                used[v] = true;

                if (selected[v] != -1)
                {
                    res += gr[v][selected[v]];
                }

                for(int j = 0; j < n; ++j)
                {
                    if(gr[v][j] < minEdge[j])
                    {
                        minEdge[j] = gr[v][j];
                        selected[j] = v;
                    }
                }
            }

            Console.WriteLine("{0:0.0000000}", res);
            Console.ReadLine();
        }
    }
}
