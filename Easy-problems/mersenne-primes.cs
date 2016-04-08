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
            // question parameters state n < 3000. Would be faster to simply calculate the Mersenne numbers up to that number, then return results
            List<int> mersenneNumbersFound = new List<int>(); // store list of Mersenne numbers -- NOT Mersenne primes!!! 

            List<int> smallPrimes = new List<int>();
            smallPrimes.Add(2);
            smallPrimes.Add(3);
            smallPrimes.Add(5);
            smallPrimes.Add(7);
            smallPrimes.Add(11);
            // 2^11 = 2048, 2^12 = 4096 -- check up to the 11th power
            foreach (int i in smallPrimes) // loop through small primes to get required Mersenne numbers
            {
                int candidate = (int) Math.Pow(2, i) - 1;
                mersenneNumbersFound.Add(candidate);
            }


            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (String.IsNullOrEmpty(line))
                    continue;
                // do something with line

                int input = Int32.Parse(line);
                StringBuilder result = new StringBuilder();
                foreach (int prime in mersenneNumbersFound)
                {
                    if (prime < input)
                    {
                        result.Append(prime).Append(", "); // note the comma and the space this time
                    }
                    else 
                    {
                        break; // no need to check after input >= prime, because our list is ordered
                    }
                }

                if (result.Length > 0)
                {
                    result.Length = result.Length - 2; // delete superfluous comma and space from last prime
                }
                Console.WriteLine(result); // print list of primes

            }

        }

    }

    static bool isPrime(int number)
    {
        int boundary = (int) Math.Floor(Math.Sqrt(number));

        if (number == 1) 
            return false;
        if (number == 2) 
            return true;

        // simple (naive) check for primes - check if even, then loop through odds up to sqrt(n)
        if (number % 2 == 0)
            return false;

        for (int i = 3; i <= boundary; i = i + 2)
        {
            if (number % i == 0) 
                return false;
        }

        return true;
    }


}
