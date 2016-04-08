using System;
using System.IO;
using System.Linq;
using System.Text;


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
                char[] dictLetters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
                char[] dictNumbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                StringBuilder result = new StringBuilder();
                foreach (char letter in line)
                {
                    if (Array.IndexOf(dictLetters, letter) > -1)
                    {
                        result.Append(Array.IndexOf(dictLetters, letter));
                    }
                    else if (Array.IndexOf(dictNumbers, letter) > -1)
                    {
                        result.Append(letter);
                    }
                }

                if (result.Length == 0)
                {
                    result.Append("NONE");
                }

                Console.WriteLine(result);
                
            }

        }

    }
}
