using System;
using System.Linq;
using System.Text;

namespace Autopal.ASML.Runner.SequenceAnalysis
{
    public class SequenceAnalysisSolver
    {
        private const int MaxChar = 26;

        public string Solve(string input)
        {
            var punctuation = input.Where(char.IsPunctuation).Distinct().ToArray();
            var words = input.Split().Select(x => x.Trim(punctuation));
            // Hash array to keep count of characters.
            // Initially count of all charters is 
            // initialized to zero.
            var charCount = new int[MaxChar];
            foreach (var word in words)
            {
                if (word != word.ToUpper()) continue;

                // Remove undesired Ascii Chars
                char[] charsToTrim = { '*' , '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                var asciiBytes = Encoding.ASCII.GetBytes(word.Trim(charsToTrim).Replace("'", string.Empty));
                
                // Traverse string and increment 
                // count of characters
                foreach (var letter in asciiBytes)
                {
                    if (letter < 65 || letter > 90)
                        throw new InvalidOperationException($"Input contains non-ascii character '{(char)letter}'. Non-Ascii characters are not supported");

                    // 'a'-'a' will be 0, 'b'-'a' will be 1,
                    // so for location of character in count 
                    // array we wil do str[i]-'a'.
                    charCount[letter % 65]++;
                }
            }

            var result = new StringBuilder();
            // Traverse the hash array and print 
            // characters
            for (var i = 0; i < MaxChar; i++)
                result.Append(new string((char)(i + 65), charCount[i]));

            return result.ToString();
        }
    }
}
