using System;
using System.IO;
using System.Linq;

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
                    string[] samples = line.Split('|');
                    string[] hexValues = samples[0].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    string[] binValues = samples[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    // just separating all these arrays out for readability
                    int[] hexInts = Array.ConvertAll(hexValues, c => Convert.ToInt32(c, 16));
                    int[] binInts = Array.ConvertAll(binValues, c => Convert.ToInt32(c, 2));

                    if (binInts.Sum() >= hexInts.Sum())
                    {
                        Console.WriteLine("True");
                    }
                    else 
                    {
                        Console.WriteLine("False");
                    }
                }
            }


            Console.ReadLine();

        }
    }

}
