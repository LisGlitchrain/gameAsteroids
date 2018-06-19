using System.Drawing;

namespace GameAsteroids2
{
    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        /// <summary>
        /// Creates object with pointer params.
        /// Создает объект с заданными параметрами.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        protected BaseObject(Point pos, Point dir, Size size)
        {
            if (pos.X < 0 || pos.X > Game.Width || pos.Y < 0 || pos.Y > Game.Height)
            {
                throw new GameObjectException("Неверная позиция.");
            }
            Pos = pos;
            if (dir.X < -15 || dir.X > 15 || dir.Y < -15 || dir.Y > 15)
            {
                throw new GameObjectException("Слишком большая скорость.");
            }
            Dir = dir;
            if (size.Width < 0 || size.Width > 200 || size.Height < 0 || size.Height > 200)
            {
                throw new GameObjectException("Неверный размер объекта.");
            }
            Size = size;
        }

        public Rectangle Rect => new Rectangle(Pos, Size);

        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);

        public abstract void Draw();

        public abstract void Update();

        
    }

}
