using System;
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

                // first we will build our matrix using integer arrays
                string[] stringRows = line.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

                // get number of columns
                int numOfColumns = 0;
                if (stringRows.Length > 0)
                {
                    numOfColumns = (stringRows[0].Split((string[])null, StringSplitOptions.RemoveEmptyEntries)).Length; // splits first line on whitespace
                }

                int[,] matrix = new int[stringRows.Length, numOfColumns];

                int rowIndex = 0; // need to remember which row we are on
                foreach (string stringRow in stringRows)
                {
                    int columnIndex = 0; // need to remember which row we are on
                    string[] stringColumns = stringRow.Split((string[])null, StringSplitOptions.RemoveEmptyEntries); // splits on whitespace
                    foreach (string stringColumn in stringColumns)
                    {
                        matrix[rowIndex, columnIndex] = Int32.Parse(stringColumn);
                        columnIndex++;
                    }
                    rowIndex++;
                }

                int numOfRows =  matrix.GetLength(0);
                // int numOfColumns = matrix.GetLength(1); // no need for this command, we found numOfColumns earlier

                // now print maximum value in each column 
                StringBuilder result = new StringBuilder();
                for (int j = 0; j < numOfColumns; j++) // start by looking at a given column
                {
                    int localMax = -1001; // question states minimum value allowed is -1000, setting this to be less than -1000 make it easier to spot errors

                    for (int i = 0; i < numOfRows; i++) // then loop through the rows to find the max value in this column
                    {
                        if (matrix[i, j] > localMax)
                        {
                            localMax = matrix[i, j];
                        }
                    }

                    result.Append(localMax).Append(" ");
                }

                result.Length--; // delete trailing space from result
                Console.WriteLine(result);
            }

        }

        Console.ReadLine();


    }



}
