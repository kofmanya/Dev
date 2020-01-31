using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergingTables
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(new char[] { ' ' });

            int n = Convert.ToInt32(str[0]);
            int m = Convert.ToInt32(str[1]);

            str = Console.ReadLine().Split(new char[] { ' ' });

            List<int> rowsCount = new List<int>();

            for(int i = 0; i < n; ++i)
            {
                rowsCount.Add(Convert.ToInt32(str[i]));
            }

            List<Tuple<int, long>> ds = new List<Tuple<int, long>>();
            List<int> rank = new List<int>();

            long max = 0;

            for(int i = 0; i < n; ++i)
            {
                ds.Add(new Tuple<int, long>(i, rowsCount[i]));
                rank.Add(0);
                max = Math.Max(max, rowsCount[i]);
            }

            for(int i = 0; i < m; ++i)
            {
                str = Console.ReadLine().Split(new char[] { ' ' });

                int d = Convert.ToInt32(str[0]) - 1;
                int s = Convert.ToInt32(str[1]) - 1;

                int parent = Union(ref ds, ref rank, d, s);

                if(parent != -1)
                    max = Math.Max(max, ds[parent].Item2);

                Console.WriteLine(max);
            }

            Console.ReadLine();
        }

        public static int Find(ref List<Tuple<int, long>> ds, int i)
        {
            if (i != ds[i].Item1)
                ds[i] = new Tuple<int, long>(Find(ref ds, ds[i].Item1), ds[i].Item2);

            return ds[i].Item1;
        }

        public static int Union(ref List<Tuple<int, long>> ds, ref List<int> rank, int i, int j)
        {
            if (i == j)
                return -1;

            int iId = Find(ref ds, i);
            int jId = Find(ref ds, j);

            if (iId == jId)
                return iId;

            if (rank[iId] > rank[jId])
            {
                ds[jId] = new Tuple<int, long>(iId, ds[jId].Item2);
                ds[iId] = new Tuple<int, long>(ds[iId].Item1, ds[iId].Item2 + ds[jId].Item2);

                return iId;
            }
            else
            {
                ds[iId] = new Tuple<int, long>(jId, ds[iId].Item2);
                ds[jId] = new Tuple<int, long>(ds[jId].Item1, ds[iId].Item2 + ds[jId].Item2);
                
                if (rank[iId] == rank[jId])
                {
                    rank[jId]++;
                }

                return jId;
            }
        }
    }
}
