using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


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

                Stack<double> prefixStack = new Stack<double>();
                string[] prefixExpression = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries); // default string split removes whitespace
                Array.Reverse(prefixExpression); // we want to read the array from right to left
                double operand = 0;
                foreach (string stringInput in prefixExpression)
                {
                    // Need to use doubles due to rules on c# integer division omitting remainder
                    if (Double.TryParse(stringInput, out operand)) // if integer parse works, it's an operand, not an operator
                    {
                        prefixStack.Push(operand);
                    }
                    else // otherwise it's an operator-- could also have used Char.IsSymbol() to check for operators
                    {
                        double leftOperand = prefixStack.Pop(); // we read right-to-left, so LIFO means left operand was last
                        double rightOperand = prefixStack.Pop();
                        double result = 0;

                        switch (stringInput) // operator
                        {
                            case "+":
                                result = leftOperand + rightOperand;
                                break;
                            case "-":
                                result = leftOperand - rightOperand;
                                break;
                            case "*":
                                result = leftOperand * rightOperand;
                                break;
                            case "/":
                                result = leftOperand / rightOperand;
                                break;
                        }

                        prefixStack.Push(result);
                    }
                }

                Console.WriteLine(prefixStack.Peek()); // only one element left in stack after the foreach loop, which is our final result
                
            }

        }
        Console.ReadLine();
    }

}
