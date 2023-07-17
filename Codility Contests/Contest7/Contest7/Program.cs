using System;
using System.Collections.Generic;

namespace Contest5
{
    class Program
    {
        static int func1(int[] A)
        {
            if (A.Length==0)
            {
                return 0;
            }
            int result = 1;
            foreach (int num in A)
            {
                if(num==0)
                {
                    return 0;
                }
                result *= num;
            }
            if(result>0)
            {
                return 1;
            }
            else
            {
                return -1;
            }

        }
        static string func2(string[] phone_numbers, string[] phone_owners, string number)
        {
            
            for (int i = 0; i < phone_numbers.Length; i++)
            {
                if (phone_numbers[i]==number)
                {
                    return phone_owners[i];
                }  
            }
            return number;
        }
        static int func3(int[] A)
        {
            int numcastles = 0;
            int a = 0;
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i - 1] == A[i])
                {

                }
                else a++;
            }
            if(a==0)
            {
                return numcastles = 1;
            }

            for (int i = 0; i < A.Length; i++)
            {
                if ((i - 1 != -1) && (i + 1 != A.Length))
                {
                    if (A[i - 1] < A[i])//check for hill
                    {
                        int j = i+1;
                        bool flag = false;
                        if(j==A.Length)
                        {
                            return numcastles;
                        }
                        while(A[j-1]<A[j])
                        {
                            
                            flag = true;
                            j++;
                            if (j == A.Length)
                            {
                                return numcastles;
                            }
                        }
                        if (flag)
                        {
                            numcastles ++;
                            i = j;
                        }
                        else
                        {
                            numcastles++;
                        }
                        
                    }
                    if (A[i - 1] > A[i]) //valley
                    {
                        int j = i + 1;
                        bool flag = false;
                        if (j == A.Length)
                        {
                            return numcastles;
                        }
                        while (A[j - 1] > A[j])
                        {
                            
                            flag = true;
                            j++;
                            if (j == A.Length)
                            {
                                return numcastles;
                            }
                        }
                        if (flag)
                        {
                            numcastles++;
                            i = j;
                        }
                        else
                        {
                            numcastles++;
                        }
                    }
                }
                
            }
            return numcastles;
        }
        static int func4(int[]A)
        {
            
            int p = 0, q = 0;
            List<int[]> list = new List<int[]>();
            for (int i = 0; i < A.Length; i++)
            {
                int[] temp = new int[2];
                temp[0] = p;
                while (A[p] == A[q] || A[p] < A[q]) //hill
                {
                    p = q;
                    q++;
                }
                temp[1] = q;
                list.Add(temp);
                while (A[p] > A[q] || A[p] == A[q]) //valley
                {
                    p = q;
                    q++;
                }
                temp[0] = p; temp[1] = q;
                list.Add(temp);
                p = q;
                i = q - 1;
            }
            foreach (int[] item in list)
            {
                Console.WriteLine(item);
            }
            return list.Count;
        }
        static void Main(string[] args)
        {

            //int[] A = { -1, -2, -3, -5, -5 };
            //Console.WriteLine(func1(A));

            //string[] phone_numbers = { "123-456-123" };
            //string[] phone_owners = { "Henry T"};
            //string number = "123-456-123";
            //func2(phone_numbers,phone_owners,number);

            //int[] test = { -3,-3 };
            //Console.WriteLine(func3(test));
            int[] A = { 2, 2, 3, 4, 3, 3, 2, 2, 1, 1, 2, 5 };
            Console.WriteLine(func4(A));
            Console.ReadKey();
        }
    }
}
