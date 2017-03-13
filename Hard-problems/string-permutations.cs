using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeEval
{
    class Program
    {
        static StringBuilder output = new StringBuilder();
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

                    // custom character sort for problem: digits < upper case letters < lower case letters
                    char[] charsOfString = line.ToCharArray();
                    List<char> charList = charsOfString.Where(r => char.IsDigit(r)).OrderBy(r => r)
                        .Concat(charsOfString.Where(r => char.IsUpper(r)).OrderBy(r => r))
                        .Concat(charsOfString.Where(r => char.IsLower(r)).OrderBy(r => r)).ToList();

                    // input string now sorted according to problem's rules
                    string input = String.Join("", charList);

                    // clear the old output
                    output.Clear();

                    // perform the permutations
                    permutation(input);

                    output.Length--; // remove trailing comma

                    Console.WriteLine(output);
                }
                Console.ReadLine();
            }
        }

        public static void permutation(string input)
        {
            permutation("", input);
        }

        public static void permutation(string prefix, string suffix)
        {
            int n = suffix.Length;

            if (n == 0)
            {
                output.Append(prefix).Append(","); // ending condition
            }
            else 
            {
                for (int i = 0; i < n; i++)
                {
                    // prefix + the ith character of the suffix is the new prefix
                    // then permute the rest of the suffix without that ith character
                    permutation(prefix + suffix[i], suffix.Substring(0, i) + suffix.Substring(i + 1));
                }
            }
        }
    }
}
