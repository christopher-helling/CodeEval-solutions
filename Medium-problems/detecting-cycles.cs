using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

                    // push elements to a stack, we will check cycles by searching from the end of the sequence
                    string[] input = line.Split((string[])null, StringSplitOptions.None); // split on whitespace
                    Stack<string> stack = new Stack<string>();
                    Stack<string> resultStack = new Stack<string>(); // need to reverse the results
                    StringBuilder result = new StringBuilder();
                    foreach (string s in input)
                    {
                        stack.Push(s);
                    }

                    string endOfCycle = stack.Pop(); // first element popped is the last element of the cycle
                    resultStack.Push(endOfCycle); // add it to the result stack, it will be last out


                    while (stack.Count > 0)
                    {
                        string nextElement = stack.Pop();

                        if (nextElement.Equals(endOfCycle))
                        {
                            break; // cycle is repeating
                        }
                        else
                        {
                            resultStack.Push(nextElement);
                        }
                        
                    }

                    // print results 
                    while (resultStack.Count > 0)
                    {
                        Console.Write(resultStack.Pop() + " ");
                    }
                    Console.WriteLine(); // new line
                }

            }

        }
    }
}
