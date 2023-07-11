using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contest3
{
    class Program
    {
        static void Main(string[] args)
        {
            //int D = 0;
            //string S = 0;
            //int S1 =1;
            //switch (S)
            //{
            //    case "one":
            //        S1 = 1;
            //        break;
            //    case "two":
            //        S1 = 2;
            //        break;
            //    case "three":
            //        S1 = 3;
            //        break;
            //    case "four":
            //        S1 = 4;
            //        break;
            //    case "five":
            //        S1 = 5;
            //        break;
            //    default:
            //        break;
            //}
            //int result = D * S1;

            //for (int i = 999; i >= 100; i--)
            //{
            //    Console.WriteLine(i);
            //}

            int[] A = new int[5] {11,1,8,12,14};
            bool flag = false;
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = i+1; j < A.Length; j++)
                {
                    if (A[i]==A[j]+1)
                    {
                        flag = true;
                    }
                    if (A[j] == A[i] + 1)
                    {
                        flag = true;
                    }
                }
                //flag=false;
            }
        }
    }
}
