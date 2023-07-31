using System;
using System.Collections.Generic;

namespace Contest12
{
    class Program
    {
        static string func1(string S)
        {
            Dictionary<string, int> countDict = new Dictionary<string, int>();
            for (int i = 0; i < S.Length; i++)
            {
                if (countDict.ContainsKey(S[i].ToString()))
                {
                    return S[i].ToString();
                }
                countDict.Add(S[i].ToString(), 1);
            }
            return S[0].ToString();
        }
        static int func2(string S)
        {
            Dictionary<char, int> letterind = new Dictionary<char, int>();
            for (int i = 0; i < S.Length; i++)
            {
                if (Char.IsUpper(S[i]))
                {
                    if (letterind.ContainsKey(S[i]))
                    {
                        continue;
                    }
                    else {letterind.Add(S[i], i); }
                }
                if (Char.IsLower(S[i]))
                {
                    if (letterind.ContainsKey(S[i]))
                    {
                        letterind[S[i]] = i;
                    }
                    else { letterind.Add(S[i], i); }
                }
            }
            int result = 0;
            foreach (var (key,value) in letterind)
            {
                if (Char.IsUpper(key)) //check if upper case
                {
                    char lower = Char.ToLower(key);
                    if (letterind.ContainsKey(lower))
                    {
                        if (letterind[key]>letterind[lower])
                        {
                            result++;
                        }
                    }
                }
            }
            return result;
        }
        static int func3(string S)
        {
            int result = 0;
            for (int i = 1; i < S.Length-1; i++)
            {
                string S1 = S.Substring(0, i);
                string S2 = S.Substring(i + 1, S.Length);
                if ((S1.Contains('x') && S1.Contains('y')) || (S2.Contains('x') && S2.Contains('y')))
                {
                    int x=0, y=0;
                    for (int j = 0; j < S1.Length; j++)
                    {
                        if (S1[j]=='x')
                        {
                            x++;
                        }
                        if (S1[j] == 'y')
                        {
                            y++;
                        }
                    }
                    bool splitfound = false;
                    if (x==y)
                    {
                        result++;
                        splitfound = true;

                    }
                    int x1 = 0, y1 = 0;
                    if (!splitfound)
                    {
                        for (int j = 0; j < S2.Length; j++)
                        {
                            if (S2[j] == 'x')
                            {
                                x1++;
                            }
                            if (S2[j] == 'y')
                            {
                                y1++;
                            }
                        }
                        if (x1 == y1)
                        {
                            result++;
                        }
                    }

                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(func2("aaAbcCABBc"));

            //Console.WriteLine(func2());

            //func3();
            //Console.WriteLine();

            Console.ReadKey();
        }
    }
}
