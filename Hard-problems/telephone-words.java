import java.io.*;
import java.util.*;


public class Main {
	static StringBuilder output = new StringBuilder();
    public static void main (String[] args) throws IOException {
        File file = new File(args[0]);
        BufferedReader buffer = new BufferedReader(new FileReader(file));
        String line;

        while ((line = buffer.readLine()) != null) {
        	output.setLength(0); // clear old results
            line = line.trim();
            // Process line of input Here

            generatePhoneLetters(line);
            
            output.setLength(output.length() - 1); // remove trailing comma
            System.out.println(output);
            
        }
        
        buffer.close();
    }
    
    
    public static void generatePhoneLetters(String input)
    { 
        generatePhoneLetters("", input);
    }
    
    public static void generatePhoneLetters(String prefix, String suffix)
    { 
        
        if (suffix.length() == 0)
        {
            output.append(prefix).append(","); // ending condition
        }
        else 
        {
            int digit = Character.getNumericValue(suffix.charAt(0));

            String keypadValues = keypad.get(digit);
            
            for (int i = 0; i < keypadValues.length(); i++)
            {
                // prefix + the ith character of the suffix is the new prefix
                // then permute the rest of the suffix without that ith character
                generatePhoneLetters(prefix + keypadValues.charAt(i), suffix.substring(1));
            }
        }
    }
    
    private static final Map<Integer,String> keypad = new HashMap<Integer, String>();
    static {
    	keypad.put(0, "0");
        keypad.put(1, "1");
        keypad.put(2, "abc");
        keypad.put(3, "def");
        keypad.put(4, "ghi");
        keypad.put(5, "jkl");
        keypad.put(6, "mno");
        keypad.put(7, "pqrs");
        keypad.put(8, "tuv");
        keypad.put(9, "wxyz");
    }
   
}
