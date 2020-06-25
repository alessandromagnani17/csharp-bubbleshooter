namespace csharp_tasks.Acampora_Andrea
{
    public class Collision
    {
        public IBubble ShootingBubble { get; }
        public  IBubble GridBubble { get; }

        public Collision(IBubble shootingBubble, IBubble gridBubble)
        {
            ShootingBubble = shootingBubble;
            GridBubble = gridBubble;
        }
    }
}