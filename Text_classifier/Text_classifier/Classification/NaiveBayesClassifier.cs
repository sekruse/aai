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
            var tokens = Utils.ExtractWords(text1);
            var wordCount1 = Utils.CountWords(tokens);

            tokens = Utils.ExtractWords(text2);
            var wordCount2 = Utils.CountWords(tokens);

            var wordCount = Utils.Add(wordCount1, wordCount2);
            var distinctWords = wordCount.Count;
            var allWords = wordCount.Values.Sum();
            var denominator = distinctWords + allWords;

            zeroLogProbability = LogLaplaceSmoothing(0, denominator);

            logProbabilities1 = CalculateWordLogProbabilites(wordCount1, denominator);
            logProbabilities2 = CalculateWordLogProbabilites(wordCount2, denominator);
            isTrained = true;
        }

        private IDictionary<string, double> CalculateWordLogProbabilites(
            IDictionary<string, int> wordCount, int denominator)
        {
            var logProbabilities = new Dictionary<string, double>(wordCount.Count);
            foreach (var entry in wordCount)
                logProbabilities[entry.Key] = LogLaplaceSmoothing(entry.Value, denominator);
            return logProbabilities;
        }

        double LogLaplaceSmoothing(int count, int denominator)
        {
            return Math.Log((1d + count) / denominator);
        }

        double IClassifier.Classify(string sample)
        {
            if (!isTrained)
                throw new NotTrainedException();
            var tokens = new HashSet<string>(Utils.ExtractWords(sample));

            double logProb1 = CalculateSampleLogProbability(tokens, logProbabilities1);
            // Console.WriteLine("Probability 1: " + Math.Exp(logProb1) + " = e^"+logProb1);
            
            double logProb2 = CalculateSampleLogProbability(tokens, logProbabilities2);
            // Console.WriteLine("Probability 2: " + Math.Exp(logProb2) + " = e^" + logProb2);

            // numerically safer calculation for (-1*p1 + 1*p2)/(p1 + p2)
            double logDiff = logProb1 - logProb2;
            double diff = Math.Exp(-Math.Abs(logDiff));
            double result = -Math.Sign(logDiff) * (1 - diff) / (1 + diff);
            // Console.WriteLine("Actual result: " + result);

            return result;
        }

        private double CalculateSampleLogProbability(HashSet<string> tokens, 
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
