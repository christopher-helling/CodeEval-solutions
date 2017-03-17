using System;
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

                    // we don't know if "(:)" is "(" + ":)" smiley or a colon in parentheses but we need to give benefit of the doubt it's correct 
                    bool isValid = false;
                    // +1 for '(', -1 for ')' keep track of upper and lower bounds of parentheses
                    int lowerBound = 0;
                    int upperBound = 0;
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == '(')
                        {
                            upperBound++;
                            if (!(i > 0 && line[i - 1] == ':')) // not :(, i.e. not ambiguous, must also increase
                            {
                                lowerBound++; 
                            }
                        }
                        else if (line[i] == ')')
                        {
                            lowerBound--;
                            if (!(i > 0 && line[i - 1] == ':')) // not :)
                            {
                                upperBound--; 
                            }
                        }

                        if (upperBound < 0) // invalid: closing parenthesis mismatch, e.g. " )text " --> -1
                            break;
                    }

                    // if "0" (i.e. balanced) is a possible value, we give the benefit of the doubt and say it's valid ":(:)" --> lower = -1, upper = +1 but  ":( :)" - valid
                    // that is, if 0 is in the range, it is possible to interpret smileys and parentheses in a way that makes a valid string 
                    if (lowerBound <= 0 && 0 <= upperBound)
                    {
                        isValid = true;
                    }
                    
                    Console.WriteLine(isValid ? "YES" : "NO");

                }

            //Console.Read();
        }
    }
}
