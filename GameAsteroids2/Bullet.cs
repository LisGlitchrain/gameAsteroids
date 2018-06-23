using System;
using System.Drawing;

namespace GameAsteroids2
{
    class Bullet:BaseObject
    {
        /// <summary>
        /// Creates bullet object. (I'm captain obvious.)
        /// Создает объект пули. (Я кэп очевидность просто. О.о)
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Draws bullet.
        /// Отрисовывает пулю.
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width,
            Size.Height);
        }
        /// <summary>
        /// Computates new bullet's position.
        /// Вычисляет новую позицию пули.
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X > Game.Width) Pos.X = 0;
        }
        /// <summary>
        /// Randomly changes bullet position.
        /// Случайно меняет позицию пули.
        /// </summary>
        /// <param name="xMin"></param>
        /// <param name="xMax"></param>
        /// <param name="yMin"></param>
        /// <param name="yMax"></param>
        /// <param name="r"></param>
        public void Regenerate(int xMin, int xMax, int yMin, int yMax, Random r)
        {
            Pos.X = r.Next(xMin, xMax);
            Pos.Y = r.Next(yMin, yMax);
        }
    }
}
