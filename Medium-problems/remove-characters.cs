using System;
using System.IO;
using System.Linq;


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

                string[] inputs = line.Split(new string[] {", "}, StringSplitOptions.None);
                string inputPhrase = inputs[0];
                string[] charsToRemove = inputs[1].ToCharArray().Select(c => c.ToString()).ToArray(); // convert string --> char[] --> string[] so we can use String.Replace()
                // convert input string to character array
                foreach (string c in charsToRemove)
                {
                    inputPhrase = inputPhrase.Replace(c, string.Empty); // replace each character with empty string (i.e. delete it)
                }

                Console.WriteLine(inputPhrase);
            }
        }

    }

}
