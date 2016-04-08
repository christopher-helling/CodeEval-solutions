using System;
using System.IO;
using System.Text;

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

                    string[] input = line.Split(new char[] { ';' }, StringSplitOptions.None); // split on semicolon

                    int desiredSum = Int32.Parse(input[1]);
                    string[] listOfCandidatesString = input[0].Split(new char[] { ',' }, StringSplitOptions.None); // split on comma

                    int[] intArray = new int[listOfCandidatesString.Length];
                    StringBuilder result = new StringBuilder();


                    for (int i = 0; i < listOfCandidatesString.Length; i++)
                    {
                        intArray[i] = Int32.Parse(listOfCandidatesString[i]); // convert to int array
                    }

                    bool answerFound = false; // use flag to determine if we need to print "NULL"

                    // find potential sums of pairs of elements starting at each position of the array
                    for (int i = 0; i < intArray.Length - 1; i++) // subtract 1 because we are looking at pairs of elements
                    {

                        for (int j = i + 1; j < intArray.Length; j++) // start index right after i-- first pair is (i, i+1)
                        {
                            if (intArray[i] + intArray[j] == desiredSum)
                            {
                                answerFound = true;
                                result.Append(intArray[i] + "," + intArray[j] + ";"); // add to list of results
                            }
                        }
                    }

                    if (result.Length > 0)
                    {
                        result.Length--; // subtract off final semi-colon
                    }

                    if (!answerFound)
                    {
                        result.Append("NULL");
                    }


                    // print result 
                    Console.WriteLine(result);
                }
            }
        }
    }
}
