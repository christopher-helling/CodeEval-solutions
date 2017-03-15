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
            String[] lists = line.split(";");
            String[] firstList = lists[0].split(",");
            String[] secondList = lists[1].split(",");
            
            Set<String> set1 = new HashSet<String>(Arrays.asList(firstList));
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < secondList.length; i++)
            {
            	if (set1.contains(secondList[i]))
            	{
            		sb.append(secondList[i]).append(",");
            	}
            }
            
            if (sb.length() > 0)
            {
            	sb.setLength(sb.length() - 1); // delete trailing comma
            }
            

            System.out.println(sb.toString());
            
        }
        
        buffer.close();
    }   
}
