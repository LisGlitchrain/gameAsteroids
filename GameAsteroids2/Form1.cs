using System;
using System.Windows.Forms;
using System.IO;

namespace GameAsteroids2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            nameBox.Hide();
            nameBox.KeyDown += new KeyEventHandler(tb_KeyDown);
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StreamWriter sw = new StreamWriter("highScores.txt");
                sw.WriteLine($"{nameBox.Text} : {SplashScreen.score.ScoreValue}");
                sw.Close();
                nameBox.Hide();
            }
        }

        private void startLabel_Click(object sender, EventArgs e)
        {
            SplashScreen.SplashScreenStop();
            SplashScreen.ShowHighScores = false;
            exitLabel.Hide();
            recordsLabel.Hide();
            startLabel.Hide();
            pictureBox1.Hide();
            try
            {
                if (this.Width > 1000 || this.Width < 0 || this.Height > 1000 || this.Height < 0)
                {
                    throw new ArgOutOfRangeException("Недопустимое значение размера окна");

                }
                Game.Init(this);
            }
            catch (ArgOutOfRangeException)
            {

            }
        }

        private void recordsLabel_Click(object sender, EventArgs e)
        {
            nameBox.Hide();
            SplashScreen.ShowHighScores = true;
        }

        private void exitLabel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
