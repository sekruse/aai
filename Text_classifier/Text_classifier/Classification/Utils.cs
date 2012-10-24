using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Text_classifier.Classification
{
    class Utils
    {
        public static IEnumerable<string> Tokenize(string text)
        {
            var matches = Regex.Matches(text, @"\w+");
            var result = new string[matches.Count];
            int i = 0;
            foreach (Match match in matches)
                result[i++] = text.Substring(match.Index, match.Length);
            return result;
        }

        public static IDictionary<string,int> CountWords(IEnumerable<string> words) 
        {
            var counts = new Dictionary<string,int>();
            foreach (var word in words)
            {
                if (counts.ContainsKey(word))
                    counts[word] = counts[word] + 1;
                else
                    counts[word] = 1;
            }
            return counts;
        }

        public static IDictionary<string, int> Add(IDictionary<string, int> a, 
            IDictionary<string, int> b)
        {
            var result = new Dictionary<string, int>(a);
            foreach (var entry in b)
            {
                if (result.ContainsKey(entry.Key))
                    result[entry.Key] = result[entry.Key] + entry.Value;
                else
                    result[entry.Key] = entry.Value;
            }
            return result;
        }
    }
}
