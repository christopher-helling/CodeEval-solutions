import java.io.*;
import java.util.*;


public class Main {
	static StringBuilder output = new StringBuilder();
	
    public static void main (String[] args) throws IOException {
        File file = new File(args[0]);
        BufferedReader buffer = new BufferedReader(new FileReader(file));
        String line;
        while ((line = buffer.readLine()) != null) {
            line = line.trim();
            // Process line of input Here
            
            char[] charsOfString = line.toCharArray();
            // character sort for problem: digits < upper case letters < lower case letters
            // can use default .sort() for this
            Arrays.sort(charsOfString);
            
            // input string now sorted according to problem's rules
            String input = new String(charsOfString);

            // clear the old output
            output.setLength(0);
            
            // perform the permutations
            permutation(input);

            output.deleteCharAt(output.length() - 1); // remove trailing comma

            System.out.println(output);
            
        }
        
        buffer.close();
    }
    
    public static void permutation(String str) { 
        permutation("", str); 
    }

    private static void permutation(String prefix, String str) {
        int n = str.length();
        if (n == 0)
        {
        	output.append(prefix).append(",");
        }
        else {
            for (int i = 0; i < n; i++)
                permutation(prefix + str.charAt(i), str.substring(0, i) + str.substring(i+1, n));
        }
    }
    
}
