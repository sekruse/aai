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
            this.trainingBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
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
            this.trainingBox.Controls.Add(this.trainButton);
            this.trainingBox.Controls.Add(this.label2);
            this.trainingBox.Controls.Add(this.label1);
            this.trainingBox.Controls.Add(this.text2TextBox);
            this.trainingBox.Controls.Add(this.text1TextBox);
            this.trainingBox.Controls.Add(this.text2Button);
            this.trainingBox.Controls.Add(this.text1Button);
            this.trainingBox.Location = new System.Drawing.Point(12, 12);
            this.trainingBox.Name = "trainingBox";
            this.trainingBox.Size = new System.Drawing.Size(360, 110);
            this.trainingBox.TabIndex = 1;
            this.trainingBox.TabStop = false;
            this.trainingBox.Text = "Training";
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
            this.groupBox1.Location = new System.Drawing.Point(12, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 78);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 223);
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
    }
}

