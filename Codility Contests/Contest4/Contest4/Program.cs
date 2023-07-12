using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contest4
{
    class Program

    {
        static public int squareside(int A, int B)
        {
            int sum = A + B;
            if (sum < 4)
            {
                return 0;
            }
            int sideLength = sum / 4;
            int maxsticks = A / sideLength + B / sideLength;
            while (maxsticks < 4)
            {
                sideLength--;
                maxsticks = A / sideLength + B / sideLength;
            }
            return sideLength;
        }
        static public int bananacount(string S)
        {
            int iter = 0;
            //count num of each letters
            int nB = 0, nA = 0, nN = 0;
            for (int i = 0; i < S.Length; i++)
            {
                switch (S[i])
                {
                    case 'B':
                        nB++;
                        break;
                    case 'A':
                        nA++;
                        break;
                    case 'N':
                        nN++;
                        break;
                    default:
                        break;

                }
            }
            //check if string contains min req letters
            bool match = true;
            while (match)
            {
                if (nB > 0)
                {
                    if (nA > 2 && nA % 3 >= 0)
                    {
                        if (nN > 1 && nN % 2 >= 0)
                        {
                            iter++;
                            nB--;
                            nA -= 3;
                            nN -= 2;
                        }
                        else
                        {
                            match = false;
                            break;
                        }
                    }
                    else
                    {
                        match = false;
                        break;
                    }
                }
                else
                {
                    match = false;
                    break;
                }
            }
            return iter;
        }

        static public int sumoddeven(int[] a)
        {
            int lodd = 0, leven = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0) //even
                {
                    if (a[i] > leven)
                    {
                        leven = a[i];
                    }
                }
                else //odd
                {
                    if (a[i] > lodd)
                    {
                        lodd = a[i];
                    }
                }
            }
            return lodd + leven;

        }

        static public int binarygap(int N)
        {
            string binary = Convert.ToString(N, 2);
            List<int> indexes1 = new List<int>{};
            int numofOnes = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i]=='1')
                {
                    indexes1.Add(i);
                    numofOnes++;
                }
            }
            if (numofOnes == binary.Length || numofOnes == 1)
            {
                return 0;
            }
            
            int difference = indexes1[1] - indexes1[0] -1;
            int largestDifference = difference;
            for (int i = 2; i < indexes1.Count; i++ )
            {
                difference = indexes1[i] - indexes1[i-1];
                if(difference>largestDifference)
                {
                    largestDifference = difference;
                }
                
            }
            return largestDifference;

        }
        static void Main(string[] args)
        {

            //int[] A = new int[5] { 5, 3, 10, 6, 11 };
            //int sum = sumoddeven(A);
            //Console.WriteLine("sum largest odd and even: " + sum);

            //string S = "NAANAAXNABABYNNBZ";
            //int bananatime = bananacount(S);
            //Console.WriteLine("iterations: "+bananatime);

            //int squaresidel = squareside(10, 21);
            //Console.WriteLine("iterations: " + squaresidel);

            int bingap = binarygap(328);
            Console.WriteLine("bin gap: " + bingap);

            Console.ReadKey();
        }
           
    }
}
