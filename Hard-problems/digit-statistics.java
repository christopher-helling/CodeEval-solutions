import java.io.*;
import java.util.*;


public class Main {
    public static void main (String[] args) throws IOException {
        File file = new File(args[0]);
        BufferedReader buffer = new BufferedReader(new FileReader(file));
        String line;
        
        Map<Integer, int[]> repeatingSequences = new HashMap<Integer, int[]>();
        repeatingSequences.put(2, new int[] { 2, 4, 8, 6 });
        repeatingSequences.put(3, new int[] { 3, 9, 7, 1 });
        repeatingSequences.put(4, new int[] { 4, 6 });
        repeatingSequences.put(5, new int[] { 5 });
        repeatingSequences.put(6, new int[] { 6 });
        repeatingSequences.put(7, new int[] { 7, 9, 3, 1 });
        repeatingSequences.put(8, new int[] { 8, 4, 2, 6 });
        repeatingSequences.put(9, new int[] { 9, 1 });

        while ((line = buffer.readLine()) != null) {
            line = line.trim();
            // Process line of input Here
            String[] input = line.split(" ");
            int a = Integer.parseInt(input[0]);
            
            long n = Long.parseLong(input[1]);
            long[] digitCount = new long[10]; // digitCount[i] = j means the digit i appears j times
            // n >= 1, initialize digitCount with values from dictionary
            for (int i : repeatingSequences.get(a))
            {
                digitCount[i]++;
            }

         // then we perform integer division (no remainder) to see how many times this sequence will appear
            long timesRepeated = n / repeatingSequences.get(a).length; // n divided by length of repeating sequence
            for (int i = 0; i < 10; i++)
            {
                if (digitCount[i] > 0)
                {
                    digitCount[i] = timesRepeated * digitCount[i];
                }
            }

            // now we take the remainder after dividing 
            int remainder = (int)(n % repeatingSequences.get(a).length);
            for (int i = 0; i < remainder; i++)
            {
                digitCount[repeatingSequences.get(a)[i]]++; // get corresponding Dict (indexed by input[0], take the ith element of that array, increase that digit's count
            }

            // output
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++) // digit count is 10
            {
                sb.append(i).append(": ").append(digitCount[i]).append(", ");
            }
            sb.setLength(sb.length() - 2); // delete final ", " characters                   
            System.out.println(sb.toString()); 
        }
        
        buffer.close();
    }    
}
