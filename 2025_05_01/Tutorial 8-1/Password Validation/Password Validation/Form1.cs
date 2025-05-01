using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Validation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // NumberUpperCase 方法接受一個字串作為參數，
        // 並回傳該字串中包含的大寫字母數量。
        private int NumberUpperCase(string str)
        {
            int uppperCaseCount = 0; // 計數器，初始值為0
            foreach (char c in str) // 遍歷字串中的每個字元
            {
                if (char.IsUpper(c)) // 如果字元是大寫字母
                {
                    uppperCaseCount++; // 計數器加1
                }
            }
            return uppperCaseCount; // 回傳大寫字母的數量
        }

        // NumberLowerCase 方法接受一個字串作為參數，
        // 並回傳該字串中包含的小寫字母數量。
        private int NumberLowerCase(string str)
        {
            int lowerCaseCount = 0; // 計數器，初始值為0
            foreach (char c in str) // 遍歷字串中的每個字元
            {
                if (char.IsLower(c)) // 如果字元是小寫字母
                {
                    lowerCaseCount++; // 計數器加1
                }
            }
            return lowerCaseCount;
        }

        // NumberDigits 方法接受一個字串作為參數，
        // 並回傳該字串中包含的數字字元數量。
        private int NumberDigits(string str)
        {
            int digitCount = 0; // 計數器，初始值為0
            foreach (char c in str) // 遍歷字串中的每個字元
            {
                if (char.IsDigit(c)) // 如果字元是數字
                {
                    digitCount++; // 計數器加1
                }
            }
            return digitCount; // 回傳數字字元的數量
        }

        // 當使用者按下「檢查密碼」按鈕時，觸發此事件處理方法。
        // 此方法將檢查使用者輸入的密碼是否符合特定條件，
        // 例如是否包含足夠的大寫字母、小寫字母和數字。
        private void checkPasswordButton_Click(object sender, EventArgs e)
        {
            const int MIN_LENGTH = 8; // 密碼的最小長度
            string password = passwordTextBox.Text; // 取得使用者輸入的密碼
            if (password.Length >= MIN_LENGTH &&
                NumberUpperCase(password) > 0&& 
                NumberLowerCase(password) > 0 && 
                NumberDigits(password) > 0)
            {
                MessageBox.Show("密碼有效！", "驗證結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("密碼無效！請確保密碼至少包含8個字元，並包含大小寫字母和數字。", "驗證結果", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        // 當使用者按下「退出」按鈕時，觸發此事件處理方法。
        // 此方法將關閉目前的表單，結束應用程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }

        // 當表單載入時，觸發此事件處理方法。
        // 此方法可用於初始化表單的狀態或載入必要的資料。
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
