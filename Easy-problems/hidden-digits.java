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


            String dictLetters = "abcdefghij";
            String dictNumbers = "0123456789";
            StringBuilder result = new StringBuilder();
            for (char letter : line.toCharArray())
            {
                if (dictLetters.indexOf(letter) > -1)
                {
                    result.append(dictLetters.indexOf(letter));
                }
                else if (dictNumbers.indexOf(letter) > -1)
                {
                    result.append(letter);
                }
            }

            if (result.length() == 0)
            {
                result.append("NONE");
            }

            System.out.println(result);
            
        }
        
        buffer.close();
    }
    
    
    
}
