namespace Tutorial_0227
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            distanceTextBox = new TextBox();
            gasTextBox = new TextBox();
            averageLabel = new Label();
            calculateButton = new Button();
            exitButton = new Button();
            logListBox = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("標楷體", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label1.Location = new Point(144, 71);
            label1.Name = "label1";
            label1.Size = new Size(156, 19);
            label1.TabIndex = 0;
            label1.Text = "輸入行駛里程數";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("標楷體", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label2.Location = new Point(144, 132);
            label2.Name = "label2";
            label2.Size = new Size(156, 19);
            label2.TabIndex = 1;
            label2.Text = "消耗油量公升數";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("標楷體", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label3.Location = new Point(144, 195);
            label3.Name = "label3";
            label3.Size = new Size(135, 19);
            label3.TabIndex = 2;
            label3.Text = "你的平均油耗";
            // 
            // distanceTextBox
            // 
            distanceTextBox.Font = new Font("標楷體", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            distanceTextBox.Location = new Point(361, 68);
            distanceTextBox.Name = "distanceTextBox";
            distanceTextBox.Size = new Size(140, 30);
            distanceTextBox.TabIndex = 3;
            // 
            // gasTextBox
            // 
            gasTextBox.Font = new Font("標楷體", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            gasTextBox.Location = new Point(361, 132);
            gasTextBox.Name = "gasTextBox";
            gasTextBox.Size = new Size(140, 30);
            gasTextBox.TabIndex = 4;
            // 
            // averageLabel
            // 
            averageLabel.BorderStyle = BorderStyle.FixedSingle;
            averageLabel.Font = new Font("標楷體", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 136);
            averageLabel.Location = new Point(361, 194);
            averageLabel.Name = "averageLabel";
            averageLabel.Size = new Size(140, 30);
            averageLabel.TabIndex = 5;
            // 
            // calculateButton
            // 
            calculateButton.Font = new Font("標楷體", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            calculateButton.Location = new Point(136, 324);
            calculateButton.Name = "calculateButton";
            calculateButton.Size = new Size(143, 59);
            calculateButton.TabIndex = 6;
            calculateButton.Text = "計算";
            calculateButton.UseVisualStyleBackColor = true;
            calculateButton.Click += calculateButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("標楷體", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            exitButton.Location = new Point(377, 324);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(143, 59);
            exitButton.TabIndex = 7;
            exitButton.Text = "離開";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // logListBox
            // 
            logListBox.Font = new Font("標楷體", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 136);
            logListBox.FormattingEnabled = true;
            logListBox.ItemHeight = 13;
            logListBox.Location = new Point(573, 71);
            logListBox.Name = "logListBox";
            logListBox.Size = new Size(217, 212);
            logListBox.TabIndex = 8;
            // 
            // button1
            // 
            button1.Font = new Font("標楷體", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            button1.Location = new Point(618, 324);
            button1.Name = "button1";
            button1.Size = new Size(143, 59);
            button1.TabIndex = 9;
            button1.Text = "總平均油耗";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 500);
            Controls.Add(button1);
            Controls.Add(logListBox);
            Controls.Add(exitButton);
            Controls.Add(calculateButton);
            Controls.Add(averageLabel);
            Controls.Add(gasTextBox);
            Controls.Add(distanceTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox distanceTextBox;
        private TextBox gasTextBox;
        private Label averageLabel;
        private Button calculateButton;
        private Button exitButton;
        private ListBox logListBox;
        private Button button1;
    }
}
