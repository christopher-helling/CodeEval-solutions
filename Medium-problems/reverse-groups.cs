using System;
using System.IO;
using System.Text;


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

                string[] inputs = line.Split(';'); // semi-colon separates the sequence and the number of items to reverse
                string[] sequence = inputs[0].Split(','); // sequence separated by commas
                int numElementsToReverse = Int32.Parse(inputs[1]);
                StringBuilder result = new StringBuilder();

                int arrayIndex = 0;
                while (arrayIndex < sequence.Length)
                {
                    result.Append(reverseArraySegment(sequence, arrayIndex, numElementsToReverse));
                    arrayIndex += numElementsToReverse;
                }

                result.Length--; // delete last character, which is a superfluous comma
                Console.WriteLine(result);

            }

        }

        Console.ReadLine();


    }

    static string reverseArraySegment(string[] inputArray, int startIndex, int numElementsToReverse)
    {
        StringBuilder output = new StringBuilder();
        if (inputArray.Length < startIndex + numElementsToReverse)
        {
            for (int i = startIndex; i < inputArray.Length; i++)
            {
                output.Append(inputArray[i]).Append(",");
            }
        }
        else
        {
            for (int i = (startIndex + numElementsToReverse) - 1; i >= startIndex; i--)
            {
                output.Append(inputArray[i]).Append(","); // subtract one due to zero-index of array
            }
        }

        return output.ToString();
    }


}
