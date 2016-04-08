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

                    int depth = Int32.Parse(line); // depth of Pascal's triangle, index starting at 1
                    

                    for (int rowNum = 1; rowNum <= depth; rowNum++)
                    {
                        int currentValue = 1; // we will use this to calculate successive terms of the triangle
                        int[] rowOutput = new int[rowNum]; // 1st row has 1 element, 2nd row has 2, etc
                        rowOutput[0] = 1; // set the first and last elements to 1
                        rowOutput[rowNum - 1] = 1; // note here that it's actually rowOutput[rowNum - 1] = currentValue, where colNum = rowNum - 1 (being the index of the last element of the row)

                        for (int colNum = 1; colNum < (int) Math.Ceiling((double) rowNum / 2); colNum++) // note that N-th row of Pascal's triangle has N columns
                        {
                            // use the identity C(n, k+1) = C(n, k) * (n - k) / (k + 1)
                            currentValue = currentValue * (rowNum - colNum) / (colNum); // this is n choose k: n is the rowNum, k is the colNum - not that it is divided by colNum instead of (colNum+1) due to our index

                            // set both ends of the triangle at once, so we only need calculate n/2 values per row
                            rowOutput[colNum] = currentValue;
                            rowOutput[rowNum - 1 - colNum] = currentValue;
                        }

                        for (int i = 0; i < rowOutput.Length; i++)
                        {
                            Console.Write(rowOutput[i] + " "); // Write our output on a single line
                        }
                        
                    }

                    Console.WriteLine(); // line break for each line of input
                    
                }

            }
        }
    }

}
