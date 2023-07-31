using System;

namespace Contest11
{
    class Program
    {
        static bool func1(string S)
        {
            int na = 0, nb = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == 'a')
                {
                    na++;

                }
                if (S[i] == 'b')
                {
                    nb++;
                }
            }
            if (na == S.Length)
            {
                return true;
            }
            if (nb == S.Length)
            {
                return true;
            }
            for (int i = 0; i < na; i++)
            {
                if (S[i] == 'b')
                {
                    return false;
                }
            }
            return true;
        }
        static int func2(string S)
        {
            int a=0, b = 0, c = 0, d = 0, e=0;
            //find num of max pointing arows
            for (int i = 0; i < S.Length; i++)
            {
                switch (S[i])
                {
                    case '^':
                        a++;
                        break;
                    case 'v':
                        b++;
                        break;
                    case '<':
                        c++;
                        break;
                    case '>':
                        d++;
                        break;
                    default:
                        e++;
                        break;
                }
            }
            int max = 0;
            if (a>max)
            {
                max = a;
            }
            if (b > max)
            {
                max = b;
            }
            if (c > max)
            {
                max = c;
            }
            if (d > max)
            {
                max = d;
            }
            if (e > max)
            {
                max = e;
            }
            return S.Length - max;

        }
        static int func3(int N)
        {
            bool flag = true;
            
            string Nstr = "";
            while (flag)
            {
                bool consecFound = false;
                N++;
                Nstr = N.ToString();
                for (int i = 0; i < Nstr.Length-1; i++)
                {
                    if (Nstr[i]==Nstr[i+1])
                    {
                        consecFound = true;
                        break;
                    }
                }
                if (!consecFound)
                {
                    flag = false;
                }
                
            }
            return N;
        }
        static void Main(string[] args)
        {
            //Console.WriteLine(func1("abba"));

            //Console.WriteLine(func2());

            Console.WriteLine(func3(1765));

            Console.ReadKey();
        }
    }
}
