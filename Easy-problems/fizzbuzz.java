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
            String[] inputArguments = line.split(" "); 
            int fizz = Integer.parseInt(inputArguments[0]);
            int buzz = Integer.parseInt(inputArguments[1]);
            int N = Integer.parseInt(inputArguments[2]);
            StringBuilder output = new StringBuilder();

            for (int i = 1; i <= N; i++)
            {
                String result = "";
                if (i % fizz == 0)
                    result = "F";
                if (i % buzz == 0)
                    result += "B";
                if (result.equals("")) // failed the first two if's, but prevents 3rd modulo check
                    result = Integer.toString(i);
                output.append(result).append(" "); // add the result and a space to the output line
            }

            System.out.println(output);
            
        }
        
        buffer.close();
    }
    
    
    
}
