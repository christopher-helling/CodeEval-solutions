using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


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

                string[] input = line.Split((string[])null, StringSplitOptions.None); // split on whitespace
                Stack<string> stack = new Stack<string>();
                StringBuilder result = new StringBuilder();
                foreach (string s in input)
                {
                    stack.Push(s);
                }
                int count = 0; // only want to print even number index
                while (stack.Count > 0)
                {
                    if (count % 2 == 0)
                    {
                        result.Append(stack.Pop()).Append(" ");
                    }
                    else 
                    {
                        stack.Pop();
                    }
                    count++;
                }

                if (result.Length > 0)
                {
                    result.Length--; // subtract off added space
                }

                Console.WriteLine(result);
            }

            Console.ReadLine();

        }

    }

}
