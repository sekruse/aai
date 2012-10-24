using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Text_classifier.Classification
{
    // Simplified implementation of Naive Bayes classifier.
    // Assumes only two topics with equal prior probability.
    // Uses Laplace smoothing to handle words that are not in
    // the training set.
    public class NaiveBayesClassifier : IClassifier
    {
        private bool isTrained = false;
        private IDictionary<string, double> logProbabilities1, logProbabilities2;
        private double zeroLogProbability;

        void IClassifier.Train(string text1, string text2)
        {
            var tokens = Utils.Tokenize(text1);
            var wordCount1 = Utils.CountWords(tokens);

            tokens = Utils.Tokenize(text2);
            var wordCount2 = Utils.CountWords(tokens);

            var wordCount = Utils.Add(wordCount1, wordCount2);
            var distinctWords = wordCount.Count;
            var allWords = wordCount.Values.Sum();
            var denominator = distinctWords + allWords;

            zeroLogProbability = logLaplaceSmoothing(0, denominator);

            logProbabilities1 = calculateWordProbabilites(wordCount1, denominator);
            logProbabilities2 = calculateWordProbabilites(wordCount2, denominator);
            isTrained = true;
        }

        private IDictionary<string, double> calculateWordProbabilites(
            IDictionary<string, int> wordCount, int denominator)
        {
            var logProbabilities = new Dictionary<string, double>(wordCount.Count);
            foreach (var entry in wordCount)
                logProbabilities[entry.Key] = logLaplaceSmoothing(entry.Value, denominator);
            return logProbabilities;
        }

        double logLaplaceSmoothing(int count, int denominator)
        {
            return Math.Log((1d + count) / denominator);
        }

        int IClassifier.Classify(string sample)
        {
            if (!isTrained)
                throw new NotTrainedException();
            var tokens = new HashSet<string>(Utils.Tokenize(sample));
            double probability1 = calculateSampleProbability(tokens, logProbabilities1);
            Console.WriteLine("Probability 1: " + probability1);
            double probability2 = calculateSampleProbability(tokens, logProbabilities2);
            Console.WriteLine("Probability 2: " + probability2);
            return probability1 > probability2 ? -1 : 1;
        }

        private double calculateSampleProbability(HashSet<string> tokens, 
            IDictionary<string, double> logProbabilities)
        {
            double logProbability = 0d;
            foreach (var token in tokens)
            {
                if (logProbabilities.ContainsKey(token))
                    logProbability += logProbabilities[token];
                else
                    logProbability += zeroLogProbability;
            }
            return logProbability;
        }
    }
}
