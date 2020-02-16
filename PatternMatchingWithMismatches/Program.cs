using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatchingWithMismatches
{
    class Program
    {
        public static long p = 1000000007;
        public static long x = 31;
        public static List<long> powerX = new List<long>();

        static void Main(string[] args)
        {
            FillPower();

            string[] str = Console.ReadLine().Split(new char[] { ' ' });
            
            while(str.Length > 1)
            {
                int k = Convert.ToInt32(str[0]);
                
                int n = str[1].Length;
                int m = str[2].Length;

                List<long> hashT = CalculateHash(str[1]);
                List<long> hashP = CalculateHash(str[2]);

                List<int> res = new List<int>();

                for (int i = 0; i <= n - m; ++i)
                {
                    int indexT = i;
                    int indexP = 0;

                    int countMismatches = 0;

                    while(indexP < m)
                    {
                        int currentLength = LargestCommonPrefix(hashT, hashP, indexT, indexP);

                        if(currentLength == 0)
                        {
                            indexT++;
                            indexP++;
                            countMismatches++;
                        }
                        else
                        {
                            indexT += currentLength;
                            indexP += currentLength;
                        }

                        if (countMismatches > k)
                            break;
                    }

                    if (countMismatches <= k)
                        res.Add(i);
                     
                }

                Console.Write(res.Count() + " ");
                for(int i = 0; i < res.Count(); ++i)
                {
                    Console.Write(res[i] + " ");
                }
                Console.WriteLine();

                str = Console.ReadLine().Split(new char[] { ' ' });
            }
        }

        public static void FillPower()
        {
            powerX.Add(1);

            for(int i = 1; i <= 200000; ++i)
            {
                powerX.Add(powerX[i - 1] * x % p);
            }
        }

        public static List<long> CalculateHash(string str)
        {
            List<long> ret = new List<long>();
            ret.Add(0);

            for(int i = 1; i <= str.Length; ++i)
            {
                ret.Add((ret[i - 1] * x % p + (long)str[i - 1]) % p);
            }

            return ret;
        }

        public static long CalculateSubstringHash(List<long> hash, int a, int l)
        {
            return (hash[a + l] + p - powerX[l] * hash[a] % p) % p;
        }

        public static int LargestCommonPrefix(List<long> hashT, List<long> hashP, int indexT, int indexP)
        {
            int left = 0;
            int right = hashP.Count() - indexP;

            while(right - left > 1)
            {
                int middle = (left + right) / 2;

                long middleHashT = CalculateSubstringHash(hashT, indexT, middle);
                long middleHashP = CalculateSubstringHash(hashP, indexP, middle);

                if(middleHashT == middleHashP)
                {
                    left = middle;
                }
                else
                {
                    right = middle;
                }
            }

            return left;
        }
    }
}
