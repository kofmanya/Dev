using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsItABinarySearchTree
{
    class Program
    {
        public static List<int> t = new List<int>();

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            List<Tuple<int, int, int>> v = new List<Tuple<int, int, int>>();

            for(int i = 0; i < n; ++i)
            {
                string[] str = Console.ReadLine().Split(new char[] { ' ' });

                v.Add(new Tuple<int, int, int>(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]), Convert.ToInt32(str[2])));
            }

            if(n != 0)
                Dfs(v, 0);

            bool correct = true;

            for(int i = 1; i < n; ++i)
            {
                if(t[i] < t[i - 1])
                {
                    correct = false;
                    break;
                }
            }

            Console.WriteLine(correct ? "CORRECT" : "INCORRECT");
            Console.ReadLine();
        }

        public static void Dfs(List<Tuple<int, int, int>> v, int i)
        {
            if (i == -1)
                return;

            Dfs(v, v[i].Item2);
            
            t.Add(v[i].Item1);
            
            Dfs(v, v[i].Item3);
        }
    }
}
