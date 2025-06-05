using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Program7_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 使用 List<string> 來存放球隊與冠軍資料
        List<string> team;
        List<string> winner;

        // 檔案路徑
        string teamsFilePath = "";
        string winnerFilePath = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            // 讓使用者選擇 Teams.txt 檔案
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "請選擇球隊資料檔 (Teams.txt)";
            openFileDialog1.Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
            MessageBox.Show("請選擇球隊資料檔 (Teams.txt)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                teamsFilePath = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("未選擇球隊資料檔，程式即將結束。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // 讓使用者選擇 WorldSeries.txt 檔案
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Title = "請選擇冠軍隊資料檔 (WorldSeries.txt)";
            openFileDialog2.Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
            MessageBox.Show("請選擇冠軍隊資料檔 (WorldSeries.txt)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                winnerFilePath = openFileDialog2.FileName;
            }
            else
            {
                MessageBox.Show("未選擇冠軍資料檔，程式即將結束。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            readTeams();
            readWinner();
        }

        // 讀取球隊資料
        private void readTeams()
        {
            try
            {
                team = new List<string>();
                listBox1.Items.Clear();
                using (StreamReader inputFile = File.OpenText(teamsFilePath))
                {
                    string line;
                    while ((line = inputFile.ReadLine()) != null)
                    {
                        listBox1.Items.Add(line);
                        team.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取球隊資料時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 讀取冠軍資料
        private void readWinner()
        {
            try
            {
                winner = new List<string>();
                using (StreamReader inputFile = File.OpenText(winnerFilePath))
                {
                    string line;
                    while ((line = inputFile.ReadLine()) != null)
                    {
                        winner.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取冠軍資料時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 當選取球隊時，顯示該球隊奪冠次數及年份
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = listBox1.SelectedItem.ToString();
            int numWin = 0;
            List<int> years = new List<int>();

            // MLB 冠軍年份，1904、1994 沒有舉辦
            for (int i = 0, y = 1903; i < winner.Count && y <= 2009; i++)
            {
                if (y == 1904 || y == 1994)
                {
                    y++;
                    i--; // 該年未舉辦，winner 沒有資料，i 不遞增
                    continue;
                }
                if (str == winner[i])
                {
                    numWin++;
                    years.Add(y);
                }
                y++;
            }

            if (numWin == 0)
            {
                label1.Text = str + " 從 1903 年到 2009 年未獲得過冠軍。";
            }
            else
            {
                label1.Text = str + " 從 1903 年到 2009 年共獲得 " + numWin + " 次冠軍。\n奪冠年份：" + string.Join("、", years);
            }
        }
    }
}
