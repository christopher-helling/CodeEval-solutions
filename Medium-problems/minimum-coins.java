import java.io.*;
public class Main {
    public static void main (String[] args) throws IOException {
        File file = new File(args[0]);
        BufferedReader buffer = new BufferedReader(new FileReader(file));
        String line;
        while ((line = buffer.readLine()) != null) {
            line = line.trim();
            // Process line of input Here
            int total = Integer.parseInt(line);
            int numCoinsNeeded = 0;
            // we have coins of length 5, 3, 1. Use as many as possible in order
            while (total > 0)
            {
                if (total >= 5)
                {
                    numCoinsNeeded = total / 5; // integer division, still have a remainder
                    total -= (5 * numCoinsNeeded); // e.g. if we have total = 23, 4 coins of value 5, then 23 - (23/5) = 23 - 20 = 3
                }
                else if (total == 3 || total == 4)
                {
                    numCoinsNeeded++;
                    total -= 3; // never going to use more than 1 coin of value 3. 6 = 3+3 = 5+1, 9 = 3+3+3 = 5+3+1, only gets worse from there and we use max# of 5-coins
                }
                else // total = 1 or 2 
                {
                    numCoinsNeeded += total;
                    total = 0;
                }
            }
            System.out.println(numCoinsNeeded);    
        }
    }
}
