using System;
using System.Windows.Forms;

namespace GameAsteroids2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startGameBtn_Click(object sender, EventArgs e)
        {
            SplashScreen.SplashScreenStop();
            Form form2 = FindForm();
            exitBtn.Hide();
            recordsBtn.Hide();
            this.startGameBtn.Hide();
            pictureBox1.Hide();
            try
            {
                if (form2.Width > 1000 || form2.Width < 0 || form2.Height > 1000 || form2.Height < 0)
                {
                    throw new ArgOutOfRangeException("Недопустимое значение размера окна");
                    
                }
                Game.Init(form2);
            }
            catch (ArgumentOutOfRangeException)
            {

            }
            //form2.Show();
            Game.Draw();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
