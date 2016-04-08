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

                    string[] input = line.Split((string[])null, StringSplitOptions.None);

                    for (int i = input.Length - 1; i >= 0; i--)
                    {
                        Console.Write(input[i] + " ");
                    }

                    Console.WriteLine(); // new line
                }
            }

        }
    }
}
