using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_classifier.Classification
{
    class SentenceLengthClassifier: IClassifier
    {
        double mean1, mean2;
        double variance1, variance2;
        bool isTrained = false;

        void IClassifier.Train(string text1, string text2)
        {
            CalculateAverageSentenceLength(text1, out this.mean1, out this.variance1);
            Console.WriteLine("Average sentence length 1: " + mean1+ " (Varaiance: "+this.variance1+")");
            CalculateAverageSentenceLength(text2, out this.mean2, out this.variance2);
            Console.WriteLine("Average sentence length 2: " + mean2 + " (Varaiance: " + this.variance2 + ")");
            this.isTrained = true;
        }

        double IClassifier.Classify(string text)
        {
            if (!this.isTrained)
                throw new NotTrainedException();

            double logProb2 = 0d;
            double logProb1 = 0d;

            foreach (var sentence in Utils.ExtractSentences(text))
            {
                int sentenceLength = Utils.ExtractWords(sentence).Count();
                logProb1 += Math.Log(NormalDistributionProbability(sentenceLength, this.mean1, this.variance1));
                logProb2 += Math.Log(NormalDistributionProbability(sentenceLength, this.mean2, this.variance2));
            }

            // numerically safer calculation for (-1*p1 + 1*p2)/(p1 + p2)
            double logDiff = logProb1 - logProb2;
            double diff = Math.Exp(-Math.Abs(logDiff));
            double result = -Math.Sign(logDiff) * (1 - diff) / (1 + diff);
            // Console.WriteLine("Actual result: " + result);

            return result;
        }

        private void CalculateAverageSentenceLength(string text, out double mean, out double variance)
        {
            var sentences = Utils.ExtractSentences(text);
            mean = 0d;
            variance = 0d;
            foreach (var sentence in sentences)
                mean += Utils.ExtractWords(sentence).Count();
            mean /= sentences.Count();
            foreach (var sentence in sentences)
                variance += Math.Pow(Utils.ExtractWords(sentence).Count() - mean, 2);
            variance /= sentences.Count();
        }

        private double NormalDistributionProbability(double x, double mean, double variance)
        {
            return Math.Exp(-0.5 * Math.Pow(x - mean, 2) / variance) / (Math.Sqrt(variance * 2 * Math.PI));
        }
    }
}
