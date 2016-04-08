using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfPrimes
{
    class Program
    {
        static void Main()
        {
            // do something
            List<int> primesFound = new List<int>(); // store list of primes found, we will use these as divisors
            primesFound.Add(2); // 2 is our first prime

            for (int primeCandidate = 3; primesFound.Count < 1000; primeCandidate += 2) // want first 1000 primes, don't check even numbers
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
                }
            }

            Console.WriteLine(primesFound.Sum()); // 3682913

        }
    }
}
