using System;
using System.Drawing;

namespace GameAsteroids2
{
    class Asteroids:BaseObject
    {
        Image image;
        Rectangle destRect;
        public int Power { get; set; }
        /// <summary>
        /// Creates asteroid with random picture. And batteries.
        /// Создает астероид с рандомной картинкой. И батарейки.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Asteroids(Point pos, Point dir, Size size, Random r) : base(pos, dir, size)
        {
            switch (r.Next(1,6))
            {
                case 1:
                    image = Resource1.Asteroid1;
                    Power = 5;
                    break;
                case 2:
                    image = Resource1.Asteroid1;
                    Power = 5;
                    break;
                case 3:
                    image = Resource1.BatteryTransparent;
                    Power = -1;
                    break;
                default:
                    image = Resource1.Asteroid2;
                    Power = 5;
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
            if (Pos.X < 0) Pos.X = Game.Width -100;
            if (Pos.X + Size.Width > Game.Width) Pos.X = 50;
            if (Pos.Y < 0) Pos.Y = Game.Height - 100;
            if (Pos.Y + Size.Height > Game.Height) Pos.Y = 50;
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
