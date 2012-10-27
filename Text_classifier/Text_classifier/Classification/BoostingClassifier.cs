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

            // Compute the first weight.
            var loss = new double[samples.Count()];
            for (int i = 0; i < loss.Count(); i++)
                loss[i] = 1d / loss.Count();
            double error = 0d;
            int debugError = 0;
            for (int i = 0; i < samples.Count(); i++)
            {
                double estimate = subclassifiers[0].Classify(samples[i].Text);
                error += Math.Abs((estimate - samples[i].Class) / 2) * loss[i];
                if (Math.Sign(estimate) != samples[i].Class) debugError++;
            }
            weights.Add(ComputeWeight(error));
            Console.WriteLine("Classifier 0 made " + debugError + "/" + samples.Count() + " errors");

            // Compute the remaining weights.
            for (int i = 1; i < this.subclassifiers.Count(); i++)
            {
                var subclassifier = subclassifiers[i];
                error = 0d;
                debugError = 0;
                for (int j = 0; j < samples.Count(); j++)
                {
                    var sample = samples[j];
                    double estimate = subclassifier.Classify(sample.Text);
                    loss[j] = loss[j] * Math.Exp(-sample.Class * weights.Last() * estimate);
                    error += Math.Abs((estimate - sample.Class) / 2) * loss[j];
                    if (Math.Sign(estimate) != sample.Class) 
                        debugError++;
                }
                weights.Add(ComputeWeight(error));
                Console.WriteLine("Classifier " + i + " made " + debugError + "/" + samples.Count() + " errors");
            }

        }

        private double ComputeWeight(double error)
        {
            return Math.Log((1 - error) / error) / 2;
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
                result += weight * subclassifier.Classify(sample);
            }
            return result;
        }

        private class SamplePoint
        {
            public string Text { get; set; }
            public double Class { get; set; }
        }
    }

}
