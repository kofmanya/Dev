using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonSubstring
{
    class Program
    {
        public static long p1 = 100000007;
        public static long p2 = 100000031;
        
        public static long x = 31;

        public static List<long> powerX1 = new List<long>();
        public static List<long> powerX2 = new List<long>();
        
        static void Main(string[] args)
        {
            FillPower(ref powerX1, 100000, p1);
            FillPower(ref powerX2, 100000, p2);
            
            string[] str = Console.ReadLine().Split(new char[] { ' ' });
            
            while(str.Length > 1)
            {
                string s = str[0];
                string t = str[1];

                int n = s.Length;
                int m = t.Length;

                int left = 0;
                int right = Math.Min(n, m) + 1;

                int sPosition = 0;
                int tPosition = 0;
                int maxLength = 0;

                while(right - left > 1)
                {
                    int middle = (left + right) / 2;

                    List<long> currHashS1 = CalculateHashTableOptimized(powerX1, middle, p1, s);
                    List<long> currHashS2 = CalculateHashTableOptimized(powerX2, middle, p2, s);
                    
                    List<long> currHashT1 = CalculateHashTableOptimized(powerX1, middle, p1, t);
                    List<long> currHashT2 = CalculateHashTableOptimized(powerX2, middle, p2, t);
                    
                    bool hasCommonSubstring = false;

                    Dictionary<long, int> dict = new Dictionary<long, int>();

                    for(int i = 0; i < currHashS1.Count; ++i)
                    {
                        if(!dict.ContainsKey(currHashS1[i]))
                            dict.Add(currHashS1[i], i);
                    }

                    for(int i = 0; i < currHashT1.Count; ++i)
                    {
                        if (dict.ContainsKey(currHashT1[i]) && currHashS2[dict[currHashT1[i]]] == currHashT2[i])
                        {
                            hasCommonSubstring = true;
                            sPosition = dict[currHashT1[i]];
                            tPosition = i;
                            maxLength = middle;
                            break;
                        }
                    }

                    if (hasCommonSubstring)
                        left = middle;
                    else
                        right = middle;
                }

                Console.WriteLine(sPosition + " " + tPosition + " " + maxLength);
                str = Console.ReadLine().Split(new char[] { ' ' });
            }
        }

        public static void FillPower(ref List<long> powerX, int l, long p)
        {
            powerX.Add(1);

            for(int i = 1; i <= l; ++i)
            {
                powerX.Add(powerX[i - 1] * x % p);
            }
        }

        public static List<long> CalculateHashTableOptimized(List<long> powerX, int l, long p, string str)
        {
            List<long> ret = new List<long>();

            for(int i = 0; i <= str.Length - l; ++i)
            {
                ret.Add(0);
            }

            long polyHash = 0;

            int power = 0;

            for(int i = str.Length - l; i < str.Length; ++i)
            {
                polyHash += ((long)str[i] * powerX[power] % p);
                polyHash %= p;
                power++;
            }
            
            ret[str.Length - l] = polyHash;

            for(int i = str.Length - l - 1; i >= 0; --i)
            {
                ret[i] = (ret[i + 1] * x % p + (long)str[i] - powerX[l] * (long)str[i + l] % p + p) % p; 
            }

            return ret;
        }
    }
}
