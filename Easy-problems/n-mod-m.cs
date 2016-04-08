using System;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        using (StreamReader reader = File.OpenText(args[0]))
        {
            while (!reader.EndOfStream)
            {
                // each line of the input file contains e.g. "3 5 10" -- need to parse the 2 divisors and N
                string line = reader.ReadLine();
                if (String.IsNullOrEmpty(line))
                    continue;
                // do something with line
                string[] values = line.Split(','); // Note that dividend/divisor = quotient + remainder, i.e. dividend % divisor = remainder
                int dividend = Int32.Parse(values[0]);
                int divisor = Int32.Parse(values[1]);

                // remainder = dividend/divisor - quotient = dividend - (quotient * divisor)
                int remainder = dividend - (dividend / divisor) * (divisor); // in C#, "dividend/divisor" returns the whole integer value (quotient)

                Console.WriteLine(remainder);
            }
        }

    }
}
