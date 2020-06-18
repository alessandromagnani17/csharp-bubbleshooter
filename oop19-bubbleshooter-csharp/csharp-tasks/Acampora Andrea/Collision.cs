namespace csharp_tasks.Acampora_Andrea
{
    public class Collision
    {
        private IBubble ShootingBubble { get; set; }
        private  IBubble GridBubble { get; set; }

        public Collision(IBubble shootingBubble, IBubble gridBubble)
        {
            this.ShootingBubble = shootingBubble;
            this.GridBubble = gridBubble;
        }
        
        
    }
}