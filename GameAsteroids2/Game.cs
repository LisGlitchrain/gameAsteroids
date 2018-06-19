using System;
using System.Windows.Forms;
using System.Drawing;

namespace GameAsteroids2
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static BaseObject[] _objs;
        private static Bullet _bullet;
        private static Asteroids[] _asteroids;


        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        /// <summary>
        /// In consequence of static class this method doing nothing.
        /// Поскольку класс статический, не делает ничего.
        /// </summary>
        static Game()
        {
        }

        /// <summary>
        /// Initialize game.
        /// Инициализирует игру.
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Creates graphic resources.
        /// Создает графические ресурсы.
        /// </summary>
        public static void Load()
        {
            _objs = new BaseObject[90];
            _asteroids = new Asteroids[10];
            var r = new Random();
            var sunDefinitiveValue = r.Next(100, 160);

            _objs[0] = new AnimatedObject(new Point(r.Next(1, Width), r.Next(1, Height)), 
                                          new Point(sunDefinitiveValue / 100, r.Next(-4, 4)), 
                                          new Size(sunDefinitiveValue, sunDefinitiveValue), Resource1.sun2);
            for (int i = 1; i < 88; i++)
            {
                var definitiveValue = r.Next(1, 5);
                _objs[i] = new Star(new Point(r.Next(1, Width), r.Next(1, Height)), 
                                    new Point(definitiveValue, r.Next(-4, 4)), 
                                    new Size(definitiveValue, definitiveValue));
            }
            _objs[88] = new Planet(new Point(r.Next(1, Width), r.Next(1, Height)), new Point(3, r.Next(-4, 4)), new Size(60, 60), Resource1.Planet1);
            _objs[89] = new Planet(new Point(r.Next(1, Width), r.Next(1, Height)), new Point(5, r.Next(-4, 4)), new Size(60, 60), Resource1.Planet1);

            for (int i = 0; i < _asteroids.Length; i++)
            {
                int defiValue = r.Next(5, 15);
                _asteroids[i] = new Asteroids(new Point(100, r.Next(0, Game.Height)), new Point(-defiValue / 5, defiValue), new Size(defiValue*3, defiValue*3));
            }

            _bullet = new Bullet(new Point(50,50), new Point( 0, 1), new Size(10,10));
        }

        /// <summary>
        /// Draws graphics.
        /// Отрисовывает графику.
        /// </summary>
        public static void Draw()
        {
            // Проверяем вывод графики
            Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            foreach (BaseObject obj in _objs)
                obj.Draw();

            foreach (Asteroids obj in _asteroids)
                obj.Draw();
            _bullet.Draw();

            try
            {
                Buffer.Render();
            }
            catch (Exception e)
            {
                Environment.Exit(0);
            }


        }
        /// <summary>
        /// Computates new positions of the objects and processes collisions of bullet and astedoids.
        /// Вычисляет новые позиции объектов и обрабатывает столкновения пули и астероидов.
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            foreach (Asteroids a in _asteroids)
            {
                a.Update();
                if (a.Collision(_bullet)) {
                    System.Media.SystemSounds.Hand.Play();
                    Random r = new Random();
                    a.Regenerate(1,Width,1,Height,r);
                    _bullet.Regenerate(1, Width, 1, Height,r);
                }
            }
            _bullet.Update();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

    }

}
