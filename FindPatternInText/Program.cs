using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPatternInText
{
    class Program
    {
        static void Main(string[] args)
        {
            long p = 10000000007;
            long x = 31;
            long y = 1;

            string pattern = Console.ReadLine();
            string text = Console.ReadLine();

            int pLength = pattern.Length;
            int tLength = text.Length;

            for(int i = 0; i < pLength; ++i)
            {
                y = (y * x) % p;
                //y %= p;
            }

            long patternHash = PolyHash(pattern, p, x);

            List<long> hashList = new List<long>();

            for(int i = 0; i < tLength - pLength + 1; ++i)
            {
                hashList.Add(0);
            }

            hashList[tLength - pLength] = PolyHash(text.Substring(tLength - pLength), p, x);

            for(int i = tLength - pLength - 1; i >= 0; --i)
            {
                hashList[i] = ((x * hashList[i + 1]) % p + (long)text[i] - (y * (long)text[i + pLength]) % p + p) % p;
            }

            for(int i = 0; i < hashList.Count(); ++i)
            {
                if (patternHash == hashList[i] && AreEqual(pattern, text.Substring(i, pLength)))
                    Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.ReadLine();
        }

        public static long PolyHash(string str, long p, long x)
        {
            long ret = 0;

            long xi = 1;
            
            for(int i = 0; i < str.Length; ++i)
            {
                ret += ((long)str[i] * xi) % p;

                xi *= x;
                xi %= p;
            }

            return ret % p;
        }

        public static bool AreEqual(string p, string s)
        {
            if (p.Length != s.Length)
                return false;

            for(int i = 0; i < p.Length; ++i)
            {
                if (p[i] != s[i])
                    return false;
            }

            return true;
        }
    }
}
