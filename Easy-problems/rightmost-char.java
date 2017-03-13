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

            String[] input = line.split(",");
            System.out.println(input[0].lastIndexOf(input[1]));
        }
        
        buffer.close();
    }
    
}

