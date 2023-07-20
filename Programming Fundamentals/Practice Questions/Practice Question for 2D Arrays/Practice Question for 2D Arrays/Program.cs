using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Question_for_2D_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum=0;
            int[,] arr2d = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            int rowlength=arr2d.GetLength(0);
            int columnlength=arr2d.GetLength(1);
            Console.WriteLine("The 2D array is: ");
            //find the sum and print array
            for (int i = 0; i < rowlength; i++)
            {
                for (int j = 0; j < columnlength; j++)
                {
                    Console.Write(arr2d[i,j]+"\t");
                    sum += arr2d[i,j];
                }
                Console.WriteLine();
            }

            //find max element
            int max = arr2d[0, 0];
            for (int i = 0; i < rowlength; i++)
            {
                for (int j = 0; j < columnlength; j++)
                {
                    if(arr2d[i,j]>max)
                    {
                        max = arr2d[i, j];
                    }
                }
            }

            //find average of each row
            float[] rowavg = new float[rowlength];
            for (int i = 0; i < rowlength; i++) 
            {
                float rowsum = 0;
                for (int j = 0; j < columnlength; j++)
                {
                    rowsum += arr2d[i, j];
                }
                rowavg[i] = rowsum / columnlength;
            }

            //check if given value exists
            Console.Write("Enter number to search: ");
            int searchfor = int.Parse(Console.ReadLine());
            bool matchfound = false;
            for (int i = 0; i < rowlength; i++)
            {
                for (int j = 0; j < columnlength; j++)
                {
                    if (arr2d[i,j]==searchfor)
                    {
                        matchfound = true;
                    }
                }
            }
            if (matchfound) { Console.WriteLine("Number found!"); }
            else { Console.WriteLine("Number not found!"); }

            //transpose the 2D Array
            int[,] transposedarr = new int[columnlength, rowlength];
            Console.WriteLine("\nThe transposed array is: ");
            //find the sum and print array
            for (int i = 0; i < rowlength; i++)
            {
                for (int j = 0; j < columnlength; j++)
                {
                    transposedarr[j, i] = arr2d[i, j];                    
                }
            }
            for (int i = 0; i < transposedarr.GetLength(0); i++)
            {
                for (int j = 0; j < transposedarr.GetLength(1); j++)
                {
                    Console.Write(transposedarr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            

            //display features of array
            Console.WriteLine("\nThe Sum of the 2D array is: "+sum);
            Console.WriteLine();
            Console.WriteLine("Average of each row: ");
            for (int i=0;i<rowavg.Length;i++)
            {
                Console.WriteLine("Row "+(i + 1) + ": " + rowavg[i]);
            }
            Console.ReadKey();
        }
    }
}
