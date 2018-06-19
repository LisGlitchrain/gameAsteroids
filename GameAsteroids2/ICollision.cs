using System.Drawing;

namespace GameAsteroids2
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }

}
