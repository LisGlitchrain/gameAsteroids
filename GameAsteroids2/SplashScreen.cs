using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GameAsteroids2
{
    static class SplashScreen
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static SplashBaseObj[] _objs;
        static Timer timer;

        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        static SplashScreen()
        {
        }

        /// <summary>
        /// Initialize splash screen.
        /// Инициализация заставки.
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

            timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Creates of visual resources.
        /// Создает визуальные ресурсы.
        /// </summary>
        public static void Load()
        {
            _objs = new SplashBaseObj[90];
            Random r = new Random();
            //var sunDefinitiveValue = r.Next(100, 160);
            //_objs[0] = new AnimatedObject(new Point(r.Next(1, 800), r.Next(1, 600)), new Point(sunDefinitiveValue / 100, r.Next(-4, 4)), new Size(sunDefinitiveValue, sunDefinitiveValue), Resource1.sun2);
            for (int i = 0; i < 90; i++)
            {
                var definitiveValue = r.Next(1, 5);
                _objs[i] = new SplashStar(new Point(r.Next(1, 800), r.Next(1, 600)), 
                                          new Point(definitiveValue, r.Next(-4, 4)), 
                                          new Size(definitiveValue, definitiveValue));
            }

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
            foreach (SplashBaseObj obj in _objs)
                obj.Draw();

            Buffer.Render();
        }

        /// <summary>
        /// Computates new positions of the objects on the screen.
        /// Вычисляет новые позиции объектов на экране.
        /// </summary>
        public static void Update()
        {
            foreach (SplashBaseObj obj in _objs)
                obj.Update();

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        /// <summary>
        /// Stops splash screen and frees graphic resources.
        /// Останавливает отрисовку заставки и освобождает ресурсы.
        /// </summary>
        public static void SplashScreenStop()
        {
            timer.Dispose();
            _objs = null;
            _context.Dispose();
            Buffer.Dispose();
        }

    }

}
