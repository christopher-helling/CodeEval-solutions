import java.io.*;
import java.util.*;


public class Main {
    public static void main (String[] args) throws IOException {
        File file = new File(args[0]);
        BufferedReader buffer = new BufferedReader(new FileReader(file));
        String line;

        while ((line = buffer.readLine()) != null) {
            line = line.trim();
            // Process line of input Here

            int numberOfSolutions = 0;
            char[] tempArray = new char[4];
            char[] solution = { 'c', 'd', 'e', 'o' }; // sort "code" into alphabetical order to save sorting time later
            String[] rows = line.split(" \\| "); // including the spaces in the string split so we have only letters in each row
            for (int i = 0; i < rows.length - 1; i++) // since we are searching for a 2x2 matrix, don't check last row or column
            {
                for (int j = 0; j < rows[i].length() - 1; j++) // assuming input has constant number of columns
                {
                    // check if the current entry of matrix is in "code"
                    switch (rows[i].charAt(j))
                    { 
                        case 'c':
                        case 'o':
                        case 'd':
                        case 'e':
                            tempArray[0] = rows[i].charAt(j);
                            tempArray[1] = rows[i+1].charAt(j);
                            tempArray[2] = rows[i].charAt(j+1);
                            tempArray[3] = rows[i+1].charAt(j+1);
                            // check if all letters of solution array are found in temp array
                            Arrays.sort(tempArray);
                            if (Arrays.equals(solution, tempArray))
                            {
                                numberOfSolutions++; // found a solution
                            }
                            break;
                    }
                }
            }
            System.out.println(numberOfSolutions);   
        }   
        buffer.close();
    }   
}
