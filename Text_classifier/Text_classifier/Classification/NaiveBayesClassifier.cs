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
        private HashSet<string> stopWords;

        public NaiveBayesClassifier(string[] stopWords)
        {
            this.stopWords = new HashSet<string>(stopWords);
        }

        void IClassifier.Train(string text1, string text2)
        {
            var tokens1 = Utils.ExtractWords(text1).Where(e => !this.stopWords.Contains(e));
            var wordCount1 = Utils.CountWords(tokens1);
            var allWords1 = wordCount1.Values.Sum();

            var tokens2 = Utils.ExtractWords(text2).Where(e => !this.stopWords.Contains(e));
            var wordCount2 = Utils.CountWords(tokens2);
            var allWords2 = wordCount2.Values.Sum();

            var distinctWords = wordCount1.Keys.Union(wordCount2.Keys).Count();
            var denominator = distinctWords + allWords1;

            this.zeroLogProbability = LogLaplaceSmoothing(0, denominator, 1d);
            this.logProbabilities1 = CalculateWordLogProbabilites(wordCount1, denominator, 1d);
            
            double correctionFactor = allWords1 / (double)allWords2;
            this.logProbabilities2 = CalculateWordLogProbabilites(wordCount2, denominator, correctionFactor);

            isTrained = true;
        }

        private IDictionary<string, double> CalculateWordLogProbabilites(
            IDictionary<string, int> wordCount, int denominator, double correctionFactor)
        {
            var logProbabilities = new Dictionary<string, double>(wordCount.Count);
            foreach (var entry in wordCount)
                logProbabilities[entry.Key] = LogLaplaceSmoothing(entry.Value, denominator, correctionFactor);
            return logProbabilities;
        }

        double LogLaplaceSmoothing(int count, int denominator, double correctionFactor)
        {
            return Math.Log((1d + correctionFactor * count) / denominator);
        }

        double IClassifier.Classify(string sample)
        {
            if (!isTrained)
                throw new NotTrainedException();
            var tokens = new HashSet<string>(Utils.ExtractWords(sample));
            tokens.RemoveWhere(e => this.stopWords.Contains(e));

            double logProb1 = CalculateSampleLogProbability(tokens, this.logProbabilities1);
            // Console.WriteLine("Probability 1: " + Math.Exp(logProb1) + " = e^"+logProb1);
            
            double logProb2 = CalculateSampleLogProbability(tokens, this.logProbabilities2);
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
                 logProbability += logProbabilities.ContainsKey(token) ?
                    logProbability += logProbabilities[token] :
                    logProbability += this.zeroLogProbability;
            }
            return logProbability;
        }
    }
}
