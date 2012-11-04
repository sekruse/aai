using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_classifier.Classification
{
    class BoostingClassifier: IClassifier
    {
        List<IClassifier> subclassifiers = new List<IClassifier>();
        List<double> weights = new List<double>();

        public void Add(IClassifier classifier)
        {
            this.subclassifiers.Add(classifier);
        }

        void IClassifier.Train(string text1, string text2)
        {
            if (this.subclassifiers.Count == 0)
                throw new Exception("No subclassifiers for boosting");
            this.weights.RemoveAll(e => true);
            foreach (var subclassfier in this.subclassifiers)
                subclassfier.Train(text1, text2);

            var samples = Utils.ExtractSamples(text1).Select(s => new SamplePoint() { Text = s, Class = -1 }).ToList()
                .Concat(Utils.ExtractSamples(text2).Select(s => new SamplePoint() { Text = s, Class = 1 }).ToList()).ToArray();

            // Calculate squared errors for each classifier.
            double[] squaredErrors = new double[subclassifiers.Count];
            int i = 0;
            foreach (var subclassifier in subclassifiers)
            {
                double squareRootMeanError = 0d;
                int debugError = 0; i++;
                foreach (var samplePoint in samples)
                {
                    var estimate = subclassifier.Classify(samplePoint.Text);
                    var error = samplePoint.Class - estimate;
                    squareRootMeanError += error * error;
                    if (Math.Abs(error) >= 1) debugError++;
                }
                squareRootMeanError = Math.Sqrt(squareRootMeanError / samples.Count());
                weights.Add(Math.Pow(Math.Max(0, (samples.Count() / 2d - debugError) / samples.Count()), 2));
            }

        }
   

        double IClassifier.Classify(string sample)
        {
            if (this.weights.Count == 0)
                throw new NotTrainedException();

            double result = 0d;
            for (int i = 0; i < weights.Count; i++)
            {
                var weight = this.weights[i];
                var subclassifier = this.subclassifiers[i];
                var subresult = subclassifier.Classify(sample);
                result += weight * subresult;
            }
            var weightsSum = weights.Sum();
            if (weightsSum != 0)
                result /= weights.Sum();
            return result;
        }

        private class SamplePoint
        {
            public string Text { get; set; }
            public double Class { get; set; }
        }
    }

}
