using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameAsteroids2
{
    class Asteroid : BaseObject, ICloneable
    {
        public int Power { get; set; }

        /// <summary>
        /// Basic constructor
        /// Базовый конструктор
        /// </summary>
        /// <param position="pos"></param>
        /// <param direction of movement="dir"></param>
        /// <param size="size"></param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        /// <summary>
        /// Drawing of object 
        /// Отрисовка объекта
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y,
            Size.Width, Size.Height);
        }

        /// <summary>
        /// Computing next position of object
        /// Вычисление новой позиции объекта
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
        /// Deep cloning
        /// Глубокое клонирование
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            // Создаем копию нашего робота
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new
            Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height));
            // Не забываем скопировать новому астероиду Power нашего астероида
            asteroid.Power = Power;
            return asteroid;
        }

    }
}
