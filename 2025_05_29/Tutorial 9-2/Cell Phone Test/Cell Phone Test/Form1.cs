using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // GetPhoneData 方法會接收一個 CellPhone 物件作為參數。
        // 此方法會將使用者在表單上輸入的資料指派給該物件的屬性。
        // 包含品牌、型號與價格，並進行必要的資料驗證。
        private void GetPhoneData(CellPhone phone)
        {
            // 取得品牌輸入框的文字，並指派給 phone 物件的 Brand 屬性
            phone.Brand = brandTextBox.Text.Trim();

            // 取得型號輸入框的文字，並指派給 phone 物件的 Model 屬性
            phone.Model = modelTextBox.Text.Trim();

            // 嘗試將價格輸入框的文字轉換為 decimal 型別
            decimal price;
            if (decimal.TryParse(priceTextBox.Text.Trim(), out price))
            {
                phone.Price = price;
            }
            else
            {
                // 若轉換失敗，顯示錯誤訊息並將焦點設回價格輸入框
                MessageBox.Show("請輸入有效的價格（數字）", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                priceTextBox.Focus();
            }
        }

        private void createObjectButton_Click(object sender, EventArgs e)
        {
            // 建立一個新的 CellPhone 物件
            CellPhone myPhone = new CellPhone();

            // 呼叫 GetPhoneData 方法，將使用者輸入的資料指派給 myPhone 物件
            GetPhoneData(myPhone);

            // 將 myPhone 物件的屬性顯示在表單上的標籤
            brandLabel.Text = myPhone.Brand;
            modelLabel.Text = myPhone.Model;
            priceLabel.Text = myPhone.Price.ToString("C");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單，結束程式執行
            this.Close();
        }
    }
}
