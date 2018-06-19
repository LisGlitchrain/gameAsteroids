using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameAsteroids2
{
    /// <summary>
    /// Класс, отрисовывающий фоновую, скользящую, не анимированную картинку.
    /// </summary>
    class Planet: BaseObject
    {
        Image image;
        Rectangle destRect;

        /// <summary>
        /// basic constructor.
        /// Базовый конструктор.
        /// </summary>
        /// <param pos="position"></param>
        /// <param dir="direction of movement"></param>
        /// <param size="size of object"></param>
        /// <param image="image"></param>
        public Planet(Point pos, Point dir, Size size, Image image) : base(pos, dir, size)
        {
            this.image = image;
            this.destRect = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Drawing of object.
        /// Отрисовка объекта.
        /// </summary>
        public override void Draw()
        {
            destRect.X = Pos.X;
            destRect.Y = Pos.Y;
            Game.Buffer.Graphics.DrawImage(image, destRect);
        }

        /// <summary>
        /// Computing next position of object.
        /// Вычисление следующей позиции.
        /// </summary>
        public override void Update()
        {
            if (Pos.X + Size.Width < -5000)
            {
                Random r = new Random();
                Pos.X = Game.Width + Size.Width;
                Pos.Y = r.Next(100, 500);
            }
            Pos.X = Pos.X - Dir.X;
        }
    }

}
