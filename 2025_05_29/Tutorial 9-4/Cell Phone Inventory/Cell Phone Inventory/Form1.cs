using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Inventory
{
    public partial class Form1 : Form
    {
        // 用來儲存 CellPhone 物件的清單
        List<CellPhone> phoneList = new List<CellPhone>();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// GetPhoneData 方法會接收一個 CellPhone 物件作為參數，
        /// 並將使用者於表單輸入的資料指派給該物件的屬性。
        /// </summary>
        /// <param name="phone">要填入資料的 CellPhone 物件</param>
        private void GetPhoneData(CellPhone phone)
        {
            // 暫存手機價格的變數
            decimal price;

            // 取得使用者輸入的品牌並指派給手機物件的 Brand 屬性
            phone.Brand = brandTextBox.Text;

            // 取得使用者輸入的型號並指派給手機物件的 Model 屬性
            phone.Model = modelTextBox.Text;

            // 取得使用者輸入的價格，並嘗試轉換為 decimal 型別
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                phone.Price = price;
            }
            else
            {
                // 若價格格式錯誤，顯示錯誤訊息提示使用者
                MessageBox.Show("價格格式無效，請輸入正確的數字。");
            }
        }

        /// <summary>
        /// 當使用者點擊「新增手機」按鈕時觸發此事件。
        /// </summary>
        private void addPhoneButton_Click(object sender, EventArgs e)
        {
            CellPhone myPhone = new CellPhone(); // 建立新的 CellPhone 物件
            GetPhoneData(myPhone); // 呼叫 GetPhoneData 方法填入資料
            phoneList.Add(myPhone); // 將新的手機物件加入清單
            //將新增手機的品牌跟型號組合成字串，並加入倒ListBox中
            phoneListBox.Items.Add(myPhone.Brand + " " + myPhone.Model);

            // 清空輸入欄位 準備下次輸入
            brandTextBox.Text = "";
            modelTextBox.Text = "";
            priceTextBox.Text = "";


        }

        /// <summary>
        /// 當使用者於手機清單中選取不同項目時觸發此事件。
        /// </summary>
        private void phoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = phoneListBox.SelectedIndex;// 取得選取的項目索引

            MessageBox.Show(phoneList[index].Price.ToString("C"));// 顯示選取手機的價格，格式化為貨幣形式
        }

        /// <summary>
        /// 當使用者點擊「離開」按鈕時觸發此事件，關閉表單。
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉目前的視窗表單
            this.Close();
        }
    }
}
