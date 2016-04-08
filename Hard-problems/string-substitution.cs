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

                string[] inputs = line.Split(';'); // semi-colon separates the input number and the strings to replace
                string inputString = inputs[0]; // first number is the main string

                // REVISION! Some of the inputs are poorly formatted, e.g. one long string with no semicolon, no commas/strings to split, etc
                if (inputs.Length > 1)
                {
                    string[] replacementStrings = inputs[1].Split(','); // sequence separated by commas
                    // using alphabet as placeholders, so that replaced strings are not overwritten
                    char[] alphabet = Enumerable.Range('A', 26).Select(x => (char)x).ToArray(); // also counting on the fact there won't be more than 26 replacement strings


                    for (int i = 0; i < replacementStrings.Length; i = i + 2)  // 0, 2, 4, ... are strings to replace
                    {
                        string[] tempArray = inputString.Split(new string[] { replacementStrings[i] }, StringSplitOptions.None); // split on the stringToReplace -- keep empty entries for when string is replaced multiple times in a row (e.g. split on '10' in string '1010')
                        
                        if (tempArray.Length > 1) // length = 0 means string wasn't found and thus there is nothing to replace
                        {
                            StringBuilder tempResult = new StringBuilder();
                            foreach (string tempString in tempArray)
                            {
                                tempResult.Append(tempString).Append(alphabet[i / 2]); // alphabet[i/2] because we are looping through 0, 2, 4, ...
                            }
                            tempResult.Length--; // delete extra letter added to the end of the result in the above foreach loop -- 1110111 split on 0 --> [111,111] --> 111A111A --> 111A111
                            inputString = tempResult.ToString(); // 1110111 --> 111A111 is new input
                        }

                    }


                    // now we have a string like 1101A1BC001D1 -- need to replace the placeholder strings to the replacement strings
                    for (int i = 1; i < replacementStrings.Length; i = i + 2) // 1, 3, 5, ... are strings to replace
                    {
                        string[] tempArray = inputString.Split(new char[] { alphabet[(i - 1) / 2] }, StringSplitOptions.None); // split on the placeholder
                        

                        if (tempArray.Length > 1) // length = 0 means string wasn't found and thus there is nothing to replace
                        {
                            StringBuilder tempResult = new StringBuilder();
                            foreach (string tempString in tempArray)
                            {
                                tempResult.Append(tempString).Append(replacementStrings[i]); //replacementStrings[odd] are the replacements
                            }
                            for (int j = 0; j < replacementStrings[i].Length; j++)
                            {
                                tempResult.Length--; // delete extra replacementString
                            }
                            inputString = tempResult.ToString(); // 111A111 --> 1110111 is output
                        }

                        
                    }

                }

                Console.WriteLine(inputString);
            }

        }

    }

}
