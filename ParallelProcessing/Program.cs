using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelProcessing
{
    class Program
    {
        public static List<Tuple<ulong, ulong>> res;
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(new char[] { ' ' });

            int n = Convert.ToInt32(str[0]);

            List<Tuple<ulong, ulong>> pQueue = new List<Tuple<ulong, ulong>>();
            
            for(int i = 0; i < n; ++i)
            {
                pQueue.Add(new Tuple<ulong, ulong>(0, (ulong)i));
            }

            int m = Convert.ToInt32(str[1]);

            res = new List<Tuple<ulong, ulong>>();

            str = Console.ReadLine().Split(new char[] { ' ' });

            List<ulong> times = new List<ulong>();

            for (int i = 0; i < m; ++i)
            {
                times.Add((ulong)Convert.ToInt64(str[i]));
            }

            for (int i = 0; i < m; ++i)
            {
                res.Add(pQueue[0]);
                pQueue[0] = new Tuple<ulong, ulong>(pQueue[0].Item1 + (ulong)times[i], pQueue[0].Item2);
                SiftDown(ref pQueue, 0, n);
            }

            for (int i = 0; i < m; ++i)
            {
                Console.WriteLine(res[i].Item2 + " " + res[i].Item1);
            }

            Console.ReadLine();
        }

        public static void SiftDown(ref List<Tuple<ulong, ulong>> pQueue, int i, int n)
        {
            int indexLeft = i * 2 + 1;
            int indexRight = i * 2 + 2;

            if (indexLeft < n && pQueue[indexLeft].Item1 < pQueue[i].Item1 && indexRight < n && pQueue[indexRight].Item1 < pQueue[i].Item1)
            {
                if(pQueue[indexLeft].Item1 == pQueue[indexRight].Item1)
                {
                    if(pQueue[indexLeft].Item2 < pQueue[indexRight].Item2)
                    {
                        Swap(ref pQueue, indexLeft, i);
                        SiftDown(ref pQueue, indexLeft, n);
                    }
                    else
                    {
                        Swap(ref pQueue, indexRight, i);
                        SiftDown(ref pQueue, indexRight, n);
                    }
                }
                else if (pQueue[indexLeft].Item1 < pQueue[indexRight].Item1)
                {
                    Swap(ref pQueue, indexLeft, i);
                    SiftDown(ref pQueue, indexLeft, n);
                }
                else
                {
                    Swap(ref pQueue, indexRight, i);
                    SiftDown(ref pQueue, indexRight, n);
                }
            }
            else if (indexLeft < n && pQueue[indexLeft].Item1 < pQueue[i].Item1)
            {
                Swap(ref pQueue, indexLeft, i);
                SiftDown(ref pQueue, indexLeft, n);
            }
            else if (indexRight < n && pQueue[indexRight].Item1 < pQueue[i].Item1)
            {
                Swap(ref pQueue, indexRight, i);
                SiftDown(ref pQueue, indexRight, n);
            }
            else if(indexLeft < n && indexRight < n && pQueue[indexLeft].Item1 == pQueue[i].Item1 && pQueue[indexRight].Item1 == pQueue[i].Item1)
            {
                if(pQueue[indexLeft].Item2 < pQueue[i].Item2 && pQueue[indexLeft].Item2 < pQueue[indexRight].Item2)
                {
                    Swap(ref pQueue, indexLeft, i);
                    SiftDown(ref pQueue, indexLeft, n);
                }
                else if(pQueue[indexRight].Item2 < pQueue[i].Item2 && pQueue[indexRight].Item2 < pQueue[indexLeft].Item2)
                {
                    Swap(ref pQueue, indexRight, i);
                    SiftDown(ref pQueue, indexRight, n);
                }
            }
            else if(indexLeft < n && pQueue[indexLeft].Item1 == pQueue[i].Item1 && pQueue[indexLeft].Item2 < pQueue[i].Item2)
            {
                Swap(ref pQueue, indexLeft, i);
                SiftDown(ref pQueue, indexLeft, n);
            }

            else if(indexRight < n && pQueue[indexRight].Item1 == pQueue[i].Item1 && pQueue[indexRight].Item2 < pQueue[i].Item2)
            {
                Swap(ref pQueue, indexRight, i);
                SiftDown(ref pQueue, indexRight, n);
            }
            else return;
        }

        public static void Swap(ref List<Tuple<ulong, ulong>> pQueue, int i, int j)
        {
            Tuple<ulong, ulong> tmp = pQueue[i];
            pQueue[i] = pQueue[j];
            pQueue[j] = tmp;
        }
    }
}
