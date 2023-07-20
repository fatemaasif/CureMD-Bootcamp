using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Project_1
{
    class Program
    {
        static void FrequencyAnalyzer(string[] text)
        {
            Console.WriteLine("Word Frequency:");
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
                    Console.WriteLine("\"" + text[i] + "\"" + ": " + frequencyarr[i]);
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
                        Console.WriteLine("\"" + text[i] + "\"" + ": " + frequencyarr[i]);
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
            Console.WriteLine("\n\nGenerated Sentences:\n");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int index = rnd.Next(0, pool.Length);
                    sentence[j] = pool[index];
                }
                Console.Write(i+1 + ". ");
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
        static void WordFinder(string[] words, string searchword)
        {
            int freq = 0;
            bool matchfound = false;
            foreach (string word in words)
            {
                if (word==searchword)
                {
                    matchfound= true;
                    freq++;
                }
            }
            if (matchfound)
            {
                Console.WriteLine($"The word \"{searchword}\" appears {freq} time(s) in the sentence.");
            }
            else
            {
                Console.WriteLine("Word not found.");
            }
            Console.ReadKey();
            Console.Clear();
        }
        static void PalindromeDetector(string[] words)
        {
            bool[] palindromedetected = new bool[words.Length];
            for (int i = 0; i < words.Length; i++) //this for loop takes each word and flags it as a palidrome if it is
            {
                string reversed = "";
                for (int j = words[i].Length - 1; j >= 0; j--)//first reverse each word
                {
                    reversed = reversed + words[i][j];
                }
                //check which words are palindromes and only write word once
                if (reversed == words[i]) { palindromedetected[i] = true; }
                else { palindromedetected[i] = false; }
            }

            bool flag = false, nopalindrome = true;
            for (int i = 0; i < palindromedetected.Length; i++) //to loop through palindrome bool array
            {
                if (palindromedetected[i]) //if the word is a palindrome 
                {
                    nopalindrome = false;
                    for (int k = i - 1; k >= 0; k--) //for loop to check if it has been printed before else print it
                    {
                        if (words[i] == words[k])
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        Console.WriteLine($"{words[i]} is a Palindrome");
                    }
                }
                flag = false;
            }
            if (nopalindrome) { Console.WriteLine("There are no palindromic words in the sentence."); }
            Console.ReadKey();
            Console.Clear();
        }
        static void VCCounter(string[] inputwords)
        {
            Console.WriteLine("Vowels and Consonants Count:");
            for (int i = 0; i < inputwords.Length; i++) //each iteration to work on one word
            {
                int vowels = 0, consonants = 0;
                for (int j = 0; j < inputwords[i].Length; j++) //each iteration to work on single letter
                {
                    //count number of vowels & consonants
                    if (inputwords[i][j] == 'a') { vowels++; }
                    else if (inputwords[i][j] == 'e') { vowels++; }
                    else if (inputwords[i][j] == 'i') { vowels++; }
                    else if (inputwords[i][j] == 'o') { vowels++; }
                    else if (inputwords[i][j] == 'u') { vowels++; }
                    else { consonants++; }
                }
                bool flag = false;
                for (int k = i-1; k >= 0; k--) //check if word has already been printed before
                {
                    if (inputwords[i] == inputwords[k])
                    {
                        flag = true;
                    }
                }
                if (!flag) { Console.WriteLine($"\"{inputwords[i]}\": {vowels} vowels and {consonants} consonants"); }
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
                string[] inputwords = inputsentence.Split(' ');
                bool newsentence = false;
                while (!newsentence)
                {
                    Console.WriteLine("\nChoose the option by entering its corresponding number (1-8):\n1.Word Frequency Analysis\n2.Sentence Maker\n3.Longest and Shortest Word Finder\n4.Word Search\n5.Palindrome Detector\n6.Vowel/Consonant Counter\n7.Analyze new sentence\n8.Exit Program");
                    Console.Write("\nOption: ");
                    int option = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Word Frequency Analysis");
                            Console.WriteLine("Obtain frequency of each word in the sentence.\n");
                            FrequencyAnalyzer(inputwords);
                            break;
                        case 2:
                            Console.WriteLine("Sentence Maker");
                            Console.Write("Enter number of sentences to generate: ");
                            int N = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            GenerateSentence(N, inputwords);
                            break;
                        case 3:
                            Console.WriteLine("Longest and Shortest Word Finder");
                            Console.WriteLine("Display the longest and shortest words in the sentence.\n");
                            LongShortFinder(inputwords);
                            break;
                        case 4:
                            Console.WriteLine("Word Finder");
                            Console.WriteLine("Check if word exists and display its frequency.");
                            Console.Write("\nEnter word to search: ");
                            string searchword = Console.ReadLine();
                            Console.WriteLine();
                            WordFinder(inputwords,searchword);
                            break;
                        case 5:
                            Console.WriteLine("Palindrome Detector");
                            Console.WriteLine("Check if there are any palindromes in the sentence and display them\n");
                            PalindromeDetector(inputwords);
                            break;
                        case 6:
                            Console.WriteLine("Vowel & Consonant Counter");
                            Console.WriteLine("Display the number of vowels and consonents in the sentence\n");
                            VCCounter(inputwords);
                            break;
                        case 7:
                            newsentence = true;
                            break;
                        case 8:
                            newsentence = true;
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
