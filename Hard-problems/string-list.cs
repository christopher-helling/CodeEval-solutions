using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace CodeEval
{
    class Program
    {
        static HashSet<string> outputSet = new HashSet<string>();

        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    // do something with line
                    outputSet.Clear(); // clear old output
                    string[] input = line.Split(',');
                    // sort the inputs in alphabetical order (which will remain in alphabetical order after permuting)
                    // it is quicker to sort input now than our long list of output later
                    char[] inputArray = input[1].ToCharArray();
                    Array.Sort(inputArray);
                    // save time by only selecting distinct letters of the string

                    string inputString = new string(inputArray.Distinct().ToArray());

                    permuteSetLength("", inputString, Int32.Parse(input[0]));
                    string[] outputArray = new string[outputSet.Count];
                    outputSet.CopyTo(outputArray);

                    Console.WriteLine(String.Join(",", outputArray));
                }

            Console.Read();
            
        }

        // this function will find all the strings of length k you can make from a set of letters N
        static void permuteSetLength(string prefix, string suffix, int length)
        {
            if (length == 0)
            {
                outputSet.Add(prefix);
                return;
            }

            // use dictionary to remove duplicate prefixes, to avoid permuting the same thing again
            Dictionary<string, string> newPrefixesAndSuffixes = new Dictionary<string, string>();
            // otherwise, calculate our new prefixes by adding each letter of suffix to the prefix, and decrementing length by 1
            for (int i = 0; i < suffix.Length; i++)
            {
                if (!newPrefixesAndSuffixes.ContainsKey(prefix + suffix[i])) // new key
                {
                    // suffix stays the same, we will be reusing the same set of letters to choose from
                    permuteSetLength(prefix + suffix[i], suffix, length - 1);
                }

            }
        }
    }
}
