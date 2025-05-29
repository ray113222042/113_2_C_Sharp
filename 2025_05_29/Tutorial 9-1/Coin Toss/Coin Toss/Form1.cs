using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coin_Toss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tossButton_Click(object sender, EventArgs e)
        {
            // 建立一個新的 Coin 物件  
            Coin myCoin = new Coin();
            outputListBox.Items.Clear(); // 清空 ListBox

            for(int i = 0; i < 5; i++)
            { 
               myCoin.Toss();// 擲硬幣
               outputListBox.Items.Add(myCoin.GetSideUp());// 將結果加入 ListBox
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
