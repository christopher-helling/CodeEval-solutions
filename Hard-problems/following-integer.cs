using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
                    char[] charArray = line.ToCharArray();
                    bool needsInsertZero = false;
                    string output = "";

                    // first check if we need to add a zero by seeing if digits are arranged largest to smallest, in which case,
                    // incrementing the number would need an extra digit
                    for (int i = 0; i < charArray.Length - 1; i++)
                    {
                        // if any digit is larger than the previous, then we don't need the zero to make the number bigger
                        if ((int)charArray[i] < (int)charArray[i + 1])
                        {
                            needsInsertZero = false;
                            break;
                        }

                        needsInsertZero = true;
                        
                    }
                    if (needsInsertZero)
                    {
                        // if we make it here, digits arranged from largest to smallest
                        // check first we don't have e.g. 80000000000, because we can't reverse that string
                        if (charArray[charArray.Length - 1].Equals('0'))
                        {
                            output = new string(charArray) + "0";
                        }
                        else
                        {
                            Array.Reverse(charArray); // smallest number of n+1 digits will have digits arranged smallest to largest, except can't start with zero
                            List<char> newCharList = charArray.ToList();
                            newCharList.Insert(1, '0');
                            output = new string(newCharList.ToArray()); // e.g. 842 --> 248 --> 2(0)48 = 2048
                        }
                    }
                    else 
                    {
                        if (charArray.Length == 1) // this would have missed the needInsertZero logic
                        {
                            output = charArray[0].ToString() + "0";
                        }
                        else
                        {
                            // assume length > 1 : handle base case above
                            // e.g. 32541 --> 3254 + 1
                            List<char> firstPart = charArray.Take(charArray.Length - 1).ToList(); // take first n-1 characters
                            List<char> endPart = charArray.Skip(charArray.Length - 1).Take(1).ToList(); // take last 1 character

                            bool isDone = false;

                            while (!isDone)
                            {
                                // compare last digit of first part to largest number in endPart. We want the smallest such number
                                //e.g. firstPart = 32, endPart = 541, max = 5, but we want the 4 to swap with the 2 --> 34125
                                if (firstPart[firstPart.Count - 1] < endPart.Max()) // there is an eligible element to swap with smallest digit of first part
                                {
                                    endPart.Sort(); // e.g. 541 --> 1, 4, 5
                                    // find smallest endPart number fulfilling if condition
                                    for (int j = 0; j < endPart.Count; j++)
                                    {
                                        // e.g. 2 < 4 when j = 1
                                        if (firstPart[firstPart.Count - 1] < endPart[j]) // endPart sorted smallest to largest
                                        {
                                            char swapA = firstPart[firstPart.Count - 1]; // 2
                                            firstPart.RemoveAt(firstPart.Count - 1); // 32 --> 3
                                            char swapB = endPart[j]; // 4
                                            endPart.RemoveAt(j); // 145 --> 15

                                            firstPart.Add(swapB); // add to end, e.g. 3 + 4 --> 34
                                            endPart.Insert(j, swapA); // endPart already sorted, e.g. 15 --> 1(2)5
                                            firstPart.AddRange(endPart); // 34 + 125
                                            output = new string(firstPart.ToArray()); // 34125
                                            isDone = true;
                                            break;
                                        }
                                    }
                                }
                                else 
                                {
                                    // move end of firstPart to start of endPart, e.g. 3254 + 1 --> 325 + 41
                                    char swapA = firstPart[firstPart.Count - 1];
                                    firstPart.RemoveAt(firstPart.Count - 1);
                                    endPart.Insert(0, swapA);
                                }
                            }

                        }
                    }

                    Console.WriteLine(output);
                }
            //Console.Read();
        }
    }
}
