using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Media;

namespace GameAsteroids2
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static BaseObject[] _objs;
        private static Bullet _bullet;
        private static Asteroids[] _asteroids;
        private static Ship _ship;
        private static Score score;
        private static StreamWriter sw;
        private static SoundPlayer bulletSound;
        private static SoundPlayer asteroidSound;

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

            bulletSound = new SoundPlayer(Resource1.GunSound1);
            asteroidSound = new SoundPlayer(Resource1.BulletCollision);
            //bool APPEND = true;
            sw = new StreamWriter("log.txt");
            sw.AutoFlush = true;
            sw.WriteLine("Game init.");
            
            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

            form.KeyDown += Form_KeyDown;
        }

        private static void OnEnergyChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"Energy: {_ship.Energy}. Time: {DateTime.Now}.");
            sw.WriteLine($"Energy: {_ship.Energy}. Time: {DateTime.Now}.");
            
        }

        private static void OnScoreChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"Score: {score.ScoreValue}. Time: {DateTime.Now}.");
            sw.WriteLine($"Score: {score.ScoreValue}. Time: {DateTime.Now}.");
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.ControlKey)
            {
                _bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(15, 0), new Size(4, 1));
                bulletSound.Play();
            }
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }

        /// <summary>
        /// Creates graphic resources.
        /// Создает графические ресурсы.
        /// </summary>
        public static void Load()
        {
            
            
            // Create the following graphic resources: 1 sun, 86 stars, 2 planets, and 10 asteroids


            _ship = new Ship(new Point(30, 300), new Point(5, 5), new Size(50, 50));
            _ship.EnergyChanged += OnEnergyChanged;
            score = new Score { ScoreValue = 0 };
            score.ScoreChanged += OnScoreChanged;

            _objs = new BaseObject[90];
            _asteroids = new Asteroids[10];
            var r = new Random();
            var sunSize = r.Next(100, 160);

            // create the Sun
            _objs[0] = new AnimatedObject(new Point(r.Next(1, Width), r.Next(1, Height)), 
                                          new Point(sunSize / 100, r.Next(-4, 4)), 
                                          new Size(sunSize, sunSize), Resource1.sun2);
            // create the stars
            for (int i = 1; i < 88; i++)
            {
                var starSize = r.Next(1, 5);
                _objs[i] = new Star(new Point(r.Next(1, Width), r.Next(1, Height)),
                                    new Point(starSize, r.Next(-4, 4)),
                                    new Size(starSize, starSize));
            }
            // Create the two planets
            _objs[88] = new Planet(new Point(r.Next(1, Width), r.Next(1, Height)), new Point(3, 0), new Size(60, 60), Resource1.Planet1);
            _objs[89] = new Planet(new Point(r.Next(1, Width), r.Next(1, Height)), new Point(5, 0), new Size(60, 60), Resource1.Planet1);

            for (int i = 0; i < _asteroids.Length; i++)
            {
                int asteroidSize = r.Next(5, 15);
                _asteroids[i] = new Asteroids(new Point(r.Next(100,Width-100), r.Next(100, Height-100)), new Point(-asteroidSize, r.Next(-5,5)), new Size(asteroidSize*3, asteroidSize*3));
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
            //Buffer.Graphics.Clear(Color.Black);
            //foreach (BaseObject obj in _objs)
            //    obj.Draw();

            //foreach (Asteroids obj in _asteroids)
            //    obj.Draw();
            //_bullet.Draw();

            //Buffer.Render();


            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroids a in _asteroids)
                a?.Draw();

            _bullet?.Draw();
            _ship?.Draw();
            if (_ship != null)
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, new Font("PIXEL", 14), Brushes.White, 20, 20);
            Buffer.Graphics.DrawString("SCORE:" + score.ScoreValue, new Font("PIXEL", 14), Brushes.White, Width-120, 20);
            Buffer.Render();


        }
        /// <summary>
        /// Computates new positions of the objects and processes collisions of bullet and astedoids.
        /// Вычисляет новые позиции объектов и обрабатывает столкновения пули и астероидов.
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs) obj.Update();
            _bullet?.Update();
            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();
                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                {
                    asteroidSound.Play();
                    _asteroids[i].Regenerate(100, Game.Width - 100, 100, Game.Height - 100, new Random());
                    _bullet = null;
                    score.ScoreValue += _asteroids[i].Power > 0 ? 1 : 0;
                    continue;
                }
                if (!_ship.Collision(_asteroids[i])) continue;
                _asteroids[i].Regenerate(100, Game.Width - 100, 100, Game.Height - 100, new Random());
                _ship?.DecreaseEnergy(_asteroids[i].Power);
                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0) _ship?.Die();
            }

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void StreamWriterClose()
        {
            //sw.Close();
        }
    }

}
