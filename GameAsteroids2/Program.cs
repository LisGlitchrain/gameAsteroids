using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameAsteroids2
{
    static class Program
    {
        static int SCREEN_WIDTH = 800;
        static int SCREEN_HEIGHT = 600;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form1 form = new Form1();
            form.Width = SCREEN_WIDTH;
            form.Height = SCREEN_HEIGHT;
            SplashScreen.Init(form);
            form.Show();
            SplashScreen.Draw();
            Application.Run(form);

        }
    }
}
