using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a sentence: ");
            string input = Console.ReadLine();
            string[] text = input.Split(' ');
            int freq;
            int[] frequencyarr = new int[10];
            string[] temparr=new string[10];
            for (int i = 0; i < text.Length; i++) //takes each word
            {
                freq=0;
                for (int j = i + 1; j < text.Length; j++) //compares to all words
                {
                    if (text[i]==text[j])
                    {
                        freq++;
                    }
                }
                frequencyarr[i]= freq;
            }
            bool flag=false; //flags if word already quoted before
            for (int i = 0; i < text.Length; i++) //takes each word and prints its frequency
            {
                if (frequencyarr[i]<=1)
                {
                    Console.WriteLine(text[i] + ": " + frequencyarr[i]);
                }
                else
                {
                    if(!flag)
                    {
                        Console.WriteLine(text[i] + ": " + frequencyarr[i]);
                        flag=true;
                    }
                }
            }
            Console.ReadKey();
            
        }
    }
}
