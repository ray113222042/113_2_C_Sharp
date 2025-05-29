using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Toss
{   // 這個類別代表一枚硬幣，可以用來模擬擲硬幣的動作
    internal class Coin
    {
        private string sideUp; // 硬幣的正面或反面
        Random rand = new Random();// 隨機數生成器
        // 建構函式，初始化硬幣的正面為 "正面"
        public Coin()
        {
            sideUp = "正面";
        }
        // 擲硬幣的方法，隨機決定硬幣的正面或反面
        public void Toss()
        {
           
            if (rand.Next(2) == 0)
            {
                sideUp = "正面"; // 50% 機率為正面
            }
            else
            {
                sideUp = "反面"; // 50% 機率為反面
            }
        }
        // 屬性，返回硬幣的正面或反面
        public string GetSideUp()
        {
            return sideUp;
        }
    }
}
