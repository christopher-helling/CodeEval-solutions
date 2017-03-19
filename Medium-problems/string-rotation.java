import java.io.*;
public class Main {
    public static void main (String[] args) throws IOException {
        File file = new File(args[0]);
        BufferedReader buffer = new BufferedReader(new FileReader(file));
        String line;
        while ((line = buffer.readLine()) != null) {
            line = line.trim();
            // Process line of input Here
            String[] input = line.split(",");
            String word1 = input[0];
            String word2 = input[1];
            boolean isRotation = false;

            // should refactor this into nicer code - find condition when it is true
            if (word1.length() > 0 && word2.length() > 0 && word1.length() == word2.length())
            {
                int startingIndex = word2.indexOf(word1.charAt(0));
                if (startingIndex > -1)
                {
                    for (int i = startingIndex; i < word2.length(); i++)
                    {
                        // creating unnecessary substrings instead of looping
                        // rearrange word2 to be String from middle of word to end of word + start of word
                        if (word1.equals(word2.substring(i) + word2.substring(0,i)))
                        {
                            isRotation = true;
                            break;
                        }
                    }
                }
            }
                    
            System.out.println(isRotation ? "True" : "False");
        }
    }
}
