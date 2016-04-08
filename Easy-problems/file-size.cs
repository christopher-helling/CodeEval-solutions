using System;
using System.IO;

namespace CodeEval
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo file = new FileInfo(args[0]);

            Console.WriteLine(file.Length); // prints file size in bytes

        }
    }
}
