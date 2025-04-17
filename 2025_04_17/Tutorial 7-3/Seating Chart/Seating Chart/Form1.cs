using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seating_Chart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void displayPriceButton_Click(object sender, EventArgs e)
        {
            const int ROWS = 6;
            const int COLS = 4;
            int row;
            int cols;
            decimal[,] seatprices = { {450m, 450m, 450m, 450m},
                                               {425m, 425m, 425m, 425m},
                                               {400m, 400m, 400m, 400m},
                                               {375m, 375m, 375m, 375m},
                                               {375m, 375m, 375m, 375m},
                                               {350m, 350m, 350m, 350m}
                                           };
            if (int.TryParse(rowTextBox.Text, out row))
            {
                if (int.TryParse(colTextBox.Text, out cols))
                {
                    if (row >= 0 && row < ROWS)
                    {
                        if (cols >= 0 && cols < COLS)
                        {
                            // 顯示座位價格
                            priceLabel.Text = seatprices[row, cols].ToString("C");
                        }
                        else
                        {
                            MessageBox.Show("請輸入有效的列號。");
                        }
                    }
                    else
                    {
                        MessageBox.Show("請輸入有效的行號。");
                    }
                }
                else
                {
                    MessageBox.Show("請輸入有效的列號。");
                }
            }
            else
            {
                MessageBox.Show("請輸入有效的行號。");
            }
        }


        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}
