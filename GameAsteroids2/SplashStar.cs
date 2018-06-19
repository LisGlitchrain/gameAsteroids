using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameAsteroids2
{
    class SplashStar: SplashBaseObj
    {
        SolidBrush myBrush;
        Rectangle destRect;
        static int DEFAULT_ALPHA = 255;
        static int DEFAULT_RED = 20;
        static int DEFAULT_GREEN = 20;
        static int DEFAULT_BLUE = 50;

        /// <summary>
        /// Creates star object.
        /// Создает объект звезды.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public SplashStar(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            myBrush = new SolidBrush(Color.FromArgb(DEFAULT_ALPHA, DEFAULT_RED * Size.Height, DEFAULT_GREEN * Size.Height, DEFAULT_BLUE * Size.Height));
            destRect = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Draws star.
        /// Отрисовывает звезду.
        /// </summary>
        public override void Draw()
        {

            destRect.X = Pos.X;
            destRect.Y = Pos.Y;
            SplashScreen.Buffer.Graphics.FillRectangle(myBrush, destRect);
        }
        /// <summary>
        /// Updates position of the star.
        /// Обновляет позицию звезды.
        /// </summary>
        public override void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X < 0) Pos.X = SplashScreen.Width + Size.Width;
        }

        
    }
}
