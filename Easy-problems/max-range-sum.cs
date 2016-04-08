using System;
using System.IO;

namespace CodeEval
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (String.IsNullOrEmpty(line))
                        continue;
                    // do something with line

                    // maximum subarray problem
                    string[] input = line.Split(new char[] { ';' }, StringSplitOptions.None); // split on semicolon

                    int numOfDays = Int32.Parse(input[0]);
                    string[] listOfDayTotalsString = input[1].Split((string[])null, StringSplitOptions.None); // split on whitespace

                    int[] intArray = new int[listOfDayTotalsString.Length];
                    for (int i = 0; i < listOfDayTotalsString.Length; i++)
                    {
                        intArray[i] = Int32.Parse(listOfDayTotalsString[i]); // convert to int array
                    }


                    int currentMax = 0; // if no gain is possible, we print 0

                    // find max subarray summing consecutive elements, starting at each position of the array
                    for (int i = 0; i <= intArray.Length - numOfDays; i++)
                    {
                        int currentSum = 0; // need to reset sum each time

                        for (int j = 0; j < numOfDays; j++)
                        {
                            currentSum += intArray[i + j]; // starting at position i, add the next X elements (X given by the number of days you are finding the maximum for)
                        }

                        if (currentMax < currentSum)
                            currentMax = currentSum;
                    }


                    // print result 
                    Console.WriteLine(currentMax);
                }
            }

        }
    }
}
