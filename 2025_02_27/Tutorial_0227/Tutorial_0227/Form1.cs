namespace Tutorial_0227
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            double distance, gas, average; //宣告區域變數

            if (double.TryParse(distanceTextBox.Text, out distance))
            {
                if (double.TryParse(gasTextBox.Text, out gas))
                {
                    average = distance / gas; //計算平均油耗
                    averageLabel.Text = "平均油耗" + average.ToString("f2") + "公里/公升"; //顯示平均油耗
                    logListBox.Items.Add(average.ToString("f2") + "公里/公升"); //將本次油耗紀錄至ListBox
                }
                else
                {
                    MessageBox.Show("油耗請輸入數字");
                    gasTextBox.Focus(); //將滑鼠游標移至gasTextBox
                    gasTextBox.Text = ""; //清空TextBox
                }
            }
            else
            {
                MessageBox.Show("請輸入文字");
                distanceTextBox.Focus();
                distanceTextBox.Text = ""; //清空TextBox
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); //關閉視窗
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logListBox.Items.Clear();
            logListBox.Items.Add("平均油耗紀錄:"); //顯示ListBox標題
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double sum = 0;
            if (logListBox.Items.Count > 1)
            {
                for(int i=1; i < logListBox.Items.Count; i++)
                {
                    sum += double.Parse(logListBox.Items[i].ToString().Replace("公里/公升", ""));
                }
                logListBox.Items.Add("平均油耗:" + (sum / (logListBox.Items.Count - 1)).ToString("f2") + "公里/公升");
            }
            else
            {
                MessageBox.Show("沒有紀錄");
            }
        }
    }
}



