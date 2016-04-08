using System;
using System.Collections.Generic;
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

                    int input = Int32.Parse(line);
                    StringBuilder result = new StringBuilder();
                    result.Append("Dollars"); // we will build the result string from right to left by prepending -- note answer is "OneDollars", not "OneDollar"


                    if (input == 0)
                    {
                        result.Insert(0, "Zero"); // edge case, only print ZeroDollars when input is 0-- otherwise ignore it (e.g. 36 thousand dollars, not 36 thousand zero dollars)
                    }


                    int lastThreeDigits = input % 1000;
                    result.Insert(0, PrintThreeDigits(lastThreeDigits));

                    // save new input without last three digits
                    input = (input - lastThreeDigits) / 1000;

                    int bigDigitTrack = 1; // keep track of thousands, millions, billions etc word
                    while (input > 0)
                    {
                        bigDigitTrack *= 1000; // 1000, 1000000, ...
                        lastThreeDigits = input % 1000;
                        if (lastThreeDigits != 0) // don't print ZeroThousand
                        {
                            result.Insert(0, PrintThreeDigits(lastThreeDigits) + largeNumberTable[bigDigitTrack]); // e.g. six hundred forty three + thousand
                        }
                        // save new input without last three digits
                        input = (input - lastThreeDigits) / 1000;
                    }

                    Console.WriteLine(result);

                }
            }

        }

        static string PrintThreeDigits(int input) // three digit number input
        {
            StringBuilder result = new StringBuilder();
            // check first two digit places-- the values 1-19 must be handled
            int tempValue = input % 100;
            if (tempValue < 20)
            {
                result.Insert(0, lookupTable[tempValue]);
            }
            else // last two digits >= 20
            {
                // get last digit
                if (tempValue % 10 != 0) // want to add "thirty", not "thirty zero"
                {
                    result.Insert(0, lookupTable[tempValue % 10]);
                }
                tempValue -= tempValue % 10; // subtract off last digit, e.g. 29 --> 20, then lookup 20
                result.Insert(0, lookupTable[tempValue]);
            }

            input = (input - tempValue) / 100; // remove last two digits
            if (input != 0) // no such thing as "zero hundred"
            {
                result.Insert(0, lookupTable[input] + "Hundred");
            }

            return result.ToString();
        }


        static Dictionary<int, string> lookupTable = new Dictionary<int, string> // lookup table
        {
            {0, ""}, // don't print anything for zero, we handle zero dollars as a special case-- zero is ignored otherwise (three hundred, not three hundred zero)
            {1, "One"},
            {2, "Two"},
            {3, "Three"},
            {4, "Four"},
            {5, "Five"},
            {6, "Six"},
            {7, "Seven"},
            {8, "Eight"},
            {9, "Nine"},
            {10, "Ten"},
            {11, "Eleven"},
            {12, "Twelve"},
            {13, "Thirteen"},
            {14, "Fourteen"},
            {15, "Fifteen"},
            {16, "Sixteen"},
            {17, "Seventeen"},
            {18, "Eighteen"},
            {19, "Nineteen"},
            {20, "Twenty"},
            {30, "Thirty"},
            {40, "Forty"},
            {50, "Fifty"},
            {60, "Sixty"},
            {70, "Seventy"},
            {80, "Eighty"},
            {90, "Ninety"},
            {100, "Hundred"}
        };

        static Dictionary<int, string> largeNumberTable = new Dictionary<int, string> // lookup table
        {
            {1000, "Thousand"},
            {1000000, "Million"} // could easily fix this for larger inputs than the problem stated, if needed
        };


    }
}
