using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameAsteroids2
{
    /// <summary>
    /// Звезда
    /// </summary>
    class Star: BaseObject
    {
        SolidBrush myBrush;
        Rectangle destRect;
        static int DEFAULT_ALPHA = 255;
        static int DEFAULT_RED = 20;
        static int DEFAULT_GREEN = 20;
        static int DEFAULT_BLUE = 50;

        /// <summary>
        /// Basic constructor of star object.
        /// Основной конструктор объекта "звезда".
        /// </summary>
        /// <param position="pos"></param>
        /// <param direction of movement="dir"></param>
        /// <param size of object="size"></param>
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            myBrush = new SolidBrush(Color.FromArgb(DEFAULT_ALPHA, DEFAULT_RED * Size.Height, DEFAULT_GREEN * Size.Height, DEFAULT_BLUE * Size.Height));
            destRect = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Drawing of object.
        /// Отрисовка объекта.
        /// </summary>
        public override void Draw()
        {
            
            destRect.X = Pos.X;
            destRect.Y = Pos.Y;
            Game.Buffer.Graphics.FillRectangle(myBrush, destRect);
        }

        /// <summary>
        /// Computing next position of object.
        /// Вычисление новой позиции объекта.
        /// </summary>
        public override void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }

    }
}
