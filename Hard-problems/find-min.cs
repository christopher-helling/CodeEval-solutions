using System;
using System.IO;
using System.Linq;

namespace CodeEval
{
    class Program
    {
        /**
         * General idea. we start with the first k values, e.g. k=4, m = [4,1,1,1]. The following facts are true after we populate our first k elements:
         * 1. The values can be no larger than k, e.g. in (0, 1, 2, ... k) by the pigeonhole principle. If we have m[0], m[1], ..., m[k-1] (k numbers), 
         * then m[k] is the smallest (min) number not among these. For m[k] > k, this would mean we ave every number from0 to k (k+1 numbers) here. Contradiction.
         * 2. Since we are only considering the previous k elements, and no element larger than k can appear in the previous k elements, we will see every number
         * from 0 to k represented from m[k] to m[2k]. I.e. we look at k elements at a time (the previous k elements), so after one cycle, every time we move our 
         * range of k elements, the element popped off is the next to add.
         * E.g. [3,1,4,1] 0, 2, 3, 4, 1 ; 0, 2, 3, 4, 1 ...
         * 3. Consequently, we are only interested in the first cycle of numbers to add (the 0,2,3,4,1 part). Furthermore, n will fall among these values, so when 
         * we want to find the nth element, we take it mod (k+1) (the cycle length from 0 to k), and we can stop computing once we have reached it.
         * 4. I used an array of -1's as a way to keep track of missing values without needing to sort. The number is represented by its index in the array (which
         * means it is already sorted from 0 to k), where a -1 means the value is in use, otherwise the value equals itself. This way I can quickly check the smallest
         * number not in use in the previous k elements by simply looping through this array and stopping at the first value > -1. E.g. for [3,1,4,1] --> [0, -1, 2, -1, -1].
         * 5. I used the Int32 datatype since CodeEval won't use huge inputs, but this should be refactored for larger inputs.
         **/
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    // do something with line
                    long[] input = line.Split(',').Select(s => long.Parse(s)).ToArray();

                    // NOTE: these Int32 should be swapped for a larger datatype to handle very large inputs we calculating initial sequence
                    // (and in general to handle larger inputs)
                    // given n,k,a,b,c,r in input
                    int n = (int)input[0];
                    int k = (int)input[1];
                    int stoppingIndex = (n + 1) % (k + 1); // don't need to find m[n-1] since the added elements are cyclical, we can thus stop at the appropriate index

                    if (stoppingIndex == 0)
                    {
                        stoppingIndex = k; // if stoppingIndex is "0" in above calculation, we need to calculate m values from m[k] up to m[2k], not m[k] to m[k+0]
                    }

                    int[] m = new int[k + stoppingIndex]; // don't need array of size m[n], since we will stop before calculating the extra values anyway
                    
                    // we will keep track of missing values with an array of -1's. If index i has a value != -1, it does not appear in the array m
                    // e.g. m = [3,1,4,1] --> missingValues = [0, -1, 2, -1, -1]. This will be useful when we need min (first nonnegative value) and can maintain sorting of missingValues
                    int[] missingValues = Enumerable.Range(0,k+1).ToArray(); // size k+1 = {0, 1, 2, ..., k}

                    m[0] = (int)input[2]; // a
                    // mark it found in our table of missingValues
                    if (m[0] <= k)
                    {
                        missingValues[m[0]] = -1;
                    }

                    for (int i = 1; i < k; i++)
                    {
                        // generate known part of the sequence pseudorandomly
                        m[i] = (int)((input[3] * m[i - 1] + input[4]) % input[5]); // m[i] = (b * m[i - 1] + c) % r, 0 < i < k 

                        // mark it found in our table of missingValues
                        if (m[i] <= k)
                        {
                            missingValues[m[i]] = -1;
                        }
                    }

                    // here we will populate k to 2k, but stop sooner when possible
                    for (int i = 0; i < stoppingIndex; i++)
                    {
                        // find minimum of missingValues by finding the first entry != -1
                        m[i + k] = findMinMissingValue(missingValues);
                        missingValues[m[i + k]] = -1; // mark this number used, i.e. no longer missing

                        bool willBecomeMissingValue = true;
                        if (m[i] <= k) // the numbers m[k] to m[2k] are a cyclic permutation of (k+1) = {0, 1, 2, ..., k}, no need to check numbers bigger than k
                        {
                            // we are determining the value of m[i+k]. m[i] is just about to be out of range of "the previous k numbers", so we check if it will become a missing value
                            for (int j = i + 1; j < n && j <= i + k; j++) // check range m[i+1] to m[i+k+1], don't check past m[n-1]
                            {
                                if (m[j] == m[i])
                                {
                                    willBecomeMissingValue = false;
                                    break;
                                }
                            }

                        }
                        else
                        {
                            willBecomeMissingValue = false; // this number is too big to be missing, e.g. > k
                        }

                        if (willBecomeMissingValue)
                        {
                            missingValues[m[i]] = m[i];
                        }
                    }

                        
                    Console.WriteLine(m[m.Length-1]); // m[n-1]
                }
            Console.Read();
        }



        public static int findMinMissingValue(int[] missingValues)
        {
            int minValue = -1;
            for (int j = 0; j < missingValues.Length; j++)
            {
                if (missingValues[j] > -1)
                {
                    minValue = missingValues[j];
                    break;
                }
            }
            return minValue;
        }
    }
}
