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

            String[] samples = line.split("\\|"); // must delimit pipe to split in regex
            int hexValues = Arrays.asList(samples[0].trim().split(" ")).stream().mapToInt(s -> Integer.parseInt(s, 16)).sum();
            int binValues = Arrays.asList(samples[1].trim().split(" ")).stream().mapToInt(s -> Integer.parseInt(s, 2)).sum();
            
            System.out.println(binValues >= hexValues ? "True" : "False");
            
        }
        
        buffer.close();
    }
    
    
    
}
