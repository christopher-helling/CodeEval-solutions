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

                    string[] input = line.Split(',');
                    Console.WriteLine(input[0].LastIndexOf(input[1]));
                }
            }
            //Console.ReadLine();
        }
    }
}
