using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contest5
{
    class Program
    {
        static int func1(int[] A)
        {
            
            string[] Astr = new string[A.Length];
            //check which two integers share same first and last
            for (int i = 0; i < A.Length; i++)
            {
                Astr[i]=Convert.ToString(A[i]);
            }
            List<int> first = new List<int>();
            List<int> second = new List<int>();
            for (int i = 0; i < Astr.Length; i++)
            {
                for (int j = i+1; j < Astr.Length; j++)
			    {
			        if (Astr[i][0]==Astr[j][0])
                    {
                        if (Astr[i][Astr[i].Length-1]==Astr[j][Astr[j].Length-1])
                        {
                            first.Add(Convert.ToInt32(Astr[i]));
                            second.Add(Convert.ToInt32(Astr[j]));
                        }
                    }
                    
			    }
            }

            //if none return -1
            if (first.Count==0)
            {
                return -1;
            }
            int sum = first[0] + second[0];
            if (first.Count==1)
            {
                return sum;
            }
            //sum them if more than 2 return larger sum
            List<int> sumList = new List<int>();
            for (int i = 0; i < first.Count; i++)
            {
                sumList.Add(first[i] + second[i]);
            }
            foreach (int s in sumList)
            {
                if (s>sum)
                {
                    sum = s;
                }
            }

            return sum;
        }
        static string func2(string S)
        {
            string str = "tie";
            int Xwin = 0, OWin = 0;

            for (int i = 0; i < S.Length - 3; i++)
            {
                if (S[i] == 'X')
                {
                    if (S[i + 1] == 'X')
                    {
                        if (S[i + 2] == 'X')
                        {
                            Xwin += 1;
                        }
                    }
                }
                if (S[i] == 'O')
                {
                    if (S[i + 1] == 'O')
                    {
                        if (S[i + 2] == 'O')
                        {
                            OWin += 1;
                        }
                    }
                }
            }
            if (Xwin >= 1 && OWin >= 1)
            {
                str = "tie";
                return str;
            }
            if (Xwin >= 1)
            {
                str = "X";
                return str;
            }
            if (OWin >= 1)
            {
                str = "O";
                return str;
            }
            return str;
        }
        static string func3(string S)
        {
            int largestsum = 0;
            string largeststr="";
            
            int sum = 0;
            
            for (int i = 0; i < S.Length; i++)
            {
                string temp1=S.Remove(i);
                                    
                for (int j = 0; j < temp1.Length; j++)
                {
                    sum += Convert.ToInt32(temp1[j]);
                }
                if (sum>largestsum)
                {
                    largeststr = temp1;
                }

            }
            return largeststr;
        }
        static void Main(string[] args)
        {
            //int[] A = new int[] { 130, 191, 200, 10 };
            //int val = func1(A);
            //Console.WriteLine(val);

            //string str = func2("XX");
            //Console.WriteLine(str + '\n');

            
            Console.WriteLine(func3("codility"));
            Console.ReadKey();
        }
    }
    
}
