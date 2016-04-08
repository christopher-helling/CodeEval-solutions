using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        using (StreamReader reader = File.OpenText(args[0]))
        {
            string line = reader.ReadLine();
            int inputLength = Int32.Parse(line);
            List<string> inputList = new List<string>();

            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                if (String.IsNullOrEmpty(line))
                    continue;
                // do something with line

                inputList.Add(line); // add each line to our list

            }

            string[] outputList = SortByLength(inputList).ToArray(); // convert list of strings to array so we can use indices

            for (int i = 0; i < inputLength; i++)
            {
                Console.WriteLine(outputList[i]);
            }

        }

        Console.ReadLine();

    }

    static IEnumerable<string> SortByLength(IEnumerable<string> inputList)
    {
        // Use LINQ to sort the array by the length of each string in descending order (biggest first)
        var sorted = from s in inputList
                     orderby s.Length descending
                     select s;
        return sorted;
    }

}
