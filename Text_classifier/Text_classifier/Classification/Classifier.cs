using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_classifier.Classification
{
    interface IClassifier
    {
        // Train the classifier and return whether training
        // was successful.
        void Train(String text1, String text2);

        // Classify a sample text. Works only if trained.
        int Classify(String sample);
    }

    public class NotTrainedException : System.Exception
    {
        public NotTrainedException() : base("The classifier is not trained.")
        {
        }

    }
}
