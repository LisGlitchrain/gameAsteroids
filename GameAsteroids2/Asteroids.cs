using System;
using System.Drawing;

namespace GameAsteroids2
{
    class Asteroids:BaseObject
    {
        Image image;
        Rectangle destRect;

        /// <summary>
        /// Creates asteroid with random picture.
        /// Создает астероид с рандомной картинкой.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Asteroids(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Random r = new Random();
            switch (r.Next(1,3))
            {
                case 1:
                    image = Resource1.Asteroid1;
                    break;
                default:
                    image = Resource1.Asteroid2;
                    break;
            }
            destRect = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Draws asteroid.
        /// Отрисовывает астероид.
        /// </summary>
        public override void Draw()
        {
            destRect.X = Pos.X;
            destRect.Y = Pos.Y;
            Game.Buffer.Graphics.DrawImage(image, destRect);
        }
        
        /// <summary>
        /// Computes new position of asteroid.
        /// Вычисляет новую позицию астероидa.
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X + Size.Width > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y + Size.Height > Game.Height) Dir.Y = -Dir.Y;
        }

        /// <summary>
        /// Changes asteroid position randomly.
        /// Случайно меняет позицию астероида.
        /// </summary>
        /// <param name="Minimum x"></param>
        /// <param name="Maximum x"></param>
        /// <param name="Minimum y"></param>
        /// <param name="Maximum y"></param>
        /// <param name="r"></param>
        public void Regenerate(int xMin, int xMax, int yMin, int yMax, Random r)
        {
            Pos.X = r.Next(xMin, xMax);
            Pos.Y = r.Next(yMin, yMax);
        }
    }
}
