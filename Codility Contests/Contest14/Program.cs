using System;
using System.Collections.Generic;
namespace Contest14
{
    class Program
    {
        static int func1(string[] E)
        {
            int result = 0;
            List<int[]> listofNumArr = new List<int[]>();
            Dictionary<int, int> countdic = new Dictionary<int, int>(); //key: num val:count
            //convert into a list of arrays
            foreach (string s in E)
            {
                int[] numarr = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    numarr[i] = int.Parse(s[i].ToString());
                }
                listofNumArr.Add(numarr); //an array of numbers from the string is added
                for (int i = 0; i < numarr.Length; i++)
                {
                    if (countdic.ContainsKey(numarr[i]))
                    {
                        countdic[numarr[i]]++;
                    }
                    else countdic.Add(numarr[i], 1);
                }
            }//countdic holds count of all nums.
            //find max count digit and second max count digit
            int maxCount = 0, secondMax=0;
            foreach (KeyValuePair<int, int> entry in countdic)
            {
                if (entry.Value > maxCount)
                {
                    maxCount = entry.Value;
                }
                if (entry.Value > secondMax && entry.Value < maxCount)
                {
                    secondMax = entry.Value;
                }
            }
            
            //return keys of max and secmax
            List<int> maxCountkey = new List<int>();
            List<int> SecondmaxCountkey = new List<int>();
            foreach (KeyValuePair<int, int> entry in countdic)
            {
                if (entry.Value==maxCount)
                {
                    maxCountkey.Add(entry.Key);
                }
                if (entry.Value == secondMax)
                {
                    SecondmaxCountkey.Add(entry.Key);
                }
            }
            if (maxCountkey.Count>1)
            {
                secondMax = maxCount;
            }

            for (int i = 0; i < listofNumArr.Count; i++)
            {
                for (int j = 0; j < maxCountkey.Count; j++)
                {
                    foreach (int num in listofNumArr[i])
                    {
                        if (num==maxCountkey[j])
                        {
                            result++;
                        }
                    }
                }
                    
            }

            return result;
        }
        static string func2()
        {
            string str = "";

            return str;
        }
        static void func3()
        {

        }
        static void Main(string[] args)
        {
            string[] E = new string[7] { "039", "4", "", "32", "14", "34", "7" };
            Console.WriteLine(func1(E));

            //Console.WriteLine(func2());

            //func3();
            //Console.WriteLine();

            Console.ReadKey();
        }
    }
}
