import java.io.*;
import java.util.*;


public class Main {
	static HashSet<String> outputSet = new HashSet<String>();
	
    public static void main (String[] args) throws IOException {
        File file = new File(args[0]);
        BufferedReader buffer = new BufferedReader(new FileReader(file));
        String line;

        while ((line = buffer.readLine()) != null) {
            line = line.trim();
            // Process line of input Here
            outputSet.clear();
            String[] input = line.split(",");
            // sort the inputs in alphabetical order (which will remain in alphabetical order after permuting)
            // it is quicker to sort input now than our long list of output later
            char[] inputArray = input[1].toCharArray();
            Arrays.sort(inputArray);
            // save time by only selecting distinct letters of the string
            Set<Character> inputStringSet = new HashSet<Character>();
            for (char c : inputArray)
            {
            	inputStringSet.add(c);
            }
            
            StringBuilder sbInput = new StringBuilder();
            for (char c : inputStringSet)
            {
            	sbInput.append(c);
            }
            
            String inputString = sbInput.toString();

            permuteSetLength("", inputString, Integer.parseInt(input[0]));
            
            StringBuilder sb = new StringBuilder();
            //need to sort set in alphabetical order
            String[] outputArray = outputSet.toArray(new String[outputSet.size()]);
            Arrays.sort(outputArray);
            for (String s : outputArray)
            {
            	sb.append(s).append(",");	
            }
            sb.setLength(sb.length() - 1); // remove trailing comma
        
            System.out.println(sb.toString()); 
        }
        
        buffer.close();
    }    
    
    
    // this function will find all the strings of length k you can make from a set of letters N
    static void permuteSetLength(String prefix, String suffix, int length)
    {
        if (length == 0)
        {
            outputSet.add(prefix);
            return;
        }

        // use dictionary to remove duplicate prefixes, to avoid permuting the same thing again
        Map<String, String> newPrefixesAndSuffixes = new HashMap<String, String>();
        // otherwise, calculate our new prefixes by adding each letter of suffix to the prefix, and decrementing length by 1
        for (int i = 0; i < suffix.length(); i++)
        {
            if (!newPrefixesAndSuffixes.containsKey(prefix + suffix.charAt(i))) // new key
            {
                // suffix stays the same, we will be reusing the same set of letters to choose from
                permuteSetLength(prefix + suffix.charAt(i), suffix, length - 1);
            }

        }
    }   
}
