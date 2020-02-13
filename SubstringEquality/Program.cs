using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringEquality
{
    class Program
    {
        public static long p1 = 100000007;
        public static long p2 = 100000009;
        public static long x = 31;
        public static List<long> powerX1;
        public static List<long> powerX2;

        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            FillPower(ref powerX1, str.Length, p1);
            FillPower(ref powerX2, str.Length, p2);

            List<long> hash1 = new List<long>();
            List<long> hash2 = new List<long>();
            
            CalculateHash(str, ref hash1, p1);
            CalculateHash(str, ref hash2, p2);

            int n = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < n; ++i)
            {
                string[] s = Console.ReadLine().Split(new char[] { ' ' });

                int a = Convert.ToInt32(s[0]);
                int b = Convert.ToInt32(s[1]);
                int l = Convert.ToInt32(s[2]);

                long hash1A = CalculateSubstringHash(hash1, a, l, p1);
                long hash1B = CalculateSubstringHash(hash1, b, l, p1);

                long hash2A = CalculateSubstringHash(hash2, a, l, p2);
                long hash2B = CalculateSubstringHash(hash2, b, l, p2);

                if (hash1A == hash1B && hash2A == hash2B)
                    Console.WriteLine("Yes");
                else
                    Console.WriteLine("No");
            }

            Console.ReadLine();
        }

        public static void FillPower(ref List<long> powerX, int n, long p)
        {
            powerX = new List<long>();
            powerX.Add(1);

            for (int i = 1; i <= n; ++i)
            {
                powerX.Add(powerX[i - 1] * x % p);
            }
        }

        public static void CalculateHash(string s, ref List<long> res, long p)
        {
            res.Add(0);

            for(int i = 1; i <= s.Length; ++i)
            {
                res.Add((res[i - 1] * x % p + (long)s[i - 1]) % p);
            }
        }

        public static long CalculateSubstringHash(List<long> hash, int a, int l, long p)
        {
            return (hash[a + l] + p - (p == p1 ? powerX1[l] : powerX2[l]) * hash[a] % p) % p;
        }
    }
}
