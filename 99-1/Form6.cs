using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _99_1
{
    public partial class Form6 : Form
    {
        int i = 0; //用來記錄 頁數
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\cards\\introduce.png");
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\cards\\rule.png");
            label2.Text = ("1/4"); // 表示目前在規則第1頁
        }

        private void button1_Click(object sender, EventArgs e) //「下一頁」按鈕
        {
            if (i == 0)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\cards\\rule-1.png"); //規則第2頁
                i++;
                label2.Text = ("2/4"); 
                button2.Visible = true; //當頁數不在第1頁時，就顯示「上一頁」按鈕
            }
            else if (i == 1)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\cards\\rule-2.png"); //規則第3頁
                i++;
                label2.Text = ("3/4");
            }
            else if (i == 2)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\cards\\rule-3.png"); //規則第4頁
                i++;
                button1.Visible = false; //當頁數在第4頁(最後一頁)時，就隱藏「下一頁」按鈕
                label2.Text = ("4/4");
            }

        }

        private void button2_Click(object sender, EventArgs e) //「上一頁」按鈕
        {
            if (i == 3)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\cards\\rule-2.png"); //規則第3頁
                i--;
                button1.Visible = true; //當頁數不在第4頁(最後一頁)時，就顯示「下一頁」按鈕
                label2.Text = ("3/4");
            }
            else if (i == 2)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\cards\\rule-1.png"); //規則第2頁
                i--;
                label2.Text = ("2/4");
            }
            else if (i == 1)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\cards\\rule.png"); //規則第1頁
                i--;
                button2.Visible = false; //當頁數在第1頁時，就隱藏「上一頁」按鈕
                label2.Text = ("1/4");
            }
        }
    }
}
