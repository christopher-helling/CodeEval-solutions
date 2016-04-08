using System;
using System.Collections.Generic;
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

                    int outputValue = 0;
                    bool isNegative = false;

                    Dictionary<string, int> bigValuesToSplitNumber = new Dictionary<string, int>();
                    bigValuesToSplitNumber.Add("million", 1000000);
                    bigValuesToSplitNumber.Add("thousand", 1000);


                    string[] input = line.Split(new string[] { "negative " }, StringSplitOptions.None); // including space 

                    if (input.Length > 1) // split into two strings-- input[0] (empty)  + "negative " + input[1]
                    {
                        isNegative = true;
                    }

                    string outputString = input[input.Length - 1]; // we don't know if length is 1 or 2, set it to last element

                    foreach (KeyValuePair<string, int> entry in bigValuesToSplitNumber)
                    {
                        string[] tempOutput = outputString.Split(new string[] { entry.Key }, StringSplitOptions.None); // "six hundred eleven million six thousand" --> [" six hundred eleven ", " six thousand"]
                        if (tempOutput.Length > 1) // was split
                        {
                            outputValue += GetNumberUnderOneThousand(tempOutput[0]) * entry.Value; // 611 * 1,000,000
                            outputString = tempOutput[1]; // leftover string
                        }                        
                    }

                    // after we strill off the millions and thousands, we have a 3-digit number left 
                    outputValue += GetNumberUnderOneThousand(outputString);

                    outputValue = (isNegative) ? (-1 * outputValue) : outputValue; // multiply by -1 if negative

                    // print result 
                    Console.WriteLine(outputValue);

                }
            }

            Console.ReadLine();

        }


        static int GetNumberUnderOneThousand(string inputString)
        {
            int outputValue = 0; 
            foreach (KeyValuePair<string, int> entry in tensDigitsTable)
            {
                string[] tempOutput = inputString.Split(new string[] { entry.Key }, StringSplitOptions.None); // "six hundred forty two" --> [" six ", " forty two"]
                if (tempOutput.Length > 1) // was split
                {
                    if (String.IsNullOrEmpty(tempOutput[0]) || tempOutput[0].Equals(" "))
                    {
                        tempOutput[0] = "one"; // six hundred forty two --> 6 * 100 + (one) * 42 -- need the 1 * 42
                    }
                    outputValue += smallDigitsTable[tempOutput[0].Trim()] * entry.Value; // strip whitespace from "six ", lookup "six" in numericValueTable to get 6, then add 6 * 100 to outputValue
                    inputString = tempOutput[1]; // update remainder of string --> "forty two"
                }
            }
            // add the final (ones place) digit - if there is one (e.g. none if the number was "seventy")
            if (!String.IsNullOrEmpty(inputString.Trim()))
            {
                outputValue += smallDigitsTable[inputString.Trim()];
            }

            return outputValue;
        }


        static Dictionary<string, int> smallDigitsTable = new Dictionary<string, int> // lookup table
        {
            {"zero", 0},
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9},
            {"ten", 10},  // below values for when string isn't split on "twenty-" to "hundred-" (e.g. the '15' in 'one hundred fifteen')
            {"eleven", 11}, 
            {"twelve", 12},
            {"thirteen", 13},
            {"fourteen", 14},
            {"fifteen", 15},
            {"sixteen", 16},
            {"seventeen", 17},
            {"eighteen", 18},
            {"nineteen", 19}
        };

        static Dictionary<string, int> tensDigitsTable = new Dictionary<string, int> // lookup table
        {
            {"hundred", 100},
            {"ninety", 90},
            {"eighty", 80},
            {"seventy", 70},
            {"sixty", 60},
            {"fifty", 50},
            {"forty", 40},
            {"thirty", 30},
            {"twenty", 20}
        };



    }
}
