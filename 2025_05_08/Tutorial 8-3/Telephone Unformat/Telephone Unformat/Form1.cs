using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidFormat 方法接受一個字串參數，
        // 用於判斷該字串是否正確地格式化為台灣電話號碼。
        // 格式應為：(XX)XXXX-XXXX，其中：
        // - XX 表示區碼，必須為 2 位數字，並用括號括起來。
        // - XXXX 表示電話號碼的前 4 位數字。
        // - XXXX 表示電話號碼的後 4 位數字。
        // - 中間必須有一個連字號（-）。
        // 如果字串符合上述格式，則方法返回 true；否則返回 false。
        private bool IsValidFormat(string str)
        {
            if (str.Length == 13 &&
                str[0] == '(' &&
                str[3] == ')' &&
                str[8] == '-' &&
                int.TryParse(str.Substring(1, 2), out _) && // 驗證區碼為數字
                int.TryParse(str.Substring(4, 4), out _) && // 驗證電話號碼前 4 位為數字
                int.TryParse(str.Substring(9, 4), out _))   // 驗證電話號碼後 4 位為數字
            {
                return true;
            }
            return false;
        }
           

              // Unformat 方法接受一個字串參數（以引用方式傳遞），
              // 該字串假設包含格式化的電話號碼，格式為：(XX)XXXX-XXXX。
              // 此方法的功能是移除字串中的括號和連字號，將其轉換為純數字格式。
              // 例如，輸入 "(123)456-7890" 將被轉換為 "1234567890"。
              private void Unformat(ref string str)
        {
            // 移除括號和連字號
            str = str.Remove(0, 1);
            str = str.Remove(2, 1);
            str = str.Remove(6, 1);
        }


        // unformatButton_Click 方法是當使用者按下「去格式化」按鈕時觸發的事件處理器。
        // 此方法的功能是：
        // 1. 從輸入框中取得使用者輸入的電話號碼。
        // 2. 驗證電話號碼是否符合格式 (XXX)XXX-XXXX。
        // 3. 如果格式正確，則呼叫 Unformat 方法移除格式，並顯示結果。
        // 4. 如果格式不正確，則顯示錯誤訊息。
        private void unformatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text;

            if (IsValidFormat(input))
            {
                Unformat(ref input);
                MessageBox.Show("去格式化的電話號碼是：" + input, "結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("請輸入正確格式的電話號碼 (XX)XXXX-XXXX", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // exitButton_Click 方法是當使用者按下「離開」按鈕時觸發的事件處理器。
        // 此方法的功能是關閉目前的表單，結束應用程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }

        private void instructionLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
