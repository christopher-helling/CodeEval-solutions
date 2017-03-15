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

                    int val = Int32.Parse(line); // convert to int 

                    // print result 
                    Console.WriteLine(Convert.ToString(val, 2)); // convert decimal value to base 2
                }

            }

        }
    }
}
