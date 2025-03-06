using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Program5_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // 修改表單標題和字型大小
            this.Text = "表單1";
            this.Font = new Font(this.Font.FontFamily, 18);

            // 修改按鈕文字和字型大小
            button1.Text = "按鈕1";
            button1.Font = new Font(button1.Font.FontFamily, 18);
            button1.Size = new Size(150, 50); // 調整按鈕大小
            button1.Location = new Point(50, 100); // 調整按鈕位置

            // 假設還有一個標籤
            Label label1 = new Label();
            label1.Text = "標籤1";
            label1.Font = new Font(label1.Font.FontFamily, 18);
            label1.Size = new Size(150, 50); // 調整標籤大小
            label1.Location = new Point(50, 30); // 調整標籤位置
            this.Controls.Add(label1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            StreamWriter outputFile;
            int count;

            try
            {
                outputFile = File.AppendText("numbers.txt");
                if (int.TryParse(textBox1.Text, out count))
                {
                    for (int i = 0; i < count; i++)
                    {
                        outputFile.WriteLine(random.Next(100)+1);
                    }
                    outputFile.Close();
                    MessageBox.Show("檔案已經建立");
                }
                else
                {
                    MessageBox.Show("請輸入一個數字");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}