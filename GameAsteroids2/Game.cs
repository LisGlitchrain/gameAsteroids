using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GameAsteroids2
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[] _objs;


        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        static Game()
        {
        }

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

            Timer timer = new Timer { Interval = 25 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        public static void Load()
        {
            _objs = new BaseObject[120];
            Random r = new Random();
            var sunDefinitiveValue = r.Next(100, 160);
            _objs[0] = new AnimatedObject(new Point(r.Next(1, 800), r.Next(1, 600)), new Point(sunDefinitiveValue / 100, r.Next(-4, 4)), new Size(sunDefinitiveValue, sunDefinitiveValue), Resource1.sun2);
            for (int i = 1; i < 88; i++)
            {
                var definitiveValue = r.Next(1, 5);
                _objs[i] = new Star(new Point(r.Next(1, 800), r.Next(1, 600)), new Point(definitiveValue, r.Next(-4, 4)), new Size(definitiveValue, definitiveValue));
            }
            _objs[88] = new Planet(new Point(r.Next(1, 800), r.Next(1, 600)), new Point(3, r.Next(-4, 4)), new Size(60, 60), Resource1.Planet1);
            _objs[89] = new Planet(new Point(r.Next(1, 800), r.Next(1, 600)), new Point(5, r.Next(-4, 4)), new Size(60, 60), Resource1.Planet1);
            
            
            for (int i = 90; i < _objs.Length; i++)
            {
                var size = r.Next(20, 50);
                _objs[i] = new Asteroids(new Point(r.Next(100, 700), r.Next(100, 500)), new Point(r.Next(-4, 4), r.Next(-4, 4)), new Size(size, size));
            }

        }

        public static void Draw()
        {
            // Проверяем вывод графики
            Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            foreach (BaseObject obj in _objs)
                obj.Draw();
            try
            {
                Buffer.Render();
            }
            catch (Exception e)
            {
                Environment.Exit(0);
            }
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}
