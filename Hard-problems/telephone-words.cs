using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeEval
{
    class Program
    {
        static StringBuilder output = new StringBuilder();
        static void Main(string[] args)
        {
        
            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    output.Clear(); // clear old results
                    string line = reader.ReadLine();
                    if (String.IsNullOrEmpty(line))
                        continue;
                    // do something with line
                    generatePhoneLetters(line);
                    
                    output.Length--; // remove trailing comma
                    Console.WriteLine(output);
                    
                }
            }
            Console.ReadLine();
        }

       public static void generatePhoneLetters(string input)
        { 
            generatePhoneLetters("", input);
        }

        public static void generatePhoneLetters(string prefix, string suffix)
        { 
            
            if (suffix.Length == 0)
            {
                output.Append(prefix).Append(","); // ending condition
            }
            else 
            {
                int digit = Int32.Parse(suffix[0].ToString());

                foreach (char c in keypad[digit])
                {
                    // prefix + the ith character of the suffix is the new prefix
                    // then permute the rest of the suffix without that ith character
                    generatePhoneLetters(prefix + c, suffix.Substring(1));
                }
            }


        }

        public static readonly Dictionary<int, string> keypad = new Dictionary<int, string>()
        {{0, "0"}, {1, "1"}, {2, "abc"}, {3, "def"}, {4, "ghi"},
            {5, "jkl"}, {6, "mno"}, {7, "pqrs"}, {8, "tuv"}, {9, "wxyz"}};

            

    }
}
