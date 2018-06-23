using System;
using System.Drawing;

namespace GameAsteroids2
{
    /// <summary>
    /// Player's ship.
    /// Корабль игрока.
    /// </summary>
    class Ship: BaseObject
    {
        private int _energy = 100;
        private Image image;
        private Rectangle rect;
        /// <summary>
        /// Field contains energy of ship.
        /// </summary>
        public int Energy => _energy;
        public EventHandler EnergyChanged;

        /// <summary>
        /// Method processes event of setting value of _energy.
        /// </summary>
        protected virtual void OnEnegryChanged()
        {
            EnergyChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Method setting _energy of the ship.
        /// </summary>
        /// <param name="n"></param>
        public void DecreaseEnergy(int n)
        {
            _energy -= n;
            if (_energy > 100) _energy = 100;
            OnEnegryChanged();
        }

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            image = Resource1.ship;
            rect = new Rectangle(Pos,Size);
        }

        /// <summary>
        /// Draws ship.
        /// </summary>
        public override void Draw()
        {
            //Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(image,rect);
        }

        /// <summary>
        /// Looks like indian code.
        /// </summary>
        public override void Update()
        {
        }

        /// <summary>
        /// Translate ship up.
        /// </summary>
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
            rect.Y = Pos.Y;
        }
        /// <summary>
        /// Translate ship down.
        /// </summary>
        public void Down()
        {
            if (Pos.Y+Size.Height < Game.Height) Pos.Y = Pos.Y + Dir.Y;
            rect.Y = Pos.Y;
        }
        /// <summary>
        /// Doing nothing when ship's energy is zero.
        /// </summary>
        public void Die()
        {
        }
    }
}
