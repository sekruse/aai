using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_classifier.Classification
{
    class PunctuationClassifier : IClassifier
    {
        int apostrCount1, apostrCount2;
        int sentenceCount1, sentenceCount2;
        bool isTrained = false;

        void IClassifier.Train(string text1, string text2)
        {
            CalculateAverageApostropheRatio(text1, out this.apostrCount1, out this.sentenceCount1);
            Console.WriteLine("Apostrophe ratio (per sentence) 1 is: " + (double) apostrCount1/sentenceCount1);
            CalculateAverageApostropheRatio(text2, out this.apostrCount2, out this.sentenceCount2);
            Console.WriteLine("Apostrophe ratio (per sentence) 2 is: " + (double)apostrCount2 / sentenceCount2);

            this.isTrained = true;
        }

        double IClassifier.Classify(string text)
        {
            if (!this.isTrained)
                throw new NotTrainedException();

            double prob1 = (double) this.apostrCount1 / this.sentenceCount1;
            double prob2 = (double) this.apostrCount2 / this.sentenceCount2;

            int apostrCount, sentenceCount;
            CalculateAverageApostropheRatio(text, out apostrCount, out sentenceCount);
            double prob3 = (double)apostrCount / sentenceCount;

            double diff13 = Math.Abs(prob1 - prob3);
            double diff23 = Math.Abs(prob2 - prob3);

            // the result will be the smaller value
            double result = diff13 < diff23 ? -1 : 1;

                        
            return result;
        }

        private void CalculateAverageApostropheRatio(string text, out int apostrCount, out int sentenceCount)
        {
            apostrCount = Utils.CharacterNo(text, '\'');
            sentenceCount = Utils.ExtractSentences(text).Count();
        }


        private double NormalDistributionProbability(double x, double mean, double variance)
        {
            return Math.Exp(-0.5 * Math.Pow(x - mean, 2) / variance) / (Math.Sqrt(variance * 2 * Math.PI));
        }

    }
}
