using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

                    string[] input = line.Split(new char[] { ',' }, StringSplitOptions.None); // split on comma
                    int numOfParticipants = Int32.Parse(input[0]);
                    int positionToKill = Int32.Parse(input[1]);
                    StringBuilder orderOfDeaths = new StringBuilder();

                    List<int> listOfParticipants = new List<int>();
                    for (int i = 0; i < numOfParticipants; i++)
                    {
                        listOfParticipants.Add(i);
                    }

                    int currentPosition = 0;

                    while (listOfParticipants.Count > 0)
                    {
                        // note we subtract 1 because if with kill every 2nd person, index 0 lives and index 1 dies -- (0 + 2 - 1)
                        currentPosition = (currentPosition + positionToKill - 1) % listOfParticipants.Count; // modulus the length of list to wrap around to beginning
                        orderOfDeaths.Append(listOfParticipants[currentPosition]).Append(" "); // add to list of deaths
                        listOfParticipants.Remove(listOfParticipants[currentPosition]); // remove from list of living players
                    }

                    // print result 
                    Console.WriteLine(orderOfDeaths);
                }
            }

        }
    }
}
