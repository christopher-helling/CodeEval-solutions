using System;
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

                    // push elements to a stack, we will check cycles by searching from the end of the sequence
                    string[] input = line.Split((string[])null, StringSplitOptions.None); // split on whitespace

                    double lowerBound = 0;
                    double upperBound = Int32.Parse(input[0]);
                    // note that .NET uses banker's roundng-- 0.5 rounds to 0, not to 1. Need to specify we don't want this for our binary search algorithm
                    double guess = Math.Ceiling((upperBound + lowerBound) / 2); // need to use double instead of int to round up

                    for (int i = 1; i < input.Length; i++)
                    {
                        if (input[i].Equals("Lower"))
                        {
                            upperBound = guess - 1;
                        }
                        else if (input[i].Equals("Higher"))
                        {
                            lowerBound = guess + 1;
                        }
                        else if (input[i].Equals("Yay!")) // guess is correct
                        {
                            break;
                        }

                        guess = Math.Ceiling((upperBound + lowerBound) / 2); // adjust guess
                    }
                    

                    // print results 
                    Console.WriteLine(guess); 
                }
            }

        }
    }
}
