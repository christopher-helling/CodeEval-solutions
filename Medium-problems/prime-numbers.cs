using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


class Program
{
    static void Main(string[] args)
    {
        using (StreamReader reader = File.OpenText(args[0]))
        {
            int largestInput = 0;
            List<int> primesFound = new List<int>(); // store list of primes found, we will use these as divisors
            primesFound.Add(2); // 2 is our first prime

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (String.IsNullOrEmpty(line))
                    continue;
                // do something with line

                int currentInput = Int32.Parse(line);
                StringBuilder result = new StringBuilder();
                // let's keep track of the biggest input so we don't recalculate old primes
                if (currentInput > largestInput)
                {
                    // this is now our largest input
                    largestInput = currentInput;

                    foreach (int prime in primesFound)
                    {
                        result.Append(prime).Append(","); // add the primes we've found so far
                    }


                    // then calculate more primes
                    int firstPrimeCandidate = (primesFound[primesFound.Count - 1] % 2 == 0) ? primesFound[primesFound.Count - 1] + 1 : primesFound[primesFound.Count - 1]; // check if last prime found is even (2), then start at the next odd

                    for (int primeCandidate = firstPrimeCandidate; primeCandidate < currentInput; primeCandidate += 2) // want first 1000 primes, don't check even numbers
                    {
                        bool isPrime = true;

                        foreach (int prime in primesFound)
                        {
                            if (primeCandidate % prime == 0) // if our number is divisible by a smaller prime, it is not prime itself
                            {
                                isPrime = false;
                                break; // stop checking further primes
                            }
                        }
                        if (isPrime)
                        {
                            primesFound.Add(primeCandidate); // add it to our list of primes
                            result.Append(primeCandidate).Append(","); // print it to the current result
                        }
                    }

                }
                else // we have already discovered this list of primes, and need to return a slice of the list
                {
                    foreach (int prime in primesFound)
                    {
                        // only print primes < currentInput
                        if (prime >= currentInput)
                        {
                            break;
                        }
                        else
                        {
                            result.Append(prime).Append(","); // we will later remove the final comma
                        }
                    }
                }



                if (result.Length > 0)
                {
                    result.Length--; // delete superfluous comma from last prime
                }
                Console.WriteLine(result); // print list of primes

            }

        }


    }


}
