namespace Text_classifier
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.text1Button = new System.Windows.Forms.Button();
            this.trainingBox = new System.Windows.Forms.GroupBox();
            this.validateButton = new System.Windows.Forms.Button();
            this.trainButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.text2TextBox = new System.Windows.Forms.TextBox();
            this.text1TextBox = new System.Windows.Forms.TextBox();
            this.text2Button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.classifyButton = new System.Windows.Forms.Button();
            this.sampleButton = new System.Windows.Forms.Button();
            this.sampleTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.apostropheCheckBox = new System.Windows.Forms.CheckBox();
            this.exclamationMarkCheckBox = new System.Windows.Forms.CheckBox();
            this.questionMarkCheckBox = new System.Windows.Forms.CheckBox();
            this.sentenceLengthCheckBox = new System.Windows.Forms.CheckBox();
            this.wordLengthCheckBox = new System.Windows.Forms.CheckBox();
            this.naiveBayesCheckBox = new System.Windows.Forms.CheckBox();
            this.trainingBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // text1Button
            // 
            this.text1Button.Location = new System.Drawing.Point(279, 22);
            this.text1Button.Name = "text1Button";
            this.text1Button.Size = new System.Drawing.Size(75, 23);
            this.text1Button.TabIndex = 0;
            this.text1Button.Text = "Browse...";
            this.text1Button.UseVisualStyleBackColor = true;
            this.text1Button.Click += new System.EventHandler(this.text1Button_Click);
            // 
            // trainingBox
            // 
            this.trainingBox.Controls.Add(this.validateButton);
            this.trainingBox.Controls.Add(this.trainButton);
            this.trainingBox.Controls.Add(this.label2);
            this.trainingBox.Controls.Add(this.label1);
            this.trainingBox.Controls.Add(this.text2TextBox);
            this.trainingBox.Controls.Add(this.text1TextBox);
            this.trainingBox.Controls.Add(this.text2Button);
            this.trainingBox.Controls.Add(this.text1Button);
            this.trainingBox.Location = new System.Drawing.Point(12, 115);
            this.trainingBox.Name = "trainingBox";
            this.trainingBox.Size = new System.Drawing.Size(360, 114);
            this.trainingBox.TabIndex = 1;
            this.trainingBox.TabStop = false;
            this.trainingBox.Text = "Training";
            // 
            // validateButton
            // 
            this.validateButton.Location = new System.Drawing.Point(90, 79);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(90, 23);
            this.validateButton.TabIndex = 7;
            this.validateButton.Text = "Cross Validate";
            this.validateButton.UseVisualStyleBackColor = true;
            this.validateButton.Click += new System.EventHandler(this.validateButton_Click);
            // 
            // trainButton
            // 
            this.trainButton.Location = new System.Drawing.Point(9, 79);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(75, 23);
            this.trainButton.TabIndex = 6;
            this.trainButton.Text = "Train";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Text 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Text 1";
            // 
            // text2TextBox
            // 
            this.text2TextBox.Location = new System.Drawing.Point(58, 53);
            this.text2TextBox.Name = "text2TextBox";
            this.text2TextBox.Size = new System.Drawing.Size(215, 20);
            this.text2TextBox.TabIndex = 3;
            // 
            // text1TextBox
            // 
            this.text1TextBox.Location = new System.Drawing.Point(58, 24);
            this.text1TextBox.Name = "text1TextBox";
            this.text1TextBox.Size = new System.Drawing.Size(215, 20);
            this.text1TextBox.TabIndex = 2;
            // 
            // text2Button
            // 
            this.text2Button.Location = new System.Drawing.Point(279, 51);
            this.text2Button.Name = "text2Button";
            this.text2Button.Size = new System.Drawing.Size(75, 23);
            this.text2Button.TabIndex = 1;
            this.text2Button.Text = "Browse...";
            this.text2Button.UseVisualStyleBackColor = true;
            this.text2Button.Click += new System.EventHandler(this.text2Button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.classifyButton);
            this.groupBox1.Controls.Add(this.sampleButton);
            this.groupBox1.Controls.Add(this.sampleTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 235);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 86);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Classification";
            // 
            // classifyButton
            // 
            this.classifyButton.Location = new System.Drawing.Point(13, 47);
            this.classifyButton.Name = "classifyButton";
            this.classifyButton.Size = new System.Drawing.Size(75, 23);
            this.classifyButton.TabIndex = 7;
            this.classifyButton.Text = "Classify";
            this.classifyButton.UseVisualStyleBackColor = true;
            this.classifyButton.Click += new System.EventHandler(this.classifyButton_Click);
            // 
            // sampleButton
            // 
            this.sampleButton.Location = new System.Drawing.Point(279, 19);
            this.sampleButton.Name = "sampleButton";
            this.sampleButton.Size = new System.Drawing.Size(75, 23);
            this.sampleButton.TabIndex = 7;
            this.sampleButton.Text = "Browse...";
            this.sampleButton.UseVisualStyleBackColor = true;
            this.sampleButton.Click += new System.EventHandler(this.sampleButton_Click);
            // 
            // sampleTextBox
            // 
            this.sampleTextBox.Location = new System.Drawing.Point(58, 21);
            this.sampleTextBox.Name = "sampleTextBox";
            this.sampleTextBox.Size = new System.Drawing.Size(215, 20);
            this.sampleTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sample";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.apostropheCheckBox);
            this.groupBox2.Controls.Add(this.exclamationMarkCheckBox);
            this.groupBox2.Controls.Add(this.questionMarkCheckBox);
            this.groupBox2.Controls.Add(this.sentenceLengthCheckBox);
            this.groupBox2.Controls.Add(this.wordLengthCheckBox);
            this.groupBox2.Controls.Add(this.naiveBayesCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 96);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Classifier";
            // 
            // apostropheCheckBox
            // 
            this.apostropheCheckBox.AutoSize = true;
            this.apostropheCheckBox.Location = new System.Drawing.Point(187, 66);
            this.apostropheCheckBox.Name = "apostropheCheckBox";
            this.apostropheCheckBox.Size = new System.Drawing.Size(85, 17);
            this.apostropheCheckBox.TabIndex = 5;
            this.apostropheCheckBox.Text = "Apostrophes";
            this.apostropheCheckBox.UseVisualStyleBackColor = true;
            // 
            // exclamationMarkCheckBox
            // 
            this.exclamationMarkCheckBox.AutoSize = true;
            this.exclamationMarkCheckBox.Location = new System.Drawing.Point(187, 43);
            this.exclamationMarkCheckBox.Name = "exclamationMarkCheckBox";
            this.exclamationMarkCheckBox.Size = new System.Drawing.Size(115, 17);
            this.exclamationMarkCheckBox.TabIndex = 4;
            this.exclamationMarkCheckBox.Text = "Exclamation Marks";
            this.exclamationMarkCheckBox.UseVisualStyleBackColor = true;
            // 
            // questionMarkCheckBox
            // 
            this.questionMarkCheckBox.AutoSize = true;
            this.questionMarkCheckBox.Location = new System.Drawing.Point(187, 19);
            this.questionMarkCheckBox.Name = "questionMarkCheckBox";
            this.questionMarkCheckBox.Size = new System.Drawing.Size(105, 17);
            this.questionMarkCheckBox.TabIndex = 3;
            this.questionMarkCheckBox.Text = "Questions Marks";
            this.questionMarkCheckBox.UseVisualStyleBackColor = true;
            // 
            // sentenceLengthCheckBox
            // 
            this.sentenceLengthCheckBox.AutoSize = true;
            this.sentenceLengthCheckBox.Location = new System.Drawing.Point(9, 66);
            this.sentenceLengthCheckBox.Name = "sentenceLengthCheckBox";
            this.sentenceLengthCheckBox.Size = new System.Drawing.Size(108, 17);
            this.sentenceLengthCheckBox.TabIndex = 2;
            this.sentenceLengthCheckBox.Text = "Sentence Length";
            this.sentenceLengthCheckBox.UseVisualStyleBackColor = true;
            // 
            // wordLengthCheckBox
            // 
            this.wordLengthCheckBox.AutoSize = true;
            this.wordLengthCheckBox.Location = new System.Drawing.Point(9, 43);
            this.wordLengthCheckBox.Name = "wordLengthCheckBox";
            this.wordLengthCheckBox.Size = new System.Drawing.Size(88, 17);
            this.wordLengthCheckBox.TabIndex = 1;
            this.wordLengthCheckBox.Text = "Word Length";
            this.wordLengthCheckBox.UseVisualStyleBackColor = true;
            // 
            // naiveBayesCheckBox
            // 
            this.naiveBayesCheckBox.AutoSize = true;
            this.naiveBayesCheckBox.Checked = true;
            this.naiveBayesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.naiveBayesCheckBox.Location = new System.Drawing.Point(9, 19);
            this.naiveBayesCheckBox.Name = "naiveBayesCheckBox";
            this.naiveBayesCheckBox.Size = new System.Drawing.Size(86, 17);
            this.naiveBayesCheckBox.TabIndex = 0;
            this.naiveBayesCheckBox.Text = "Naive Bayes";
            this.naiveBayesCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 330);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.trainingBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Text Classification";
            this.trainingBox.ResumeLayout(false);
            this.trainingBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button text1Button;
        private System.Windows.Forms.GroupBox trainingBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text2TextBox;
        private System.Windows.Forms.TextBox text1TextBox;
        private System.Windows.Forms.Button text2Button;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button classifyButton;
        private System.Windows.Forms.Button sampleButton;
        private System.Windows.Forms.TextBox sampleTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button validateButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox questionMarkCheckBox;
        private System.Windows.Forms.CheckBox sentenceLengthCheckBox;
        private System.Windows.Forms.CheckBox wordLengthCheckBox;
        private System.Windows.Forms.CheckBox naiveBayesCheckBox;
        private System.Windows.Forms.CheckBox apostropheCheckBox;
        private System.Windows.Forms.CheckBox exclamationMarkCheckBox;
    }
}

