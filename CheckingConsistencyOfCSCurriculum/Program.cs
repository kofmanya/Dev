using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckingConsistencyOfCSCurriculum
{
    class Program
    {
        public static List<int> color = new List<int>();
       
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(new char[] { ' ' });

            int n = Convert.ToInt32(str[0]);
            int m = Convert.ToInt32(str[1]);

            List<List<int>> gr = new List<List<int>>();

            for(int i = 0; i < n; ++i)
            {
                List<int> row = new List<int>();
                gr.Add(row);

                color.Add(-1);
            }

            for(int i = 0; i < m; ++i)
            {
                str = Console.ReadLine().Split(new char[] { ' ' });

                int u = Convert.ToInt32(str[0]) - 1;
                int v = Convert.ToInt32(str[1]) - 1;

                gr[u].Add(v);
            }

            bool findCircle = false;

            for(int i = 0; i < n; ++i)
            {
                if(color[i] == -1)
                {
                    findCircle = DFS(gr, i);

                    if (findCircle)
                        break;
                }
            }

            Console.WriteLine(findCircle ? 1 : 0);
            Console.ReadLine();
        }

        public static bool DFS(List<List<int>> gr, int v)
        {
            if (color[v] == 1)
                return true;

            color[v] = 1;

            for(int i = 0; i < gr[v].Count; ++i)
            {
                if (DFS(gr, gr[v][i]))
                    return true;
            }

            color[v] = 2;
            return false;
        }
    }
}
