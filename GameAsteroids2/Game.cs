using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Media;
using System.Collections.Generic;

namespace GameAsteroids2
{
    static class Game
    {
        private static BufferedGraphicsContext context;
        public static BufferedGraphics Buffer;
        private static BaseObject[] objs;
        private static Bullet bullet;
        private static List<Asteroids> asteroids;
        private static Ship ship;
        public static Score score;
        private static StreamWriter sw;
        //private static SoundPlayer bulletSound;
        //private static SoundPlayer asteroidSound;
        private static SoundPlayer bgm;
        private static int asteroidsCount = 10;
        private static Timer timer;

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
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));

            //bulletSound = new SoundPlayer(Resource1.GunSound1);
            //asteroidSound = new SoundPlayer(Resource1.BulletCollision);
            bgm = new SoundPlayer(Resource1._8bit_adventures_for_Asteroids);
            sw = new StreamWriter("log.txt");
            sw.AutoFlush = true;
            sw.WriteLine("Game init.");
            
            Load();

            timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

            form.KeyDown += Form_KeyDown;
        }

        private static void OnEnergyChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"Energy: {ship.Energy}. Time: {DateTime.Now}.");
            sw.WriteLine($"Energy: {ship.Energy}. Time: {DateTime.Now}.");
            
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
                bullet = new Bullet(new Point(ship.Rect.X + 10, ship.Rect.Y + 4), new Point(15, 0), new Size(4, 1));
                //bulletSound.Play();
            }
            if (e.KeyCode == Keys.Up) ship.Up();
            if (e.KeyCode == Keys.Down) ship.Down();
        }

        /// <summary>
        /// Creates graphic resources.
        /// Создает графические ресурсы.
        /// </summary>
        public static void Load()
        { 
            // Create the following graphic resources: 1 sun, 86 stars, 2 planets, and 10 asteroids
            ship = new Ship(new Point(30, 300), new Point(5, 5), new Size(50, 50));
            ship.EnergyChanged += OnEnergyChanged;
            score = new Score { ScoreValue = 0 };
            score.ScoreChanged += OnScoreChanged;
            bgm.PlayLooping();
            objs = new BaseObject[90];
            asteroids = new List<Asteroids>();
            var r = new Random();
            var sunSize = r.Next(100, 160);

            // create the Sun
            objs[0] = new AnimatedObject(new Point(r.Next(1, Width), r.Next(1, Height)), 
                                          new Point(sunSize / 100, r.Next(-4, 4)), 
                                          new Size(sunSize, sunSize), Resource1.sun2);
            // create the stars
            for (int i = 1; i < 88; i++)
            {
                var starSize = r.Next(1, 5);
                objs[i] = new Star(new Point(r.Next(1, Width), r.Next(1, Height)),
                                    new Point(starSize, r.Next(-4, 4)),
                                    new Size(starSize, starSize));
            }
            // Create the two planets
            objs[88] = new Planet(new Point(r.Next(1, Width), r.Next(1, Height)), new Point(3, 0), new Size(60, 60), Resource1.Planet1);
            objs[89] = new Planet(new Point(r.Next(1, Width), r.Next(1, Height)), new Point(5, 0), new Size(60, 60), Resource1.Planet1);

            CreateAsteroids(asteroidsCount, new Random());

        }

        /// <summary>
        /// Draws graphics.
        /// Отрисовывает графику.
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in objs)
                obj.Draw();
            foreach (Asteroids a in asteroids)
                a?.Draw();

            bullet?.Draw();
            ship?.Draw();
            if (ship != null)
                Buffer.Graphics.DrawString("Energy:" + ship.Energy, new Font("PIXEL", 14), Brushes.White, 20, 20);
            Buffer.Graphics.DrawString("SCORE:" + score.ScoreValue, new Font("PIXEL", 14), Brushes.White, Width-120, 20);
            Buffer.Render();
        }
        /// <summary>
        /// Computates new positions of the objects and processes collisions of bullet and astedoids.
        /// Вычисляет новые позиции объектов и обрабатывает столкновения пули и астероидов.
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in objs) obj.Update();
            bullet?.Update();
            for (var i = 0; i < asteroids.Count; i++)
            {
                if (asteroids[i] == null) continue;
                asteroids[i].Update();
                if (bullet != null && bullet.Collision(asteroids[i]))
                {
                    //asteroidSound.Play();
                    bullet = null;
                    score.ScoreValue += asteroids[i].Power > 0 ? 1 : 0;
                    asteroids.RemoveAt(i);
                    continue;
                }
                if (!ship.Collision(asteroids[i])) continue;
                ship?.DecreaseEnergy(asteroids[i].Power);
                //System.Media.SystemSounds.Asterisk.Play();
                asteroids.RemoveAt(i);
                if (ship.Energy <= 0) ship?.Die();
            }
            if(asteroids.Count == 0)
            {
                asteroidsCount++;
                CreateAsteroids(asteroidsCount, new Random());
            }

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        private static void CreateAsteroids(int count, Random r)
        {
            for (int i = 0; i < count; i++)
            {
                int asteroidSize = r.Next(5, 15);
                asteroids.Add(new Asteroids(new Point(r.Next(Width - 100, Width), r.Next(100, Height - 100)), new Point(-asteroidSize, r.Next(-5, 5)), new Size(asteroidSize * 3, asteroidSize * 3), r));
            }      
        }
        /// <summary>
        /// Frees game's resources.
        /// </summary>
        public static void GameStop()
        {
            Program.form.KeyDown -= Form_KeyDown;
            timer.Dispose();
            objs = null;
            ship = null;
            bullet = null;
            asteroids.Clear();
            context.Dispose();
            Buffer.Dispose();
        }

    }

}
