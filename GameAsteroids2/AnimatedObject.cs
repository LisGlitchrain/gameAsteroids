using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace GameAsteroids2
{
    //To do: fix animation framerate
    class AnimatedObject: BaseObject
    {
        Image animation;
        int activeFrame;
        int framesCount;
        int frameSkipper;
        FrameDimension dimension;
        Rectangle destRect;

        public AnimatedObject(Point pos, Point dir, Size size, Image animation) : base(pos, dir, size)
        {
            this.animation = animation;
            dimension = new FrameDimension(animation.FrameDimensionsList[0]);
            activeFrame = 0;
            frameSkipper = 0;
            framesCount = animation.GetFrameCount(dimension);
            destRect = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        
        public override void Draw()
        {
            destRect.X = Pos.X;
            destRect.Y = Pos.Y;
            Game.Buffer.Graphics.DrawImage(animation, destRect);
        }

        public override void Update()
        {
            frameSkipper++;
            if (frameSkipper > 10) frameSkipper = 0;
            if (activeFrame < framesCount - 1)
            {
                if (frameSkipper == 0) activeFrame ++;
            }
            else
            {
                activeFrame = 0;
            }
            animation.SelectActiveFrame(dimension, activeFrame);
            Pos.X = Pos.X - Dir.X;
            if (Pos.X + Size.Width < 0)
            {
                Random r = new Random();
                Pos.X = Game.Width + Size.Width;
                Pos.Y = r.Next(100, 500);
            }

        }

    }
}
