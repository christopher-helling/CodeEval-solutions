using System;
using System.IO;


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
                try
                {
                    string[] stringList = line.Split((string[])null, StringSplitOptions.RemoveEmptyEntries); // whitespace default separator
                    int mthElement = Int32.Parse(stringList[stringList.Length - 1]); // last element of list tells us the mth element
                    string result = stringList[(stringList.Length - 1) - mthElement]; // length - 1 because the list includes the element parameter
                    Console.WriteLine(result);
                }
                catch (IndexOutOfRangeException) // If the index is larger than the number of elements in the list, ignore that input
                {
                    continue;
                }
                
            }

        }

    }
}
