using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_classifier.Classification
{
    class AverageWordLengthClassifier : IClassifier
    {
        double mean1, mean2;
        double variance1, variance2;
        bool isTrained = false;

        void IClassifier.Train(string text1, string text2)
        {
            CalculateAverageWordLength(text1, out this.mean1, out this.variance1);
            // Console.WriteLine("Average word length 1: " + mean1 + " (Varaiance: " + this.variance1 + ")");
            CalculateAverageWordLength(text2, out this.mean2, out this.variance2);
            // Console.WriteLine("Average word length 2: " + mean2 + " (Varaiance: " + this.variance2 + ")");
            this.isTrained = true;
        }

        double IClassifier.Classify(string text)
        {
            if (!this.isTrained)
                throw new NotTrainedException();

            double logProb2 = 0d;
            double logProb1 = 0d;

            foreach (var word in Utils.ExtractWords(text))
            {
                int wordLength = word.Length;
                logProb1 += Math.Log(NormalDistributionProbability(wordLength, this.mean1, this.variance1));
                logProb2 += Math.Log(NormalDistributionProbability(wordLength, this.mean2, this.variance2));
            }

            // numerically safer calculation for (-1*p1 + 1*p2)/(p1 + p2)
            double logDiff = logProb1 - logProb2;
            double diff = Math.Exp(-Math.Abs(logDiff));
            double result = -Math.Sign(logDiff) * (1 - diff) / (1 + diff);
            // Console.WriteLine("Actual result: " + result);

            return result;
        }

        private void CalculateAverageWordLength(string text, out double mean, out double variance)
        {
            var words = Utils.ExtractWords(text);
            mean = 0d;
            variance = 0d;
            foreach (var word in words)
                mean += word.Length;
            mean /= words.Count();
            foreach (var word in words)
                variance += Math.Pow(word.Length - mean, 2);
            variance /= words.Count();
        }

        private double NormalDistributionProbability(double x, double mean, double variance)
        {
            return Math.Exp(-0.5 * Math.Pow(x - mean, 2) / variance) / (Math.Sqrt(variance * 2 * Math.PI));
        }


    }
}
