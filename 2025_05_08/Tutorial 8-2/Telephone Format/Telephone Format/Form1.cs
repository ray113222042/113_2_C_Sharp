using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidNumber 方法接受一個字串作為參數。
        // 此方法的功能是檢查傳入的字串是否包含 10 個數字。
        // 如果字串中包含恰好 10 個數字，則回傳 true，表示該字串有效。
        // 如果字串中不包含 10 個數字，則回傳 false，表示該字串無效。
        private bool IsValidNumber(string str)
        {
            const int VALID_LENGTH = 10;

            // 檢查字串長度是否為 10
            if (str.Length == VALID_LENGTH)
            {
                // 檢查字串中的每個字元是否為數字
                for (int i = 0; i < str.Length; i++)
                {
                    if (!char.IsDigit(str[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        // TelephoneFormat 方法接受一個字串參數，並以參考方式傳遞。
        // 此方法的功能是將傳入的字串格式化為電話號碼的標準形式。
        // 格式化後的電話號碼形式為 (XXX) XXX-XXXX，其中 X 代表數字。
        // 例如，傳入 "1234567890" 的字串，格式化後會變成 "(123) 456-7890"。
        private void TelephoneFormat(ref string str)
        {
            // 在字串的開頭插入 "("
            str = str.Insert(0, "(");
            // 在字串的第 3 個位置插入 ") "
            str = str.Insert(3, ") ");
            // 在字串的第 9 個位置插入 "-"
            str = str.Insert(9, "-");
        }

        // 當使用者按下「格式化」按鈕時，會觸發此事件處理方法。
        // 此方法的功能是從輸入框中取得使用者輸入的字串，並檢查其是否有效。
        // 如果輸入的字串有效，則會將其格式化為電話號碼，並顯示在適當的位置。
        // 如果輸入的字串無效，則可能會顯示錯誤訊息，提示使用者重新輸入。
        private void formatButton_Click(object sender, EventArgs e)
        {
            // 取得使用者輸入的字串
            string input = numberTextBox.Text;

            // 檢查輸入是否為有效的 10 位數字
            if (IsValidNumber(input))
            {
                // 格式化字串為電話號碼
                TelephoneFormat(ref input);

                // 顯示格式化後的電話號碼
                MessageBox.Show(input, "格式化電話號碼", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // 顯示錯誤訊息，提示使用者重新輸入
                MessageBox.Show("請輸入有效的 10 位數字！", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 當使用者按下「退出」按鈕時，會觸發此事件處理方法。
        // 此方法的功能是關閉目前的表單，結束應用程式的執行。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
