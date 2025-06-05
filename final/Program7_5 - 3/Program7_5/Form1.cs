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

        // 定義 TeamData 結構
        public class TeamData
        {
            public string TeamName { get; set; }      // 球隊名稱
            public int WinCount { get; set; }         // 獲勝次數
            public List<int> WinYears { get; set; }   // 獲勝年份清單

            public TeamData(string name)
            {
                TeamName = name;
                WinCount = 0;
                WinYears = new List<int>();
            }
        }

        List<string> team;                // 球隊名稱清單
        List<string> winner;              // 冠軍隊伍清單
                                          // 儲存所有球隊與冠軍資料的清單
        List<TeamData> teamDataList = new List<TeamData>();

        string teamsFilePath = "";        // 球隊檔案路徑
        string winnerFilePath = "";       // 冠軍檔案路徑

        private void Form1_Load(object sender, EventArgs e)
        {
            // 選擇 Teams.txt
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "請選擇球隊資料檔 (Teams.txt)",
                Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*"
            };
            MessageBox.Show("請選擇球隊資料檔 (Teams.txt)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                teamsFilePath = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("未選擇球隊資料檔，程式即將結束。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            // 選擇 WorldSeries.txt
            OpenFileDialog openFileDialog2 = new OpenFileDialog
            {
                Title = "請選擇冠軍隊資料檔 (WorldSeries.txt)",
                Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*"
            };
            MessageBox.Show("請選擇冠軍隊資料檔 (WorldSeries.txt)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                winnerFilePath = openFileDialog2.FileName;
            }
            else
            {
                MessageBox.Show("未選擇冠軍資料檔，程式即將結束。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            readTeams();
            readWinner();
            buildTeamDataList();
        }

        // 讀取球隊資料
        private void readTeams()
        {
            try
            {
                team = new List<string>();
                using (StreamReader inputFile = File.OpenText(teamsFilePath))
                {
                    string line;
                    while ((line = inputFile.ReadLine()) != null)
                    {
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

        // 建立 teamDataList
        private void buildTeamDataList()
        {
            teamDataList.Clear();

            // 1. 收集所有隊伍名稱
            HashSet<string> allTeams = new HashSet<string>(team);
            foreach (string w in winner)
                allTeams.Add(w);

            // 2. 建立 TeamData 物件並放入 teamDataList
            foreach (string t in allTeams)
                teamDataList.Add(new TeamData(t));

            // 3. 計算每隊的獲勝次數與年份
            int startYear = 1903;
            int winnerIndex = 0;
            int y = startYear;
            while (winnerIndex < winner.Count)
            {
                if (y == 1904 || y == 1994)
                {
                    y++;
                    continue;
                }
                string winTeam = winner[winnerIndex];
                TeamData td = teamDataList.FirstOrDefault(td2 => td2.TeamName == winTeam);
                if (td != null)
                {
                    td.WinCount++;
                    td.WinYears.Add(y);
                }
                winnerIndex++;
                y++;
            }

            // 依球隊名稱排序
            teamDataList = teamDataList.OrderBy(td => td.TeamName).ToList();

            // 更新 ListBox
            listBox1.Items.Clear();
            foreach (var td in teamDataList)
                listBox1.Items.Add(td.TeamName);
        }

        // ListBox 點選時顯示該球隊奪冠次數及年份
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) return;
            string str = listBox1.SelectedItem.ToString();
            TeamData td = teamDataList.FirstOrDefault(t => t.TeamName == str);

            // 直接從 teamDataList 計算所有奪冠年份的最大最小值
            int startYear = 1903;
            int endYear = 1903;
            var allYears = teamDataList.SelectMany(t => t.WinYears).ToList();
            if (allYears.Count > 0)
            {
                startYear = allYears.Min();
                endYear = allYears.Max();
            }

            if (td == null || td.WinCount == 0)
            {
                label1.Text = str + $" 從 {startYear} 年到 {endYear} 年未獲得過冠軍。";
            }
            else
            {
                label1.Text = str + $" 從 {startYear} 年到 {endYear} 年共獲得 {td.WinCount} 次冠軍。\n奪冠年份：" + string.Join("、", td.WinYears);
            }
        }

        // 新增資料按鈕
        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog3 = new OpenFileDialog
            {
                Title = "請選擇2010年以後MLB冠軍隊伍資料檔",
                Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*"
            };
            MessageBox.Show("請選擇2010年以後MLB冠軍隊伍資料檔", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader inputFile = File.OpenText(openFileDialog3.FileName))
                    {
                        string line;
                        while ((line = inputFile.ReadLine()) != null)
                        {
                            winner.Add(line);
                        }
                    }
                    buildTeamDataList();
                    label1.Text = "資料已成功新增並更新隊伍清單！\n冠軍年份範圍已擴展至 2010 年以後。";
                    MessageBox.Show("資料已成功新增並更新隊伍清單！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取新增資料時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 離開按鈕
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // 將 teamDataList 的球隊名稱存回 teamsFilePath
                File.WriteAllLines(teamsFilePath, teamDataList.Select(td => td.TeamName), Encoding.UTF8);

                // 將 winner 資料存回 winnerFilePath
                File.WriteAllLines(winnerFilePath, winner, Encoding.UTF8);

                MessageBox.Show("資料已成功儲存，程式即將結束。", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("儲存資料時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Close();
            }
        }
    }
}
