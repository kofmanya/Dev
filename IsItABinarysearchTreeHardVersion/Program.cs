using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsItABinarysearchTreeHardVersion
{
    class Program
    {
        public static List<int> t = new List<int>();
        public static List<int> depths = new List<int>();
        
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            List<Tuple<int, int, int>> v = new List<Tuple<int, int, int>>();

            for (int i = 0; i < n; ++i)
            {
                string[] str = Console.ReadLine().Split(new char[] { ' ' });

                v.Add(new Tuple<int, int, int>(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]), Convert.ToInt32(str[2])));
            }

            if (n != 0)
            {
                Dfs(v, 0, 0);
            }

            bool correct = true;

            for (int i = 1; i < t.Count; ++i)
            {
                if (t[i] < t[i - 1] || (t[i] == t[i - 1] && depths[i] < depths[i - 1]))
                {
                    correct = false;
                    break;
                }
            }

            Console.WriteLine(correct ? "CORRECT" : "INCORRECT");
            Console.ReadLine();
        }

        public static void Dfs(List<Tuple<int, int, int>> v, int i, int depth)
        {
            if (i == -1)
            {
                return;
            }

            depth += 1;

            Dfs(v, v[i].Item2, depth);

            t.Add(v[i].Item1);
            depths.Add(depth - 1);

            Dfs(v, v[i].Item3, depth);
        }
    }
}
