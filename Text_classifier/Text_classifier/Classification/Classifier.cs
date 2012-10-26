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
        // Result is in range [-1, 1] whereas -1 represents class 1 and 1 represents class 2.
        double Classify(String sample);
    }

    public class NotTrainedException : System.Exception
    {
        public NotTrainedException() : base("The classifier is not trained.")
        {
        }

    }
}
