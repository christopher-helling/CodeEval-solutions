using System;
using System.IO;

namespace CodeEval
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {

                    string line = reader.ReadLine();
                    if (String.IsNullOrEmpty(line))
                        continue;
                    // do something with line

                    int input = int.Parse(line);

                    if (input == 0 || input == 1)
                        Console.WriteLine(input);
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

                        Console.WriteLine(f_next);
                    }
                }
            }


            //Console.ReadLine();

        }
    }

}
