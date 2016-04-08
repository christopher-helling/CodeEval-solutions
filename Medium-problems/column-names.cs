using System;
using System.IO;
using System.Text;

namespace ColumnNames
{
    class Program
    {
        /* Your program should accept a file as its first argument. The file contains multiple separated lines; 
         * each line contains 3 numbers that are space delimited. The first number is the first divider (X), 
         * the second number is the second divider (Y), and the third number is how far you should count (N). 
         * You may assume that the input file is formatted correctly and the numbers are valid positive integers. */
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            {
                // we want to convert the number to a base 26 representation, then substitute those values for letters-- note 'Z' at index 0 (mod 26)
                char[] letters = new char[] { 'Z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y'};

                while (!reader.EndOfStream)
                {
                    // each line of the input file contains e.g. "3 5 10" -- need to parse the 2 divisors and N
                    string line = reader.ReadLine(); 
                    if (String.IsNullOrEmpty(line))
                        continue;
                    // do something with line
                    int value = Int32.Parse(line);
                    int remainder = 0;
                    StringBuilder output = new StringBuilder();  

                    do
                    {
                        remainder = value % 26; // remainder -- e.g. R12
                        if (remainder == 0) // coresponds to the letter 'Z'
                        {
                            value = value / 26 - 1; // need to shift by 1 because our 'Z' is at index 0
                        }
                        else
                        {
                            value = value / 26; // this returns the integer portion -- 1208 / 26 = 46 (R12)
                        }
                        output.Insert(0, letters[remainder]); // inserting at index 0 same as prepending that letter
                    } 
                    while (value > 0);

                    Console.WriteLine(output);
                    

                }
            }

        }
    }
}
