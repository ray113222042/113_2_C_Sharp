using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery_Numbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 5; // 定義陣列大小為5
            int[] lotteryNumbers = new int[SIZE]; // 宣告一個大小為5的整數陣列
            Random random = new Random(); // 建立一個隨機數生成器

            for (int i = 0; i < lotteryNumbers.Length; i++)
            {
                int number;
                do
                {
                    number = random.Next(1, 43); // 產生1到42之間的亂數(包含1和42)
                } while (lotteryNumbers.Contains(number)); // 確認產生的亂數沒有在陣列中重複
                lotteryNumbers[i] = number; // 將亂數放入陣列中
            }

            // 將 lotteryNumbers 陣列中的數字由小到大排序
            Array.Sort(lotteryNumbers);

            // 將表單上的 Label 控制項存入一個 Label 陣列中
            Label[] labels = { label1, label2, label3, label4, label5 };

            // 將排序後的數字顯示在 Label 控制項上
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Text = lotteryNumbers[i].ToString();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}
