using System;
using System.IO;


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

                int numIterations = 0;
                while (numIterations < 100)
                {
                    char[] charArray = line.ToCharArray();
                    // check palindrome
                    if (isPalindrome(charArray))
                    {
                        break;
                    }

                    // else perform iteration
                    int number = Int32.Parse(new string(charArray));
                    Array.Reverse(charArray); // reverse the character array
                    int numberFlipped = Int32.Parse(new string(charArray));

                    // set new number
                    line = (number + numberFlipped).ToString();
                    numIterations++;
                }

                Console.WriteLine(numIterations + " " + line);
                

            }

        }


    }

    static bool isPalindrome(char[] charArray)
    {
        int numOfDigits = charArray.Length;
        for (int i = 0; i < numOfDigits / 2; i++) // length 4 = 2 checks (1,4 and 2,3), length 5 = 2 checks (1,5 and 2,4 -- 3,3 doesn't need to be checked)
        {
            if (charArray[i] != charArray[(numOfDigits - 1) - i])
            {
                return false;
            }
        }
        return true;
    }

}
