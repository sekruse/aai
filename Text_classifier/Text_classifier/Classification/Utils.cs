using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Text_classifier.Classification
{
    class Utils
    {
        private static Regex SectionRegex = new Regex(@"(?:\r?\n)(?:\s*(?:\r?\n))+");
        private static Regex SentenceRegex = new Regex(@"[\.!\?]");

        public static IEnumerable<string> ExtractWords(string text)
        {
            var matches = Regex.Matches(text, @"\w+");
            var result = new string[matches.Count];
            int i = 0;
            foreach (Match match in matches)
                result[i++] = match.Value;
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

        public static IEnumerable<string> ExtractSamples(string text)
        {
            return Split(text, SectionRegex);
        }

        public static int CharacterNo(string text, char character)
        {
            int result = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if()
                {
                    result++;
                }
                
            }
         
            
            return result;
        }

        public static IEnumerable<string> ExtractSentences(string text)
        {
            return Split(text, SentenceRegex);
        }

        private static IEnumerable<string> Split(string text, Regex regex)
        {
            var result = regex.Split(text).Where(s => !String.IsNullOrWhiteSpace(s));
            return result;
        }


    }
}
