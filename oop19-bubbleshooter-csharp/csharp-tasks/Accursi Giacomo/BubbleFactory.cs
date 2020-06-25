using csharp_tasks.Acampora_Andrea;

namespace csharp_tasks.Accursi_Giacomo
{
    /// <summary>
    /// Represents a factory for IBubbles.
    /// </summary>
    public class BubbleFactory
    {
        /// <summary>
        /// Creates new GridBubble.
        /// </summary>
        /// <param name="position"> The position of the IBubble. </param>
        /// <param name="color"> The Color of the IBubble. </param>
        /// <returns> A new IBubble. </returns>
        public IBubble CreateGridBubble(Point2D position, BubbleColor color)
        {
            return new GridBubble(position, color); 
        }
        /// <summary>
        /// Creates new ShootingBubble.
        /// </summary>
        /// <param name="position"> The position of the IBubble. </param>
        /// <param name="color"> The Color of the IBubble. </param>
        /// <returns> A new IBubble. </returns>
        public IBubble CreateShootingBubble(Point2D position, BubbleColor color)
        {
            return new ShootingBubble(position, color); 
        }
        /// <summary>
        /// Creates new SwitchBubble 
        /// </summary>
        /// <param name="position"> The position of the IBubble. </param>
        /// <param name="color"> The Color of the IBubble. </param>
        /// <returns> A new IBubble. </returns>
        public IBubble CreateSwitchBubble(Point2D position, BubbleColor color)
        {
            return new SwitchBubble(position, color); 
        }
    }
}