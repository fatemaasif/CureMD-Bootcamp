namespace _20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string 1: ");
            string str1 = Console.ReadLine();
            Console.Write("Enter string 2: ");
            string str2 = Console.ReadLine();
            string possiblecs="";
            int j, matchindex;
            for (int s=0; s<str1.Length; s++)
            { 
                string temp="";
                matchindex = 0;
                for (int i = s; i < str1.Length; i++) //for iterating through first string
                {
                    for (j = matchindex; j < str2.Length; j++) //for iterating through second string
                    {
                        if (str1[i] == str2[j]) 
                        {
                            temp = temp + str1[i];
                            matchindex = j+1;
                            break;
                        }
                    }
                }
                if(temp.Length>1) //only add to possible common seq if length >1
                {
                    possiblecs = possiblecs + temp + ' ';
                }
            }
            //find longest common subsequence
            string[] splitpcs = possiblecs.Split(' ');
            int[] lengthsplitpcs = new int[splitpcs.Length];
            for (int i = 0; i < splitpcs.Length; i++)
            {
                lengthsplitpcs[i] = splitpcs[i].Length;
            }
            int largest = 0;
            int index = 0;
            for (int i = 0; i < lengthsplitpcs.Length; i++)
            {
                if (lengthsplitpcs[i]>largest)
                {
                    largest= lengthsplitpcs[i];
                    index = i;
                }
            }
            Console.WriteLine("The longest common subsequence is " + splitpcs[index]);
        }
    }
}