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

namespace Text_classifier
{
    public partial class MainForm : Form
    {

        private IClassifier classifier = new NaiveBayesClassifier();

        public MainForm()
        {
            InitializeComponent();
        }

        private void updateTextBox(TextBox textBox)
        {
            var result = this.openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox.Text = this.openFileDialog.FileName;
            }
        }

        private void text1Button_Click(object sender, EventArgs e)
        {
            updateTextBox(this.text1TextBox);
        }

        private void text2Button_Click(object sender, EventArgs e)
        {
            updateTextBox(this.text2TextBox);
        }

        private void sampleButton_Click(object sender, EventArgs e)
        {
            updateTextBox(this.sampleTextBox);
        }

        private void trainButton_Click(object sender, EventArgs e)
        {
            try
            {
                classifier.Train(
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
                MessageBox.Show(this, "Classification result: " + (result == -1 ? "Text 1" : "Text 2"), 
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
            TextReader reader = new StreamReader(path);
            var content = reader.ReadToEnd();
            reader.Close();
            return content;
        }
    }
}
