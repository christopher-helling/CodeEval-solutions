using System;

class Program
{
    static void Main()
    {
        // do something
        if (BitConverter.IsLittleEndian)
        {
            Console.WriteLine("LittleEndian");
        }
        else
        {
            Console.WriteLine("BigEndian");
        }

    }
}
