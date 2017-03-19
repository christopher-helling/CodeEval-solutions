using System;
using System.IO;
using System.Collections.Generic;

namespace CodeEval
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    // do something with line
                    int total = Int32.Parse(line);
                    int numCoinsNeeded = 0;
                    // we have coins of length 5, 3, 1. Use as many as possible in order
                    while (total > 0)
                    {
                        if (total >= 5)
                        {
                            numCoinsNeeded = total / 5; // integer division, still have a remainder
                            total -= (5 * numCoinsNeeded); // e.g. if we have total = 23, 4 coins of value 5, then 23 - (23/5) = 23 - 20 = 3
                        }
                        else if (total == 3 || total == 4)
                        {
                            numCoinsNeeded++;
                            total -= 3; // never going to use more than 1 coin of value 3. 6 = 3+3 = 5+1, 9 = 3+3+3 = 5+3+1, only gets worse from there and we use max# of 5-coins
                        }
                        else // total = 1 or 2 
                        {
                            numCoinsNeeded += total;
                            total = 0;
                        }
                    }          
                    Console.WriteLine(numCoinsNeeded);
                }
            //Console.Read();
        }
    }
}
