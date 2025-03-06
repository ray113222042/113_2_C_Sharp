using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.CodeDom.Compiler;

namespace Program5_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader inputFile;
            int sum = 0;
            int count = 0;
            int temp;
            try
            {
                inputFile = File.OpenText("Names.txt");//開啟檔案
                while (!inputFile.EndOfStream)//當沒有讀到檔案結尾時(代表檔案中還有資廖)
                {
                    count++;
                    temp = int.Parse(inputFile.ReadLine());
                    sum += temp;
                    listBox1.Items.Add(temp);
                }
                listBox1.Items.Add("總共有" +count+"個數字\n總和"+ sum);
                inputFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }   
        }
    }
}
