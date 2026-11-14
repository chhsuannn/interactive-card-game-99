using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _99_1
{
    public partial class Form2 : Form
    {
        //建立牌庫
        List<int> num = new List<int> { 0, 11, 11, 11, 11, 12, 12, 12, 13, 13, 13, 10, 99, 99, 99, 99, 100, 100, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9 };
        List<int> my_card = new List<int>(); //建立我的手牌
        List<int> cpu_card = new List<int>(); //建立電腦的手牌
        Random rnd = new Random(); //隨機亂數
        int now; //現在數值
        bool isplayer = true; //判斷現在是否為玩家回合
        bool end = false; //判斷遊戲是否結束
        SoundPlayer music = new SoundPlayer(Application.StartupPath + "\\bgm.wav"); //遊戲的背景音樂

        private void playmusic() 
        {
            music.Play(); //開始播放
        }
        public Form2()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\cards\\table.png");
            playmusic(); //播放音樂
            pictureBox12.Image = Image.FromFile(Application.StartupPath + "\\cards\\point_cpu.png"); //輪到電腦
            pictureBox13.Image = Image.FromFile(Application.StartupPath + "\\cards\\point_me.png"); //輪到玩家
            pictureBox12.Visible = false; //一開始先隱藏 輪到電腦的圖片
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\cards\\back.png");

            now = 0; //初始設定為0
            for (int start = 2; start <= 11; start++) //起始抽牌，總共抽10張
            {
                int n = rnd.Next(num.Count); //隨機從牌庫出牌
                if (start <= 6) //先抽玩家手牌
                {
                    my_card.Add(num[n]); //將抽到的牌加入自己牌庫
                    PictureBox Pic = (PictureBox)this.Controls["pictureBox" + start]; 
                    // 利用PictureBox類型，建立Pic變數，讓它可以帶入變數start，指定第start張圖片
                    Pic.Image = Image.FromFile(Application.StartupPath + "\\cards\\" + num[n] + ".png"); //將自己抽到的牌顯示在第start張上
                }
                else //再抽電腦手牌
                {
                    cpu_card.Add(num[n]); //將抽到的牌加入電腦牌庫
                }
                num.Remove(num[n]); //把被抽到的牌序從清單移除
            }
        }

        public bool decide_cpu(int a) //判斷電腦選擇的牌能否出
        {
            int temp = now;
            //if (a == 0) nulll();

            if (a == 10) temp = 0;
            // else if (a == 11) 
            else if (a == 12) temp += 20;
            else if (a == 13) temp -= 20;
            else if (a == 99) temp = 99;
            //else if (a == 100) king();
            else
            {
                for (int i = 1; i <= 9; i++)
                {
                    if (a == i) temp += i;
                }
            }

            if (temp < 0) temp = 0;
            if (temp <= 99) return true;
            else return false;
            //label2.Text = now.ToString();
        }
        public int changepoint(int a) //變更點數
        {
            if (a == 0) nulll(); //牌序0: 執行nulll函式
            else if (a == 10) now = 0; //牌序10: 將點數歸零
            // else if (a == 11)  //牌序11: 跳過 
            else if (a == 12) now += 20; //牌序12: 將點數+20 
            else if (a == 13) now -= 20; //牌序13: 將點數-20 
            else if (a == 99) now = 99; //牌序99: 將點數變為199
            else if (a == 100) king(); //牌序100: 執行king函式
            else //其餘牌: 將點數+1~9
            {
                for (int i = 1; i <= 9; i++)
                {
                    if (a == i) now += i;
                }
            }
            if (now < 0) now = 0; //如果now小於0，點數歸零
            return now; // 回傳now數值
        }
        public void nulll() // 更換全部手牌
        {
            if (isplayer == true) //如果是玩家出此牌
            {
                my_card.Clear(); //將自己手牌歸零
                for (int start = 2; start <= 6; start++) //玩家重新抽5張牌
                {
                    int nnn = rnd.Next(num.Count);
                    my_card.Add(num[nnn]);
                    PictureBox Pic = (PictureBox)this.Controls["pictureBox" + start];
                    Pic.Image = Image.FromFile(Application.StartupPath + "\\cards\\" + num[nnn] + ".png");
                    num.Remove(num[nnn]);
                }
            }
            else //如果是電腦出此牌
            {
                cpu_card.Clear(); //將電腦手牌歸零
                for (int start = 7; start <= 11; start++) //電腦重新抽5張牌
                {
                    int nnn = rnd.Next(num.Count);
                    cpu_card.Add(num[nnn]);
                    num.Remove(num[nnn]);
                }
            }
        }
        public void king() //王牌，隨機點數
        {
            int m = rnd.Next(151); //從0~150隨機抽取數值
            now = m; //更新現在數值
        }
        public void reset_my(int p) //玩家出牌後抽一張
        {
            int n = rnd.Next(num.Count);
            my_card.RemoveAt(p - 2);
            my_card.Insert(p - 2, num[n]);
            PictureBox Pic = (PictureBox)this.Controls["pictureBox" + p];
            Pic.Image = Image.FromFile(Application.StartupPath + "\\cards\\" + num[n] + ".png");
            num.Remove(num[n]);
            isplayer = false; //等下換電腦出牌
            pictureBox12.Visible = true; //顯示 輪到電腦 圖片
            pictureBox13.Visible = false; //隱藏 輪到玩家 圖片
            nextTurn();
        }
        public void reset_cpu(int cp) //電腦出牌後抽一張
        {
            int n = rnd.Next(num.Count);
            cpu_card.RemoveAt(cp);
            cpu_card.Insert(cp, num[n]);
            num.Remove(num[n]);
            isplayer = true; //等下換玩家出牌
            pictureBox12.Visible = false; //隱藏 輪到電腦 圖片
            pictureBox13.Visible = true; //顯示 輪到玩家 圖片
            nextTurn(); 
        }
        private void nextTurn() //玩家、電腦 回合交換
        {
            // 玩家回合結束後，判斷是否遊戲結束

            if (now > 99)
            {
                checkwinner();
            }

            if (isplayer == false && end == false)
            {
                // 玩家回合結束後，轉換為電腦回合

                // pictureBox12.Image = Image.FromFile("C:\\Users\\User\\OneDrive\\桌面\\視窗程式設計\\撲克牌\\point.jpg");
                turn_cpu(); // 讓電腦出牌
            }


            
            label2.Text = now.ToString(); // 更新畫面，顯示現在點數
        }
        public async void checkwinner() //now>99時，判斷誰獲勝
        {
            if (isplayer == false)
            {
                end = true;
                Form5 form = new Form5();
                form.Show();
                await Task.Delay(3000);
                this.Close();
                music.Stop();
            }
            else
            {
                Form4 form = new Form4();
                form.Show();
                await Task.Delay(3000);
                this.Close();
                music.Stop();
            }
        }
        public async void turn_cpu() //輪到電腦出牌
        {
            await Task.Delay(5000); //先延遲5秒
            if (decide_cpu(cpu_card[0]) == false && decide_cpu(cpu_card[1]) == false && decide_cpu(cpu_card[2]) == false && decide_cpu(cpu_card[3]) == false && decide_cpu(cpu_card[4]) == false)
            {
                int nn = rnd.Next(5);
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\cards\\" + cpu_card[nn] + ".png");
                changepoint(cpu_card[nn]);
                reset_cpu(nn);
            }
            else
            {
                while (true)
                {
                    int nn = rnd.Next(5);
                    if (decide_cpu(cpu_card[nn])) //此牌可出
                    {
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\cards\\" + cpu_card[nn] + ".png");
                        changepoint(cpu_card[nn]);
                        reset_cpu(nn);
                        break;
                    }
                }
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e) //手上第1張
        {
            if (isplayer == true) //如果是玩家回合，才能執行動作
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\cards\\" + my_card[0] + ".png"); 
                changepoint(my_card[0]);
                reset_my(2);
            }


        }

        private void pictureBox3_Click(object sender, EventArgs e) //手上第2張
        {
            if (isplayer == true)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\cards\\" + my_card[1] + ".png");
                changepoint(my_card[1]);
                reset_my(3);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e) //手上第3張
        {
            if (isplayer == true)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\cards\\" + my_card[2] + ".png");
                changepoint(my_card[2]);
                reset_my(4);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e) //手上第4張
        {
            if (isplayer == true)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\cards\\" + my_card[3] + ".png");
                changepoint(my_card[3]);
                reset_my(5);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e) //手上第5張
        {
            if (isplayer == true)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\cards\\" + my_card[4] + ".png");
                changepoint(my_card[4]);
                reset_my(6);
            }
        }

        private void button1_Click_1(object sender, EventArgs e) //「卡片介紹」按鈕
        {
            Form6 form = new Form6();
            form.Show(); //顯示「卡片介紹」
        }

        private void button2_Click(object sender, EventArgs e) //「回首頁」按鈕
        {
            Form1 form = new Form1();
            form.Show(); //顯示「首頁」
            music.Stop();
            this.Close();
        }
    }
}
