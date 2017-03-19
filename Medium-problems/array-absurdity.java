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
            String[] input = line.split(";");
            int arraySize = Integer.parseInt(input[0]);
            String[] arrayStr = input[1].split(",");

            int[] array = new int[arrayStr.length];
            for (int i=0; i < array.length; i++) {
                array[i] = Integer.parseInt(arrayStr[i]);
            }
                   
            // array contains all values from 0 to n-2, so we can find the duplicate by subtracting array sum from the sum of 0 to n-2
            // sum of 0 + 1 + 2 + ... + n = n(n+1)/2, so sum of 0 to n-2 is (n-1)(n-2) / 2
            int expectedSum = ((arraySize - 1) * (arraySize - 2)) / 2;
            int arraySum = 0;
            for (int i = 0; i < array.length; i++)
            {
            	arraySum += array[i];
            }
            
            int duplicateValue = arraySum - expectedSum;
        
            System.out.println(duplicateValue); 
        }
        
        buffer.close();
    }  
}
