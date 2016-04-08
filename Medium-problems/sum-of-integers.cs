using System;
using System.IO;
using System.Linq;

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
                    string[] input = line.Split(new char[] {','}, StringSplitOptions.None); // split on comma

                    int[] intArray = new int[input.Length];
                    for (int i = 0; i < input.Length; i++)
                    {
                        intArray[i] = Int32.Parse(input[i]); // convert to int array
                    }

                    int currentSum = 0; // is empty subarray valid, i.e. sum of 0 elements = 0?
                    int currentMax = 0;

                    if (intArray.Max() < 0)
                    {
                        currentMax = intArray.Max(); // Code Eval doesn't think empty subarray is valid, so return smallest negative integer instead
                    }
                    else
                    {
                        // find max subarray summing consecutive elements, starting at each position of the array
                        for (int i = 0; i < intArray.Length; i++)
                        {
                            currentSum += intArray[i];

                            if (currentMax < currentSum)
                                currentMax = currentSum;
                            else if (currentSum < 0)
                                currentSum = 0;
                        }
                    }

                    // print result 
                    Console.WriteLine(currentMax); 
                }
            }

        }
    }
}
