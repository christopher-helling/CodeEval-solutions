using System;
using System.IO;
using System.Linq;


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
                int numberOfSolutions = 0;
                char[] tempArray = new char[4];
                char[] solution = { 'c', 'o', 'd', 'e' };
                string[] rows = line.Split(new[] {" | "}, StringSplitOptions.None); // including the spaces in the string split so we have only letters in each row
                for (int i = 0; i < rows.Length - 1; i++) // since we are searching for a 2x2 matrix, don't check last row or column
                {
                    for (int j = 0; j < rows[i].Length - 1; j++) // assuming input has constant number of columns
                    {
                        // check if the current entry of matrix is in "code"
                        switch (rows[i][j])
                        { 
                            case 'c':
                            case 'o':
                            case 'd':
                            case 'e':
                                tempArray[0] = rows[i][j];
                                tempArray[1] = rows[i + 1][j];
                                tempArray[2] = rows[i][j + 1];
                                tempArray[3] = rows[i + 1][j + 1];
                                if (solution.All(tempArray.Contains))
                                {
                                    numberOfSolutions++; // found a solution
                                }
                                break;
                        }
                    }
                }

                Console.WriteLine(numberOfSolutions);
                
            }

        }

    }
}
