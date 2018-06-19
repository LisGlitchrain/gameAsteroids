using System.Drawing;

namespace GameAsteroids2
{
    /// <summary>
    /// Базовый объект заставки.
    /// </summary>
    class SplashBaseObj
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        /// <summary>
        /// Создает базовый объект. 
        /// </summary>
        /// <param позиция="pos"></param>
        /// <param направление движения="dir"></param>
        /// <param размер="size"></param>
        public SplashBaseObj(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        
        /// <summary>
        /// Метод рисует белый эллипс.
        /// </summary>
        public virtual void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);

        }
        
        /// <summary>
        /// Рассчитывает смещение объекта с учетом границ экрана.
        /// </summary>
        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X + Size.Width > SplashScreen.Width || Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.Y + Size.Height > SplashScreen.Height || Pos.Y < 0) Dir.Y = -Dir.Y;
        }

    }
}
