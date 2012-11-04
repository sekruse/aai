using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_classifier.Classification
{
    class PunctuationClassifier : IClassifier
    {
        public const int PerWord = 0;
        public const int PerSentence = 1;

        int punctuationCount1, punctuationCount2;
        int sentenceCount1, sentenceCount2;
        bool isTrained = false;
        bool perWord;
        char punctuationChar;

        public PunctuationClassifier(char punctuationChar, int options)
        {
            this.punctuationChar = punctuationChar;
            switch (options)
            {
                case PerSentence:
                    perWord = false;
                    break;
                case PerWord:
                    perWord = true;
                    break;
                default:
                    throw new ArgumentException("Illegal options: " + options);
            }
        }

        void IClassifier.Train(string text1, string text2)
        {
            CalculateAveragePunctuationRatio(text1, out this.punctuationCount1, out this.sentenceCount1, this.punctuationChar, this.perWord);
            CalculateAveragePunctuationRatio(text2, out this.punctuationCount2, out this.sentenceCount2, this.punctuationChar, this.perWord);
            this.isTrained = true;
        }

        double IClassifier.Classify(string text)
        {
            if (!this.isTrained)
                throw new NotTrainedException();

            double prob1 = (double) this.punctuationCount1 / this.sentenceCount1;
            double prob2 = (double) this.punctuationCount2 / this.sentenceCount2;

            int apostrCount, sentenceCount;
            CalculateAveragePunctuationRatio(text, out apostrCount, out sentenceCount, this.punctuationChar, this.perWord);
            double prob3 = (double)apostrCount / sentenceCount;

            double diff13 = Math.Abs(prob1 - prob3);
            double diff23 = Math.Abs(prob2 - prob3);

            // the result will be the smaller value
            double result = diff13 == diff23 ? 0d : (diff13 - diff23) / (diff13 + diff23);
            return result;
        }

        private void CalculateAveragePunctuationRatio(string text, out int apostrCount, out int relativeCount, char punctuationChar, bool perWord)
        {
            apostrCount = Utils.CharacterNo(text, punctuationChar);
            relativeCount = (perWord ? Utils.ExtractWords(text) : Utils.ExtractSentences(text)).Count();
        }

    }
}
