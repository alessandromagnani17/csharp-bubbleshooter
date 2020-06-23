using csharp_tasks.Acampora_Andrea;

namespace csharp_tasks.Accursi_Giacomo
{
    public class BubbleFactory
    {
        public IBubble CreateGridBubble(Point2D position, BubbleColor color)
        {
            return new GridBubble(position, color); 
        }
        
        public IBubble CreateShootingBubble(Point2D position, BubbleColor color)
        {
            return new GridBubble(position, color); 
        }
        
        public IBubble CreateSwitchBubble(Point2D position, BubbleColor color)
        {
            return new GridBubble(position, color); 
        }
    }
}