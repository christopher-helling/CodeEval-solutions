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

                    int decimalValue = Int32.Parse(input[0]); // convert to int 

                    // print result 
                    Console.WriteLine(Convert.ToString(decimalValue, 2)); // convert decimal value to base 2
                }

            }

        }
    }
}
