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

                    int sumOfDigits = 0;

                    foreach (char c in line)
                    {
                        sumOfDigits += Int32.Parse(c.ToString()); // take digit char --> string --> int
                    }
                    


                    // print result 
                    Console.WriteLine(sumOfDigits);
                }
            }

        }
    }
}
