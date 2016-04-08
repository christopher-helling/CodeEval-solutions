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
                string plainText = "abcdefghijklmnopqrstuvwxyz";
                string encodedText = "uvwxyznopqrstghijklmabcdef";

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (String.IsNullOrEmpty(line))
                        continue;
                    // do something with line
                    char[] outputCharacters = new char[line.Length];

                    for (int i = 0; i < line.Length; i++)
                    {
                        // take character from input (line), find the index in encoded string, see which plain text letter that corresponds to
                        outputCharacters[i] = plainText[encodedText.IndexOf(line[i])]; 
                    }

                    // print result 
                    Console.WriteLine(new string(outputCharacters));

                }
            }

            Console.ReadLine();

        }

    }
}
