using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Text_classifier.Classification;
using System.IO;
using System.Text.RegularExpressions;
using Text_classifier.Resources;

namespace Text_classifier
{
    public partial class MainForm : Form
    {

        private IClassifier classifier;
        private string[] stopWords;

        public MainForm()
        {
            InitializeComponent();

            this.stopWords = Regex.Split(Stopwords.StopWords, @"\r\n");

            var classifier = new BoostingClassifier();
            classifier.Add(new NaiveBayesClassifier(stopWords));
            classifier.Add(new SentenceLengthClassifier());
            classifier.Add(new AverageWordLengthClassifier());
            classifier.Add(new PunctuationClassifier('\'', PunctuationClassifier.PerWord));
            classifier.Add(new PunctuationClassifier('?', PunctuationClassifier.PerSentence));
            classifier.Add(new PunctuationClassifier('!', PunctuationClassifier.PerSentence));

            this.classifier = classifier;
            // this.classifier = new SentenceLengthClassifier();
        }

        private IClassifier CreateClassifier()
        {
            var classifiers = new List<IClassifier>();
            if (this.naiveBayesCheckBox.Checked)
                classifiers.Add(new NaiveBayesClassifier(this.stopWords));
            if (this.wordLengthCheckBox.Checked)
                classifiers.Add(new AverageWordLengthClassifier());
            if (this.sentenceLengthCheckBox.Checked)
                classifiers.Add(new SentenceLengthClassifier());
            if (this.questionMarkCheckBox.Checked)
                classifiers.Add(new PunctuationClassifier('?', PunctuationClassifier.PerSentence));
            if (this.exclamationMarkCheckBox.Checked)
                classifiers.Add(new PunctuationClassifier('!', PunctuationClassifier.PerSentence));
            if (this.apostropheCheckBox.Checked)
                classifiers.Add(new PunctuationClassifier('\'', PunctuationClassifier.PerWord));
            if (classifiers.Count == 1)
                return classifiers.First();
            else
            {
                var boostingClassifier = new BoostingClassifier();
                foreach (var subclassifier in classifiers)
                    boostingClassifier.Add(subclassifier);
                return boostingClassifier;
            }
        }

        private void UpdateTextBox(TextBox textBox)
        {
            var result = this.openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox.Text = this.openFileDialog.FileName;
            }
        }

        private void text1Button_Click(object sender, EventArgs e)
        {
            UpdateTextBox(this.text1TextBox);
        }

        private void text2Button_Click(object sender, EventArgs e)
        {
            UpdateTextBox(this.text2TextBox);
        }

        private void sampleButton_Click(object sender, EventArgs e)
        {
            UpdateTextBox(this.sampleTextBox);
        }

        private void trainButton_Click(object sender, EventArgs e)
        {
            this.classifier = CreateClassifier();
            try
            {
                this.classifier.Train(
                    LoadTextFile(this.text1TextBox.Text),
                    LoadTextFile(this.text2TextBox.Text));
                MessageBox.Show(this, "Classifier successfully trained.", "Training", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                var msg = "Could not train the classifier: \n" + ex.Message;
                MessageBox.Show(this, msg, "Training", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void classifyButton_Click(object sender, EventArgs e)
        {
            try
            {
                var result = classifier.Classify(LoadTextFile(this.sampleTextBox.Text));
                MessageBox.Show(this, "Classification result: " + (result < 0 ? "Text 1" : "Text 2"), 
                    "Classification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                var msg = "Classification not successful: \n" + ex.Message;
                MessageBox.Show(this, msg, "Classification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string LoadTextFile(string path)
        {
            string content;
            using (TextReader reader = new StreamReader(path))
            {
               content = reader.ReadToEnd();
            }
            return content;
        }

        private void validateButton_Click(object sender, EventArgs e)
        {
            try
            {
                CrossValidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Cross validation failed:\n" + ex.Message, "Cross validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CrossValidate()
        {
            var classifier = CreateClassifier();
            var text1 = LoadTextFile(this.text1TextBox.Text);
            var samples1 = Utils.ExtractSamples(text1);
            var text2 = LoadTextFile(this.text2TextBox.Text);
            var samples2 = Utils.ExtractSamples(text2);
            int errors = 0;
            for (int i = 0; i < samples1.Count(); i++)
            {
                string sample, trainingData;
                CreateSampleAndTrainingData(samples1, i, out sample, out trainingData);
                classifier.Train(trainingData, text2);
                if (Math.Sign(classifier.Classify(sample)) != -1)
                    errors++;
            }
            for (int i = 0; i < samples2.Count(); i++)
            {
                string sample, trainingData;
                CreateSampleAndTrainingData(samples2, i, out sample, out trainingData);
                classifier.Train(text1, trainingData);
                if (Math.Sign(classifier.Classify(sample)) != 1)
                    errors++;
            }
            var msg = String.Format("Made {0} errors out of {1}.", 
                errors, samples1.Count() + samples2.Count());
            MessageBox.Show(this, msg, "Cross Validation", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CreateSampleAndTrainingData(IEnumerable<string> samples, 
            int sampleIndex, out string sample, out string trainingData)
        {
            int i = 0;
            StringBuilder sb = new StringBuilder();
            sample = null;
            foreach (string s in samples)
                if (i++ == sampleIndex)
                    sample = s;
                else
                    sb.Append(s).Append("\r\n\r\n");
            trainingData = sb.ToString();
        }
    }
}
