using System;
using System.IO;
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

                string[] inputs = line.Split(new string[] {" | "}, StringSplitOptions.RemoveEmptyEntries);

                // need to find the repeating word
                // construct word of length input[0] from parsed list, search unsplit string for match
                int repeatedWordLength = Int32.Parse(inputs[0]);
                string repeatedWord = "";
                // get UTF-16 encoded character value of last letter-- 
                // we will compare this to the last letter of the repeated word, to find the fixed N offsetting the message
                int lastLetter = Convert.ToChar(inputs[1]); // string --> byte array --> integer
                string[] encodedMessageString = inputs[2].Split((string[])null, StringSplitOptions.RemoveEmptyEntries); // split on whitespace
                
                
                for (int i = 0; i <= encodedMessageString.Length - repeatedWordLength; i++)
                {
                    StringBuilder testWordSB = new StringBuilder();
                    for (int j=0; j < repeatedWordLength; j++)
                    {
                        testWordSB.Append(encodedMessageString[i + j]).Append(" ");
                    }
                    testWordSB.Length--; // delete extra space

                    string testWord = testWordSB.ToString();

                    string[] testSplit = inputs[2].Split(new string[] { testWord }, StringSplitOptions.None);
                    // check the word was found twice AND that it was either preceded or ended with a space in the converted sentence
                    if (testSplit.Length > 2) // our test word was found twice -- thus split to 3 parts
                    {
                        // get last digit of before the split and first one after the split, to see if they match (both integer value for spaces)
                        // otherwise "The needs of the many outweight the needs of the few" repeats on e.g. 5 character sequence "he ne" instead of "needs"
                        string[] beforeSplit = testSplit[0].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                        string[] afterSplit = testSplit[1].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                        int lastDigitBeforeSplit = Int32.Parse(beforeSplit[beforeSplit.Length - 1]);
                        int firstDigitAfterSplit = Int32.Parse(afterSplit[0]);

                        if (lastDigitBeforeSplit == firstDigitAfterSplit) // surrounded by spaces
                        {
                            repeatedWord = testWord;
                            break;
                        }
                    }
                }

                // repeatedWord[repeatedWord.Length - 1] is the character value of the last letter of the repeated word
                string[] repeatedWordArray = repeatedWord.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                int unknownConstant = Int32.Parse(repeatedWordArray[repeatedWordArray.Length - 1]) - lastLetter;

                int[] encodedMessageIntegers = Array.ConvertAll(encodedMessageString, Int32.Parse); // convert to array of integers
                
                char[] decodedMessage = Array.ConvertAll(encodedMessageIntegers, element => (char)(element - unknownConstant)); // subtract off fixed integer to decrypt
                
                // output
                Console.WriteLine(new string(decodedMessage));

            }

        }

    }


}
