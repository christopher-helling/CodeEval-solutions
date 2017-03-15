import java.nio.ByteOrder;
public class Main {
    public static void main(String[] args) {
            // Process line of input Here
            if (ByteOrder.nativeOrder().equals(ByteOrder.LITTLE_ENDIAN)) 
            {
                System.out.println("LittleEndian");
            } 
            else 
            {
                System.out.println("BigEndian");
            }
        }
    }
