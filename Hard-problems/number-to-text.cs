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

                    int input = Int32.Parse(line);

                    string outputValue = "";

                    if (input < 0)
                    {
                        outputValue += "Negative";
                        input = input * -1; // flip the sign of negative input
                    }

                    if (input / 1000000 > 0) // number greater than 1 million
                    {
                        outputValue += GetNumberUnderOneThousand(input / 1000000); // e.g. "642 million"
                        outputValue += "Million";
                        input = input % 1000000; // divide off the millions place
                    }
                    if (input / 1000 > 0) // number greater than 1 thousand
                    {
                        outputValue += GetNumberUnderOneThousand(input / 1000); // e.g. "642 thousand"
                        outputValue += "Thousand";
                        input = input % 1000; // divide off the millions place
                    }
                    if (input > 0)
                    {
                        outputValue += GetNumberUnderOneThousand(input);
                    }

                    if (String.IsNullOrEmpty(outputValue)) // if output is still empty at this point, our number is zero
                    {
                        outputValue += "Zero";
                    }



                    // print result 
                    Console.WriteLine(outputValue);

                }
            }

            Console.ReadLine();

        }


        static string GetNumberUnderOneThousand(int input)
        {
            if (input == 0)
            {
                return "Zero"; // make sure this is only called on a number < 1000
            }

            string output = "";

            if (input / 100 > 0) // c# integer division rounds down, this means input is 3-digits
            {
                output += smallDigitsTable[input / 100]; // gets string "One" through "Nine"
                output += "Hundred";
                input = input % 100; // get rid of hundreds place
            }


            if (input >= 20)
            {
                string tempOutput = "";
                int onesPlace = input % 10;
                if (onesPlace > 0) // exclude zero, don't want "FortyZero"
                {
                    tempOutput = smallDigitsTable[onesPlace];
                }

                input = input - onesPlace; // get 20, ... 90
                output += tensDigitsTable[input] + tempOutput; // tempOutput is either One, Two, ..., Nine or empty string
            }
            else // otherwise number < 20, i.e. 1-19 
            {
                if (input > 0) // make sure we don't do "SixHundredZero"
                {
                    output += smallDigitsTable[input];
                }
                
            }


            return output;
        }


        static Dictionary<int, string> smallDigitsTable = new Dictionary<int, string> // lookup table
        {
            {0, "Zero"},
            {1, "One"},
            {2, "Two"},
            {3, "Three"},
            {4, "Four"},
            {5, "Five"},
            {6, "Six"},
            {7, "Seven"},
            {8, "Eight"},
            {9, "Nine"},
            {10, "Ten"},  // below values for when string isn't split on "twenty-" to "hundred-" (e.g. the '15' in 'one hundred fifteen')
            {11, "Eleven"}, 
            {12, "Twelve"},
            {13, "Thirteen"},
            {14, "Fourteen"},
            {15, "Fifteen"},
            {16, "Sixteen"},
            {17, "Seventeen"},
            {18, "Eighteen"},
            {19, "Nineteen"}
        };

        static Dictionary<int, string> tensDigitsTable = new Dictionary<int, string> // lookup table
        {
            {100, "Hundred"},
            {90, "Ninety"},
            {80, "Eighty"},
            {70, "Seventy"},
            {60, "Sixty"},
            {50, "Fifty"},
            {40, "Forty"},
            {30, "Thirty"},
            {20, "Twenty"}
        };



    }
}
