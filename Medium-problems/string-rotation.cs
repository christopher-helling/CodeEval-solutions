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
                    string[] input = line.Split(',');
                    string word1 = input[0];
                    string word2 = input[1];
                    bool isRotation = false;

                    // should refactor this into nicer code - find condition when it is true
                    if (word1.Length > 0 && word2.Length > 0 && word1.Length == word2.Length)
                    {
                        int startingIndex = word2.IndexOf(word1[0]);
                        if (startingIndex > -1)
                        {
                            for (int i = startingIndex; i < word2.Length; i++)
                            {
                                // creating unnecessary substrings instead of looping
                                // rearrange word2 to be string from middle of word to end of word + start of word
                                if (word1.Equals(word2.Substring(i) + word2.Substring(0,i)))
                                {
                                    isRotation = true;
                                    break;
                                }
                            }
                        }
                    }
                            
                    Console.WriteLine(isRotation ? "True" : "False");
                }
            //Console.Read();
        }
    }
}
