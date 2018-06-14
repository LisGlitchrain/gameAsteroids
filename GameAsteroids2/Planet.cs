using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameAsteroids2
{
    class Planet: BaseObject
    {
        Image image;
        public Planet(Point pos, Point dir, Size size, Image image) : base(pos, dir, size)
        {
            this.image = image;
        }

        public override void Draw()
        {
            Rectangle destRect = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(image, destRect);
        }

        public override void Update()
        {
            if (Pos.X + Size.Width < -5000)
            {
                Random r = new Random();
                Pos.X = Game.Width + Size.Width;
                Pos.Y = r.Next(100, 500);
            }
            Pos.X = Pos.X - Dir.X;
        }
    }
    
}
