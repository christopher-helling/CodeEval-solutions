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

                    string[] input = line.Split(new char[] { ',' }, StringSplitOptions.None); // split on comma
                    string testString = input[0];
                    string endString = input[1];

                    Console.WriteLine(Convert.ToInt32(testString.EndsWith(endString))); // EndsWith method returns bool, convert bool to int and print it
                  
                }

                Console.ReadLine();

            }

        }
    }
}
