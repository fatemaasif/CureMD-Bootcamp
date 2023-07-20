using System;

namespace Contest5
{
    class Program
    {
        static int func1(int[] blocks)
        {
            int largestindexdifference = 0, ind1 = 0, ind2 = 0, j=0, k=0, diff=0;
            for (int i = 0; i < blocks.Length; i++) //to check for each starting point
            {
                if(i+1!=blocks.Length)
                {
                    j = i;
                    while (blocks[j] <= blocks[j + 1])
                    {
                        ind1 = j + 1;
                        j++;
                        if(j+1==blocks.Length)
                        {
                            break;
                        }
                    }
                }
                if (i - 1 != -1)
                {
                    k = i;
                    while (blocks[k] <= blocks[k - 1])
                    {
                        
                        ind2 = k - 1;
                        k--;
                        if(k-1==-1)
                        {
                            break;
                        }
                    }
                }
                diff = ind1 - ind2 + 1;
                if (diff >largestindexdifference)
                {
                    largestindexdifference = diff;
                }
            }
            return largestindexdifference;
        }
        static string func2(string name, string surname, int age)
        {
            string str = "";
            str = string.Concat(name[0], name[1], surname[0], surname[1], age);
            return str;
        }
        static public string func3(string S)
        {
            
            for (int i = 0; i < S.Length-2; i++)
            {
                while(S[i] == S[i + 1] && S[i + 1] == S[i + 2])
                {
                    if (i < S.Length - 2)
                    {
                        S = S.Remove(i + 2, 1);
                        if(i == S.Length - 2)
                        {
                            break;
                        }
                    }
                    else {break; }
                        
                }
            }
            return S;
        }
        static void Main(string[] args)
        {
            int[] A = {1,5,5,2,6 };
            Console.WriteLine(func1(A));

            //int str = func2();
            //Console.WriteLine(str + '\n');

            //func3();
            //Console.WriteLine();

            Console.ReadKey();
        }
    }
}
