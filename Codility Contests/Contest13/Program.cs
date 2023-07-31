using System;

namespace Contest13
{
    class Program
    {
        static int func1(int[] A)
        {
            int largestodd = 0, largesteven = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i]%2==0) //even
                {
                    if (A[i]>largesteven)
                    {
                        largesteven = A[i];
                    }
                }
                else //odd
                {
                    if (A[i] > largestodd)
                    {
                        largestodd = A[i];
                    }
                }
            }
            return largesteven + largestodd;
        }
        static int func2(int[] A)
        {
            int largestsum = -1;
            for (int i = 0; i < A.Length-1; i++)
            {
                string num1 = A[i].ToString();
                for (int j = i+1; j < A.Length; j++)
                {
                    string num2 = A[j].ToString();
                    if (num1[0]==num2[0] && num1[num1.Length-1]==num2[num2.Length-1]) //if first & last digits equal
                    {
                        if (A[i] + A[j]>largestsum)
                        {
                            largestsum = A[i] + A[j];
                        }
                    }
                }
            }
            return largestsum;
        }
        static int func3(int[] A)
        {
            Array.Sort(A);
            int roomcount = 0;
            int i = 0;
            while (i<A.Length)
            {
                if (A[i] > 0)
                {
                    roomcount++;
                    i += A[i];
                    if (i > A.Length)
                    {
                        break;
                    }
                }
            }
            return roomcount;
        }
        static void Main(string[] args)
        {
            int[] A = { 2,1,1,2};
            Console.WriteLine(func3(A));

            //Console.WriteLine(func2());

            //func3();
            //Console.WriteLine();

            
            Console.ReadKey();
        }
    }
}
