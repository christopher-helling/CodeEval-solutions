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

                    string[] input = line.Split(new char[] { ',' }, StringSplitOptions.None); // no commas in input strings

                    string inputString = input[0];
                    string stringToMatch = input[1];
                    bool isMatch = true;

                    // since '*' is a wild card but '\*' is not, let's replace '\*' with another symbol so we can split our substring on actual wildcards '*'
                    // then only need to check the substrings before and after both occur in the original string - wildcard represents 0 or more characters, so
                    // it doesn't matter what characters occur in between the matched substrings
                    stringToMatch = stringToMatch.Replace("\\*", "~~~~~~~~~"); // replace \* with placeholder ~~~~~~~~~, and hope ~~~~~~~~~ doesn't occur in the real string

                    string[] substingsToMatch = stringToMatch.Split(new char[] { '*' }, StringSplitOptions.None);// split on asterisks/wildcard

                    foreach (string s in substingsToMatch)
                    {
                        string fixedString = s.Replace("~~~~~~~~~", "*"); // put the asterisks back in
                        if (inputString.IndexOf(fixedString) == -1)
                        {
                            isMatch = false;
                            break;
                        }
                    }

                    Console.WriteLine(isMatch ? "true" : "false");



                }

            }

        }
    }
}
