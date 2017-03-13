import java.io.*;
import java.util.*;


public class Main {
    public static void main (String[] args) throws IOException {
        List<Integer> mersenneNumbersFound = new ArrayList<Integer>();
        List<Integer> smallPrimes = new ArrayList<Integer>();
        smallPrimes.add(2);
        smallPrimes.add(3);
        smallPrimes.add(5);
        smallPrimes.add(7);
        smallPrimes.add(11);
        
        // 2^11 = 2048, 2^12 = 4096 -- check up to the 11th power
        for (int i : smallPrimes) // loop through small primes to get required Mersenne numbers
        {
            int candidate = (int) Math.pow(2, i) - 1;
            mersenneNumbersFound.add(candidate);
        }
        
        File file = new File(args[0]);
        BufferedReader buffer = new BufferedReader(new FileReader(file));
        String line;
        while ((line = buffer.readLine()) != null) {
            line = line.trim();
            // Process line of input Here

            int input = Integer.parseInt(line);
            StringBuilder result = new StringBuilder();
            for (int prime : mersenneNumbersFound)
            {
                if (prime < input)
                {
                    result.append(prime).append(", "); // note the comma and the space this time
                }
                else 
                {
                    break; // no need to check after input >= prime, because our list is ordered
                }
            }

            if (result.length() > 0)
            {
            	result.setLength(result.length() - 2); // delete superfluous comma and space from last prime
            }
            System.out.println(result); // print list of primes
            
        }
        
        buffer.close();
    }
}
