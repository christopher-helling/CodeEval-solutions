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

                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line.LastIndexOf(line[i]) == line.IndexOf(line[i])) // compare last index of character against first occurrence index
                        {
                            Console.WriteLine(line[i]);
                            break;
                        }
                    }
                    
                }

            }
        }
    }
