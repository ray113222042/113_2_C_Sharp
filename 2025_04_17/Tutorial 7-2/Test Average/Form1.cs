using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Test_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Average 方法接受一個 int 陣列參數
        // 並返回該陣列中值的平均值。
        private double Average(int[] scores)
        {
            int total = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                total += scores[i];
            }
            return (double)total / scores.Length;
        }

        // Highest 方法接受一個 int 陣列參數
        // 並返回該陣列中的最高值。
        private int Highest(int[] scores)
        {
            int highest = scores[0];
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] > highest)
                {
                    highest = scores[i];
                }
            }
            return highest;
        }

        // Lowest 方法接受一個 int 陣列參數
        // 並返回該陣列中的最低值。
        private int Lowest(int[] scores)
        {
            int lowest = scores[0];
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] < lowest)
                {
                    lowest = scores[i];
                }
            }
            return lowest;
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 48;
            int[] testScores = new int[SIZE];
            int count = 0;
            int highestscore = 0;
            int lowestscore = 0;
            double averageScore = 0.0;
            StreamReader inputFile;
            try
            {
                // 打開文件。  
                inputFile = File.OpenText("TestScores.txt");
                // 清空 ListBox。  
                testScoresListBox.Items.Clear();
                // 從文件中讀取測試分數。  
                while (!inputFile.EndOfStream)
                {
                    // 從文件中讀取一個分數。  
                    testScores[count] = Convert.ToInt32(inputFile.ReadLine());
                    // 將分數添加到 ListBox。  
                    testScoresListBox.Items.Add(testScores[count]);
                    count++;
                }
                inputFile.Close();

                // 計算最高分、最低分和平均分。  
                highestscore = Highest(testScores);
                lowestscore = Lowest(testScores);
                averageScore = Average(testScores);

                // 顯示結果。  
                MessageBox.Show($"最高分: {highestscore}\n最低分: {lowestscore}\n平均分: {averageScore:F2}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤: ");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
