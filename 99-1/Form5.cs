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
    public partial class Form5 : Form //電腦勝利
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\cards\\fail.png");
        }

        private void button1_Click(object sender, EventArgs e) //「回首頁」按鈕
        {
            Form1 form = new Form1(); 
            form.Show(); //顯示「首頁」視窗
            this.Close(); //將此視窗關閉
        }
    }
}
