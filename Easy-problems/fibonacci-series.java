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

            int input = Integer.parseInt(line);
            
            if (input == 0 || input == 1)
                System.out.println(input);
            else 
            {
                int f_prev = 0;
                int f_curr = 1;
                int f_next = 1;
                for (int i = 1; i < input; i++)
                {
                    f_next = f_prev + f_curr;
                    f_prev = f_curr;
                    f_curr = f_next;
                }

                System.out.println(f_next);
            }
            
        }
        
        buffer.close();
    }
    
    
    
}
