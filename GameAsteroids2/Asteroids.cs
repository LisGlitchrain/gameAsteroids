using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameAsteroids2
{
    class Asteroids:BaseObject
    {
        Image image;
        public Asteroids(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Random r = new Random();
            switch (r.Next(1,3))
            {
                case 1:
                    image = Resource1.Asteroid1;
                    break;
                default:
                    image = Resource1.Asteroid2;
                    break;
            }
        }

        public override void Draw()
        {
            Rectangle destRect = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(image, destRect);
        }
    }
}
