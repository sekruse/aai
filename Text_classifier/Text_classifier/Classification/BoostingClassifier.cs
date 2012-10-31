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
        /*
        void IClassifier.Train(string text1, string text2)
        {
            if (this.subclassifiers.Count == 0)
                throw new Exception("No subclassifiers for boosting");
            this.weights.RemoveAll(e => true);
            foreach (var subclassfier in this.subclassifiers)
                subclassfier.Train(text1, text2);

            var samples = Utils.ExtractSamples(text1).Select(s => new SamplePoint() { Text = s, Class = -1 }).ToList()
                .Concat(Utils.ExtractSamples(text2).Select(s => new SamplePoint() { Text = s, Class = 1 }).ToList()).ToArray();

            var loss = new double[samples.Count()];
            for (int i = 0; i < this.subclassifiers.Count(); i++)
            {
                var subclassifier = subclassifiers[i];
                double error = 0d;
                int debugError = 0;
                for (int j = 0; j < samples.Count(); j++)
                {
                    var sample = samples[j];
                    double estimate = subclassifier.Classify(sample.Text);
                    if (i == 0)
                        loss[j] = 1d / samples.Count();
                    else
                        loss[j] = loss[j] * Math.Exp(-sample.Class * weights.Last() * estimate);
                    error += Math.Abs((estimate - sample.Class) / 2) * loss[j];
                    if (Math.Sign(estimate) != sample.Class) 
                        debugError++;
                }
                weights.Add(ComputeWeight(error));
                Console.WriteLine("Classifier " + i + " made " + debugError + "/" + samples.Count() + " errors ("+error+"), weight: " + weights.Last());
            }

        }

        private double ComputeWeight(double error)
        {
            return Math.Log((1-error)/error) / 2;
        }
        */

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
                // weights.Add(1 - squareRootMeanError);
                weights.Add(Math.Pow(Math.Max(0, (samples.Count() / 2d - debugError) / samples.Count()), 2));
                Console.WriteLine("Classifier " + i + ":");
                Console.WriteLine("  " + debugError + "/" + samples.Count() + " errors");
                Console.WriteLine("  " + squareRootMeanError + " -> " + weights.Last());  
                //squaredErrors[i++] = squareRootMeanError;
            }

            /*
            // Weight them by their error rate.
            double errorSum = squaredErrors.Sum();
            foreach (var error in squaredErrors)
            {
                // smoothen the error share to avoid division by zero
                double errorShare = (error + 1) / (errorSum + squaredErrors.Count());
                double weight = (1 - errorShare) / errorShare;
                Console.WriteLine(errorShare + "->" + weight);             
                weights.Add(weight);
            }
             * */
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
                Console.WriteLine("Classifier " + i + " voted: " + subresult);
            }
            result /= weights.Sum();
            Console.WriteLine("Overall result: " + result);
            return result;
        }

        private class SamplePoint
        {
            public string Text { get; set; }
            public double Class { get; set; }
        }
    }

}
