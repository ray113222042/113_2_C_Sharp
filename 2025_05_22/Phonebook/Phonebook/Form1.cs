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
using System.Linq.Expressions;

namespace Phonebook
{
    struct PhoneBookEntry
    {
        public string name; // 儲存聯絡人的名稱
        public string phone; // 儲存聯絡人的電話號碼
    }

    public partial class Form1 : Form
    {
        // 用於儲存 PhoneBookEntry 物件的清單
        private List<PhoneBookEntry> phoneList =
            new List<PhoneBookEntry>();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ReadFile 方法用於讀取 PhoneList.txt 檔案的內容，
        /// 並將其儲存為 PhoneBookEntry 物件，存入 phoneList 清單中。
        /// </summary>
        private void ReadFile()
        {
            StreamReader inputFile;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                inputFile = File.OpenText(openFile.FileName); // 開啟選擇的檔案
                string line;
                while (!inputFile.EndOfStream)
                {
                    line = inputFile.ReadLine().Trim(); // 讀取每一行並去除多餘空白
                    string[] parts = line.Split(',');
                    // 將每一行分割為名稱和電話號碼，並存入 PhoneBookEntry 物件
                    if (parts.Length == 2)
                    {
                        PhoneBookEntry entry = new PhoneBookEntry();

                        entry.name = parts[0].Trim(); // 儲存名稱
                        entry.phone = parts[1].Trim(); // 儲存電話號碼
                        phoneList.Add(entry); // 將物件加入清單
                    }
                    else
                    {
                        MessageBox.Show("未選擇檔案。"); // 顯示錯誤訊息
                    }
                }
                inputFile.Close(); // 關閉檔案
            }
        }

        /// <summary>
        /// DisplayNames 方法用於將名稱清單顯示在 nameListBox 控制項中。
        /// </summary>
        private void DisplayNames()
        {
            foreach (PhoneBookEntry entry in phoneList)
            {
                nameListBox.Items.Add(entry.name); // 將名稱加入列表框
            }
        }

        /// <summary>
        /// 當表單載入時觸發的事件處理方法。
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile(); // 讀取電話簿檔案
            DisplayNames(); // 顯示電話簿名稱
        }

        /// <summary>
        /// 當用戶選擇名稱列表中的項目時觸發的事件處理方法。
        /// </summary>
        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex; // 獲取選中的索引
            if (index != -1)
            {
                phoneLabel.Text = phoneList[index].phone; // 顯示對應的電話號碼
            }
            else
            {
                phoneLabel.Text = "無資料"; // 如果未選擇任何項目，顯示“無資料”
            }
        }


        /// <summary>
        /// 當用戶點擊退出按鈕時觸發的事件處理方法。
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單，結束程式。
            this.Close();

            //把phoneList的資料寫進原來檔案
            if (openFile.FileName != null && File.Exists(openFile.FileName))
            {
                try
                {
                    using (StreamWriter outputFile = new StreamWriter(openFile.FileName))
                    {
                        foreach (PhoneBookEntry entry in phoneList)
                        {
                            outputFile.WriteLine($"{entry.name},{entry.phone}");
                        }
                    }
                    MessageBox.Show("資料已成功儲存至檔案！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"儲存檔案時發生錯誤：{ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("無法儲存資料，檔案不存在或未選擇檔案。");
            }
            //把phoneList的資料寫進原來檔案
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 檢查 NameBox 和 PhoneBox 是否有輸入資料  
            if (!string.IsNullOrWhiteSpace(Namebox.Text) && !string.IsNullOrWhiteSpace(PhoneBox.Text))
            {
                // 建立新的 PhoneBookEntry 物件  
                PhoneBookEntry newEntry;
                newEntry.name = Namebox.Text.Trim();
                newEntry.phone = PhoneBox.Text.Trim();

                // 將新資料加入 phoneList  
                phoneList.Add(newEntry);

                // 將新姓名顯示在 nameListBox  
                nameListBox.Items.Add(newEntry.name);

                // 清空輸入框  
                Namebox.Clear();
                PhoneBox.Clear();

                // 提示使用者資料已新增  
                MessageBox.Show("資料已成功新增！");
            }
            else
            {
                // 提示使用者輸入資料  
                MessageBox.Show("請輸入完整的姓名和電話號碼！");
            }
        }
    }
}
 