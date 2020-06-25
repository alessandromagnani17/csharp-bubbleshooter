using System.ComponentModel;
using csharp_tasks.Accursi_Giacomo;

namespace csharp_tasks.Acampora_Andrea
{
    public class ShootingBubble : AbstractBubble
    {
        public ShootingBubble(Point2D position) : base(BubbleType.ShootingBubble,position)
        {
            Type = BubbleType.ShootingBubble;
            Position = position;
        }

        public void SetComponents()
        {
            Components.Add(new CollisionComponent(this));
        }
    }
}