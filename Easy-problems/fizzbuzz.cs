using System;
using System.IO;
using System.Text;

namespace FizzBuzz
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
                while (!reader.EndOfStream)
                {
                    // each line of the input file contains e.g. "3 5 10" -- need to parse the 2 divisors and N
                    string line = reader.ReadLine(); 
                    if (String.IsNullOrEmpty(line))
                        continue;
                    // do something with line
                    string[] inputArguments = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries); // split on whitespace, delete excess entries
                    int fizz = Int32.Parse(inputArguments[0]);
                    int buzz = Int32.Parse(inputArguments[1]);
                    int N = Int32.Parse(inputArguments[2]);
                    StringBuilder output = new StringBuilder();

                    for (int i = 1; i <= N; i++)
                    {
                        string result = "";
                        if (i % fizz == 0)
                            result = "F";
                        if (i % buzz == 0)
                            result += "B";
                        if (result.Equals("")) // failed the first two if's, but prevents 3rd modulo check
                            result = i.ToString();
                        output.Append(result).Append(" "); // add the result and a space to the output line
                    }

                    // unsure if project wants to print to console or to use StreamWriter to create a file
                    Console.WriteLine(output);
                }
            }
        }
    }
}
