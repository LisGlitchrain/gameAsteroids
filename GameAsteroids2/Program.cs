using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameAsteroids2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form1 form = new Form1();
            form.Width = 800;
            form.Height = 600;
            SplashScreen.Init(form);
            form.Show();
            SplashScreen.Draw();
            Application.Run(form);
        }
    }
}
