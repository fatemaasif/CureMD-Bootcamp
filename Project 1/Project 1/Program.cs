using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class Program
    {
        static void FrequencyAnalyzer(string[] text)
        {
            int freq;
            int[] frequencyarr = new int[text.Length];
            string[] temparr = new string[text.Length];
            for (int i = 0; i < text.Length; i++) //takes each word
            {
                freq=0;
                for (int j = 0; j < text.Length; j++) //compares to all words
                {
                    if (text[i]==text[j])
                    {
                        freq++;
                    }
                }
                frequencyarr[i]= freq;
            }
            bool flag = false; //flags if word already quoted before
            for (int i = 0; i < text.Length; i++) //takes each word and prints its frequency
            {
                if (frequencyarr[i] == 1)
                {
                    Console.WriteLine(text[i] + ": " + frequencyarr[i]);
                }
                else
                {
                    for (int j = i-1; j >= 0; j--) //searches in previous words if word on that index is used
                    {
                        if (text[i]==text[j])
                        {
                            flag = true;
                        }
                    }
                    if(!flag)
                    {
                        Console.WriteLine(text[i] + ": " + frequencyarr[i]);
                    }
                }
                flag = false;
            }
            Console.ReadKey();
            Console.Clear();
        }
        static void GenerateSentence(int N, string[] pool)
        {
            string[] sentence = new string[5];
            Random rnd = new Random();
            Console.WriteLine("\n\nSentences:\n");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int index = rnd.Next(0, pool.Length);
                    sentence[j] = pool[index];
                }
                foreach (string sen in sentence)
                {
                    Console.Write(sen + ' ');
                }
                Console.WriteLine();
            }
            Console.ReadKey();
            Console.Clear();
        }
        static void LongShortFinder(string[] words)
        {
            int longest = words[0].Length, shortest = words[0].Length;
            for (int i = 0; i < words.Length; i++ ) //find the longest and shortest length
            {
                int length = words[i].Length;
                if (length >= longest)
                {
                    longest = length;
                }
                if (length <= shortest)
                {
                    shortest = length;
                }
            }
            string longestw = "", smallestw = "";
            bool flag = false;
            for (int i = 0; i < words.Length; i++) //check which words have the smallest and shortest measured length
            {
                if (words[i].Length==longest)
                {
                    //print only those words that have not occured before
                    for (int j = i - 1; j >= 0; j--) //searches in previous words if word on that index is used
                    {
                        if (words[i] == words[j])
                        {
                            flag = true;
                        }
                    }
                    if(!flag)
                    {
                        longestw = longestw + words[i] + ' ';
                    }
                }   
                if (words[i].Length == shortest)
                {
                    for (int j = i - 1; j >= 0; j--) //searches in previous words if word on that index is used
                    {
                        if (words[i] == words[j])
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        smallestw = smallestw + words[i] + ' ';
                    }
                }
                flag = false;
            }
            string[] out1 = longestw.Trim().Split(' ');
            string[] out2 = smallestw.Trim().Split(' ');
            Console.WriteLine($"Longest word(s) have length {longest} and are as follows: ");
            foreach (string o in out1)
	        {
                Console.WriteLine("\"" + o + "\"");
	        }
            Console.WriteLine($"Shortest word(s) have length {shortest} and are as follows: ");
            foreach (string o in out2)
	        {
                Console.WriteLine("\"" + o + "\"");
            }
            Console.ReadKey();
            Console.Clear();
        }


        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Text Analyzer!\n");
                Console.WriteLine("Enter a sentence to analyze it: ");
                string inputsentence = Console.ReadLine();
                inputsentence = inputsentence.ToLower();    
                Console.WriteLine();
                string[] inputwords = inputsentence.Split(' ');
                bool newsentence = false;
                while (!exit || !newsentence)
                {
                    Console.WriteLine("Choose the option by entering its corresponding number (1-8):\n1.Word Frequency Analysis\n2.Sentence Maker\n3.Longest and Shortest Word Finder\n4.Word Search\n5.Palindrome Detector\n6.Vowel/Consonant Counter\n7.Analyze new sentence\n8.Exit Program");
                    int option = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Word Frequency Analysis");
                            Console.WriteLine("Obtain frequency of each word in the sentence.");
                            FrequencyAnalyzer(inputwords);
                            break;
                        case 2:
                            Console.WriteLine("Sentence Maker");
                            Console.Write("Enter number of sentences to generate: ");
                            int N = int.Parse(Console.ReadLine());
                            GenerateSentence(N, inputwords);
                            break;
                        case 3:
                            Console.WriteLine("Longest and Shortest Word Finder");
                            Console.WriteLine("Display the longest and shortest words in the sentence.");
                            LongShortFinder(inputwords);
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            newsentence = true;
                            break;
                        case 8:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Choose an appropriate option.");
                            break;
                    }
                
            }
        }
        
        }
    }
}
