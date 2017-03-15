using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace CodeEval
{
    class Program
    {
        static void Main(string[] args)
        {
            // set encoding keys
            // faster to add explicitly
            Dictionary<string, int> length1keys = new Dictionary<string, int> { { "0", 0 } };

            Dictionary<string, int> length2keys = new Dictionary<string, int> { { "00", 1 }, { "01", 2 }, { "10", 3 } };

            Dictionary<string, int> length3keys = new Dictionary<string, int> { { "000", 4 }, { "001", 5 }, { "010", 6 }, 
            { "011", 7 }, { "100", 8 }, { "101", 9 }, { "110", 10 } };

            Dictionary<string, int> length4keys = new Dictionary<string, int> { { "0000", 11 }, { "0001", 12 }, { "0010", 13 }, 
            { "0011", 14 }, { "0100", 15 }, { "0101", 16 }, { "0110", 17 }, { "0111", 18 }, { "1000", 19 }, { "1001", 20 },
            { "1010", 21 }, { "1011", 22 }, { "1100", 23 }, { "1101", 24 }, { "1110", 25 } };

            Dictionary<string, int> length5keys = new Dictionary<string, int> { { "00000", 26 }, { "00001", 27 }, { "00010", 28 }, 
            { "00011", 29 }, { "00100", 30 }, { "00101", 31 }, { "00110", 32 }, { "00111", 33 }, { "01000", 34 }, { "01001", 35 }, 
            { "01010", 36 }, { "01011", 37 }, { "01100", 38 }, { "01101", 39 }, { "01110", 40 }, { "01111", 41 }, { "10000", 42 }, 
            { "10001", 43 }, { "10010", 44 }, { "10011", 45 }, { "10100", 46 }, { "10101", 47 }, { "10110", 48 }, { "10111", 49 }, 
            { "11000", 50 }, { "11001", 51 }, { "11010", 52 }, { "11011", 53 }, { "11100", 54 }, { "11101", 55 }, { "11110", 56 } };

            Dictionary<string, int> length6keys = new Dictionary<string, int> { { "000000", 57 }, { "000001", 58 }, { "000010", 59 }, 
            { "000011", 60 }, { "000100", 61 }, { "000101", 62 }, { "000110", 63 }, { "000111", 64 }, { "001000", 65 }, { "001001", 66 }, 
            { "001010", 67 }, { "001011", 68 }, { "001100", 69 }, { "001101", 70 }, { "001110", 71 }, { "001111", 72 }, { "010000", 73 }, 
            { "010001", 74 }, { "010010", 75 }, { "010011", 76 }, { "010100", 77 }, { "010101", 78 }, { "010110", 79 }, { "010111", 80 }, 
            { "011000", 81 }, { "011001", 82 }, { "011010", 83 }, { "011011", 84 }, { "011100", 85 }, { "011101", 86 }, { "011110", 87 }, 
            { "100000", 88 }, { "100001", 89 }, { "100010", 90 }, { "100011", 91 }, { "100100", 92 }, { "100101", 93 }, { "100110", 94 }, 
            { "100111", 95 }, { "101000", 96 }, { "101001", 97 }, { "101010", 98 }, { "101011", 99 }, { "101100", 100 }, { "101101", 101 }, 
            { "101110", 102 }, { "101111", 103 }, { "110000", 104 }, { "110001", 105 }, { "110010", 106 }, { "110011", 107 }, { "110100", 108 }, 
            { "110101", 109 }, { "110110", 110 }, { "110111", 111 }, { "111000", 112 }, { "111001", 113 }, { "111010", 114 }, { "111011", 115 }, 
            { "111100", 116 }, { "111101", 117 }, { "111110", 118 } };

            Dictionary<string, int> length7keys = new Dictionary<string, int> { { "0000000", 119 }, { "0000001", 120 }, { "0000010", 121 }, 
            { "0000011", 122 }, { "0000100", 123 }, { "0000101", 124 }, { "0000110", 125 }, { "0000111", 126 }, { "0001000", 127 }, { "0001001", 128 }, 
            { "0001010", 129 }, { "0001011", 130 }, { "0001100", 131 }, { "0001101", 132 }, { "0001110", 133 }, { "0001111", 134 }, { "0010000", 135 }, 
            { "0010001", 136 }, { "0010010", 137 }, { "0010011", 138 }, { "0010100", 139 }, { "0010101", 140 }, { "0010110", 141 }, { "0010111", 142 }, 
            { "0011000", 143 }, { "0011001", 144 }, { "0011010", 145 }, { "0011011", 146 }, { "0011100", 147 }, { "0011101", 148 }, { "0011110", 149 }, 
            { "0100000", 150 }, { "0100001", 151 }, { "0100010", 152 }, { "0100011", 153 }, { "0100100", 154 }, { "0100101", 155 }, { "0100110", 156 }, 
            { "0100111", 157 }, { "0101000", 158 }, { "0101001", 159 }, { "0101010", 160 }, { "0101011", 161 }, { "0101100", 162 }, { "0101101", 163 }, 
            { "0101110", 164 }, { "0101111", 165 }, { "0110000", 166 }, { "0110001", 167 }, { "0110010", 168 }, { "0110011", 169 }, { "0110100", 170 }, 
            { "0110101", 171 }, { "0110110", 172 }, { "0110111", 173 }, { "0111000", 174 }, { "0111001", 175 }, { "0111010", 176 }, { "0111011", 177 }, 
            { "0111100", 178 }, { "0111101", 179 }, { "0111110", 180 }, { "1000000", 181 }, { "1000001", 182 }, { "1000010", 183 }, { "1000011", 184 }, 
            { "1000100", 185 }, { "1000101", 186 }, { "1000110", 187 }, { "1000111", 188 }, { "1001000", 189 }, { "1001001", 190 }, { "1001010", 191 }, 
            { "1001011", 192 }, { "1001100", 193 }, { "1001101", 194 }, { "1001110", 195 }, { "1001111", 196 }, { "1010000", 197 }, { "1010001", 198 }, 
            { "1010010", 199 }, { "1010011", 200 }, { "1010100", 201 }, { "1010101", 202 }, { "1010110", 203 }, { "1010111", 204 }, { "1011000", 205 }, 
            { "1011001", 206 }, { "1011010", 207 }, { "1011011", 208 }, { "1011100", 209 }, { "1011101", 210 }, { "1011110", 211 }, { "1100000", 212 }, 
            { "1100001", 213 }, { "1100010", 214 }, { "1100011", 215 }, { "1100100", 216 }, { "1100101", 217 }, { "1100110", 218 }, { "1100111", 219 }, 
            { "1101000", 220 }, { "1101001", 221 }, { "1101010", 222 }, { "1101011", 223 }, { "1101100", 224 }, { "1101101", 225 }, { "1101110", 226 }, 
            { "1101111", 227 }, { "1110000", 228 }, { "1110001", 229 }, { "1110010", 230 }, { "1110011", 231 }, { "1110100", 232 }, { "1110101", 233 }, 
            { "1110110", 234 }, { "1110111", 235 }, { "1111000", 236 }, { "1111001", 237 }, { "1111010", 238 }, { "1111011", 239 }, { "1111100", 240 }, 
            { "1111101", 241 }, { "1111110", 242 } };

            // now map binary message length indicator to corresponding dictionary of keys
            Dictionary<string, Dictionary<string, int>> listOfKeyDicts = new Dictionary<string, Dictionary<string, int>> 
            { {"001", length1keys}, { "010", length2keys }, { "011", length3keys }, { "100", length4keys }, 
            { "101", length5keys }, { "110", length6keys }, { "111", length7keys }};


            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    // do something with line
                    int indexMessageStart = Math.Min(line.IndexOf('0'), line.IndexOf('1'));
                    string header = line.Substring(0, indexMessageStart);
                    string message = line.Substring(indexMessageStart);

                    List<char> messageChars = message.ToList();
                    List<char> outputChars = new List<char>();

                    while (messageChars.Count > 3)
                    {
                        string keyLength = new string(messageChars.Take(3).ToArray());
                        int messageSize = Convert.ToInt32(keyLength, 2); // e.g. "011" -- key length 3
                        messageChars.RemoveRange(0, 3); // remove key length indicator
                        // listOfKeyDicts[keyLength] is the "lengthNkeys" Dictionary
                        Dictionary<string, int> dict = listOfKeyDicts[keyLength]; // e.g. length3keys
                        string endingFlag = new string('1', messageSize); // create a string of 1's with the given length, e.g. "111"
                        string messagePart = new string(messageChars.Take(messageSize).ToArray()); // e.g. "010" = 6
                        messageChars.RemoveRange(0, messageSize); // remove messageByte
                        while (!messagePart.Equals(endingFlag))
                        {
                            ////////////////////////
                            outputChars.Add(header[dict[messagePart]]); // get character in header corresponding to this bit position,  e.g. length3keys["010"] = 6, add character 6 of header
                            ////////////////////////
                            messagePart = new string(messageChars.Take(messageSize).ToArray());
                            messageChars.RemoveRange(0, messageSize); // remove messageByte
                        }

                    }

                    if (new string(messageChars.ToArray()) == "000") // ending flag of message
                    {
                        Console.WriteLine(new string(outputChars.ToArray()));
                    }
                }

            //Console.Read();
        }
    }
}
