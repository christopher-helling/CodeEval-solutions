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
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    // do something with line
                    string[] input = line.Split(';');
                    int arraySize = Int32.Parse(input[0]);
                    int[] array = Array.ConvertAll(input[1].Split(','), int.Parse);

                    // array contains all values from 0 to n-2, so we can find the duplicate by subtracting array sum from the sum of 0 to n-2
                    // sum of 0 + 1 + 2 + ... + n = n(n+1)/2, so sum of 0 to n-2 is (n-1)(n-2) / 2
                    int expectedSum = ((arraySize - 1) * (arraySize - 2)) / 2;
                    int arraySum = array.Sum();
                    int duplicateValue = arraySum - expectedSum;

                    Console.WriteLine(duplicateValue);
                }
            //Console.Read();
        }
    }
}
