using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeHeap
{
    class Program
    {
        public static List<Tuple<int, int>> res;

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            List<int> numbers = new List<int>();

            string[] str = Console.ReadLine().Split(new char[] { ' ' });

            for(int i = 0; i < n; ++i)
            {
                numbers.Add(Convert.ToInt32(str[i]));
            }

            res = new List<Tuple<int, int>>(); 

            for(int i = n / 2 + 1; i >= 0; --i)
            {
                SiftDown(ref numbers, i, n);
            }

            Console.WriteLine(res.Count());

            for(int i = 0; i < res.Count(); ++i)
            {
                Console.WriteLine(res[i].Item1 + " " + res[i].Item2);
            }

            Console.ReadLine();
        }

        public static void SiftDown(ref List<int> numbers, int index, int n)
        {
            int indexLeft = (index + 1) * 2 - 1;
            int indexRight = (index + 1) * 2;

            if (indexLeft < n && numbers[indexLeft] < numbers[index] && indexRight < n && numbers[indexRight] < numbers[index])
            {
                if (numbers[indexLeft] < numbers[indexRight])
                {
                    Swap(ref numbers, indexLeft, index);
                    res.Add(new Tuple<int, int>(indexLeft, index));
                    SiftDown(ref numbers, indexLeft, n);
                }
                else
                {
                    Swap(ref numbers, indexRight, index);
                    res.Add(new Tuple<int, int>(indexRight, index));
                    SiftDown(ref numbers, indexRight, n);
                }
            }
            else if (indexLeft < n && numbers[indexLeft] < numbers[index])
            {
                Swap(ref numbers, indexLeft, index);
                res.Add(new Tuple<int, int>(indexLeft, index));
                SiftDown(ref numbers, indexLeft, n);
            }
            else if (indexRight < n && numbers[indexRight] < numbers[index])
            {
                Swap(ref numbers, indexRight, index);
                res.Add(new Tuple<int, int>(indexRight, index));
                SiftDown(ref numbers, indexRight, n);
            }
            else return;
        }

        public static void SiftUp(ref List<int> numbers, int index)
        {
            int parentIndex = index / 2;

            if (numbers[parentIndex] > numbers[index])
            {
                Swap(ref numbers, parentIndex, index);
                res.Add(new Tuple<int, int>(parentIndex, index));
                SiftUp(ref numbers, parentIndex);
            }
            else
                return;
        }
             

        public static void Swap(ref List<int> numbers, int i, int j)
        {
            int tmp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = tmp;
        }
    }
}
