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

                // first we will build our matrix using integer arrays
                string[] stringRows = line.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                int[,] matrix = new int[stringRows.Length, stringRows.Length]; // square matrix

                int rowIndex = 0; // need to remember which row we are on
                foreach (string stringRow in stringRows)
                {
                    int columnIndex = 0; // need to remember which row we are on
                    // REVISION - Need to remove empty entries due to poor formatting of input code
                    string[] stringColumns = stringRow.Split((string[])null, StringSplitOptions.RemoveEmptyEntries); // splits on whitespace
                    foreach (string stringColumn in stringColumns)
                    {
                        matrix[rowIndex, columnIndex] = Int32.Parse(stringColumn);
                        columnIndex++;
                    }
                    rowIndex++;
                }


                // we will use an Insertion Sort algorithm on the first row
                InsertionSortAlgorithm(matrix); // square matrix

                bool needToCheckAnotherRow = false;
                int rowNum = 0; // row number
                //List<Tuple<int, int>> indicesToCheck = new List<Tuple<int, int>>();
                //indicesToCheck.Add(new Tuple<int,int>(0, stringRows.Length - 1));// check all columns to start
                // now we need to handle the cases when adjacent entries are equal, and we need to search a lower row
                do
                {
                    int startIndex = 0;
                    while (startIndex < stringRows.Length - 1) // no need to check when only 1 column left
                    {
                        needToCheckAnotherRow = false;
                        int endIndex = startIndex;
                        while ((rowNum == 0 && endIndex < stringRows.Length && matrix[rowNum, startIndex] == matrix[rowNum, endIndex]) || // if first row, only need adjacent entries to be equal
                            (rowNum > 0 && endIndex < stringRows.Length && matrix[rowNum - 1, startIndex] == matrix[rowNum - 1, endIndex] && // otherwise, the current adjacent entries and the 
                            matrix[rowNum, startIndex] == matrix[rowNum, endIndex])) // entries above them must be equal
                        {
                            endIndex++;
                        }
                        endIndex--; // subtract off the one added for equaling itself

                        if (endIndex - startIndex > 0)
                        {
                            needToCheckAnotherRow = true;
                            // when we exit the while loop, the end index has been set to be the last index that matched the initial entry
                            int[,] subMatrix = new int[stringRows.Length - (rowNum + 1), (endIndex - startIndex) + 1]; // (k+1) because first row already sorted, +1 to column number because index 0 to 2 is 3 columns-- (2-0)+1
                            for (int i = 0; i < subMatrix.GetLength(0); i++) // iterate over rows
                            {
                                for (int j = 0; j < subMatrix.GetLength(1); j++) // iterate over columns
                                {
                                    subMatrix[i, j] = matrix[(rowNum + 1) + i, startIndex + j];
                                }
                            }
                            InsertionSortAlgorithm(subMatrix);

                            // need to save SubMatrix back to original matrix
                            for (int i = 0; i < subMatrix.GetLength(0); i++) // iterate over rows
                            {
                                for (int j = 0; j < subMatrix.GetLength(1); j++) // iterate over columns
                                {
                                    matrix[(rowNum + 1) + i, startIndex + j] = subMatrix[i, j];
                                }
                            }

                        }

                        startIndex = endIndex + 1; // set the start index to the number after the one you just checked at endIndex
                    }

                    if (needToCheckAnotherRow)
                    {
                        rowNum++;
                    }
                    

                } while (needToCheckAnotherRow);





                StringBuilder result = new StringBuilder();
                // print out results in same format as the input
                for (int i = 0; i < stringRows.Length; i++)
                {
                    for (int j = 0; j < stringRows.Length; j++)
                    {
                        result.Append(matrix[i, j]).Append(" ");
                    }
                    // at the end of the row, print row delimiter
                    if (i < stringRows.Length - 1) //except for the last row, in which we leave off the delimiter
                    {
                        result.Append("| ");
                    }
                }

                Console.WriteLine(result);

            }

        }

        Console.ReadLine();

    }


    static void InsertionSortAlgorithm(int[,] matrix)
    {
        int numOfRows =  matrix.GetLength(0);
        int numOfColumns = matrix.GetLength(1);
        // we will use an Insertion Sort algorithm on the first row
        for (int i = 1; i < numOfColumns; i++)
        {
            int[] columnToSort = new int[numOfRows]; // column has #row entries, e.g. 3x1 column vector -- 3 rows
            for (int col = 0; col < columnToSort.Length; col++)
            {
                columnToSort[col] = matrix[col, i];
            }
            int j = i - 1;
            while (j >= 0 && matrix[0, j] > columnToSort[0]) // we are sorting the first row of the matrix
            {
                // need to move the entire column
                for (int rowNum = 0; rowNum < numOfRows; rowNum++)
                {
                    matrix[rowNum, j + 1] = matrix[rowNum, j]; // clear a spot for the value to sort by shifting other values to the right
                }

                j--;
            }

            // once you've shifted over the values, insert the valueToSort in the correct position
            for (int rowNum = 0; rowNum < numOfRows; rowNum++)
            {
                matrix[rowNum, j + 1] = columnToSort[rowNum]; // columnToSort stored in a different location in memory
            }

        }
    }


}
