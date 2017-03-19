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
            String[] hexValuesStr = samples[0].trim().split(" ");
            String[] binValuesStr = samples[1].trim().split(" ");
            
            int[] hexArray = new int[hexValuesStr.length];
            for (int i=0; i < hexArray.length; i++) {
            	hexArray[i] = Integer.parseInt(hexValuesStr[i], 16);
            }
            int[] binArray = new int[binValuesStr.length];
            for (int i=0; i < binArray.length; i++) {
            	binArray[i] = Integer.parseInt(binValuesStr[i], 2);
            }
            
            int hexValues = 0;
            for (int i = 0; i < hexArray.length; i++)
            {
            	hexValues += hexArray[i];
            }
            int binValues = 0;
            for (int i = 0; i < binArray.length; i++)
            {
            	binValues += binArray[i];
            }
             
            System.out.println(binValues >= hexValues ? "True" : "False");
            
        }
        
        buffer.close();
    }   
}
