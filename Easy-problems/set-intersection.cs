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

                    // 2 list separated by a semicolon
                    string[] lists = line.Split(';');

                    // numbers separated by commas
                    string[] set1 = lists[0].Split(',');
                    string[] set2 = lists[1].Split(',');

                    // empty string for output, in case no intersection found
                    string output = "";
                    //convert IEnumerable<string> to string
                    output = String.Join(",", set1.Intersect(set2));

                    Console.WriteLine(output);
                }
                //Console.ReadLine();
            }
        }
    }
}
