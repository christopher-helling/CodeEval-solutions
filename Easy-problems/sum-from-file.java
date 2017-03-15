import java.io.*;

public class Main {
    public static void main (String[] args) throws IOException {
        File file = new File(args[0]);
        BufferedReader buffer = new BufferedReader(new FileReader(file));
        String line;
        int total = 0;

        while ((line = buffer.readLine()) != null) {
            line = line.trim();
            // Process line of input Here

            total += Integer.parseInt(line);  
        }
        
        System.out.println(total);
        
        buffer.close();
    }  
}
