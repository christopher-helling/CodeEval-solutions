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

                    string[] inputs = line.Split(new char[] { ',' }, StringSplitOptions.None);
                    int lowerBound = Int32.Parse(inputs[0]);
                    int upperBound = Int32.Parse(inputs[1]);

                    int primeNumbersFound = 0;

                    if (lowerBound == 1)
                        lowerBound++; // set it to 2

                    if (lowerBound == 2 && lowerBound <= upperBound) // e.g. [2, 1] should not count as a prime found, not should [1, 1]
                    {
                        primeNumbersFound++; // 2 is prime
                        lowerBound++; // set it to 3
                    }
                    if (lowerBound % 2 == 0)
                        lowerBound++; // if lower bound is even, no point in checking primality

                    if (lowerBound > upperBound) // bad input, or 
                    {
                        Console.WriteLine(primeNumbersFound);
                    }
                    else
                    {
                        // check each prime between the two numbers
                        for (int primeCandidate = lowerBound; primeCandidate <= upperBound; primeCandidate += 2) // we start on an odd > 2, increment by 2
                        {

                            bool isPrimeNumber = isPrime(primeCandidate);

                            if (isPrimeNumber)
                            {
                                primeNumbersFound++;
                            }
                        }

                        Console.WriteLine(primeNumbersFound);
                    
                    }

                    
                }

            }

            Console.ReadLine();


        }

        static bool isPrime(int candidate)
        {
            if (candidate == 1)
                return false;
            if (candidate == 2)
                return true;
            if (candidate % 2 == 0)
                return false;

            int upperLimit = (int) Math.Floor(Math.Sqrt(candidate)); // only need to check up to the square root of the number as the largest factor

            for (int i = 3; i <= upperLimit; i += 2)
            {
                if (candidate % i == 0)
                    return false;
            }

            return true;
        }


    }

}
