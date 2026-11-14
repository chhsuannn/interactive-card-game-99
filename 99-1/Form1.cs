namespace _99_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\cards\\home.png"); // form1的背景圖片
        }

        private void button1_Click(object sender, EventArgs e) //「開始」按鈕
        {
            //按下開始後
            Form2 form = new Form2(); 
            form.Show(); // 顯示「遊戲畫面」視窗
            this.Hide(); //把這個視窗隱藏
        }

        private void button2_Click(object sender, EventArgs e) //「玩法介紹」按鈕
        {
            Form6 form = new Form6();
            form.Show(); //顯示「玩法介紹」視窗
        }
    }
}