using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace CodeEval
{
    class Program
    {
        static void Main(string[] args)
        {
            // since we have 2 <= a <= 9, there are only a few possible sequences of digits we can get. We will define the sequences, and then figure out
            // how often they repeat with a given n in order to calculate the digit count
            Dictionary<int, int[]> repeatingSequences = new Dictionary<int, int[]>(); // given a, repeating digit pattern
            repeatingSequences.Add(2, new int[] { 2, 4, 8, 6 });
            repeatingSequences.Add(3, new int[] { 3, 9, 7, 1 });
            repeatingSequences.Add(4, new int[] { 4, 6 });
            repeatingSequences.Add(5, new int[] { 5 });
            repeatingSequences.Add(6, new int[] { 6 });
            repeatingSequences.Add(7, new int[] { 7, 9, 3, 1 });
            repeatingSequences.Add(8, new int[] { 8, 4, 2, 6 });
            repeatingSequences.Add(9, new int[] { 9, 1 });

            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    // do something with line
                    string[] input = line.Split(' '); // given [a, n], want last digit of a^1, a^2, ..., a^n
                    int a = Int32.Parse(input[0]);
                    long n = long.Parse(input[1]);
                    long[] digitCount = new long[10]; // digitCount[i] = j means the digit i appears j times
                    // n >= 1, initialize digitCount with values from dictionary
                    foreach (int i in repeatingSequences[a])
                    {
                        digitCount[i]++;
                    }

                    // then we perform integer division (no remainder) to see how many times this sequence will appear
                    long timesRepeated = n / repeatingSequences[a].Length; // n divided by length of repeating sequence
                    for (int i = 0; i < 10; i++)
                    {
                        if (digitCount[i] > 0)
                        {
                            digitCount[i] = timesRepeated * digitCount[i];
                        }
                    }

                    // now we take the remainder after dividing 
                    int remainder = (int)(n % repeatingSequences[a].Length);
                    for (int i = 0; i < remainder; i++)
                    {
                        digitCount[repeatingSequences[a][i]]++; // get corresponding Dict (indexed by input[0], take the ith element of that array, increase that digit's count
                    }

                    // output
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < 10; i++) // digit count is 10
                    {
                        sb.Append(i).Append(": ").Append(digitCount[i]).Append(", ");
                    }
                    sb.Length = sb.Length - 2; // delete final ", " characters                   
                    Console.WriteLine(sb.ToString());
                }
            //Console.Read();
        }
    }
}
