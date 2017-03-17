using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace CodeEval
{
    class Program
    {
        static HashSet<string> outputSet = new HashSet<string>();

        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    // do something with line
                    // we don't care which letters we find, only their frequencies
                    int[] input = line.Where(c => Char.IsLetter(c)).GroupBy(c => Char.ToLower(c)).Select(g => g.Count()).OrderByDescending(c => c).ToArray();

                    int maxLetterValue = 26;
                    int totalScore = 0; 
                    for (int i = 0; i < input.Length; i++)
                    {
                        totalScore += maxLetterValue * input[i];
                        maxLetterValue--;
                    }

                    Console.WriteLine(totalScore);
                }

            //Console.Read();
        }
    }
}
