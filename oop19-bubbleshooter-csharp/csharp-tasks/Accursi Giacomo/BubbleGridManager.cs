using System.Collections.Generic;
using System.Linq;
using csharp_tasks.Acampora_Andrea;
using csharp_tasks.Accursi_Giacomo.Level;

namespace csharp_tasks.Accursi_Giacomo
{
    /// <summary>
    /// Class used to add, remove bubble from bubble grid and create new row of IBubbles.
    /// </summary>
    public class BubbleGridManager
    {
        public int CreatedRows { get; set; } 
        public bool OffSetRow { get; set; }
        private readonly ILevel Level;

        /// <summary>
        /// Constructor of {@link BubbleGridManager} used to initialize the ILevel
        /// </summary>
        /// <param name="level"> The level of the game. </param>
        public BubbleGridManager(ILevel level)
        {
            this.Level = level;
            this.OffSetRow = false;
            this.CreatedRows = 0; 
        }

        /// <summary>
        /// Creates new row on the top of the grid.
        /// </summary>
        /// <param name="bubblesPerRow"> Number of Ibubbles in a row</param>
        /// <returns> New row of Ibubbles. </returns>
        public List<IBubble> CreateNewRow(int bubblesPerRow)
        {
            List<IBubble> newRow = new List<IBubble>();
            double offset = this.OffSetRow ? Ibubble.Width : Ibubble.Radius;
            this.MoveDownBubbles();
            for (int x = 0; x < bubblesPerRow; x++)
            {
                newRow.Add(this.Level.BubbleFactory.CreateGridBubble(new Point2D(x * IBubble.Width + offset, Ibubble.Radius)));
            }

            this.CreatedRows++;
            this.OffSetRow = !OffSetRow;
            return newRow;

        }

        /// <summary>
        /// Moves all IBubbles on row down to create new one.
        /// </summary>
        private void MoveDownBubbles()
        {
            foreach (IBubble bubble in this.GetBubbleGrid().AsEnumerable())
            {
                bubble.SetPosition(new Point2D(bubble.Position.X, bubble.Position.Y + bubble.Width));
            }
        }

        /// <summary>
        /// Creates a new Ibubble and tells the BubbleManager to add it to the game.
        /// </summary>
        /// <param name="bubble"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public IBubble AddToGrid(IBubble bubble, Point2D position)
        {
            IBubble bubbleToAdd = this.Level.BubbleFactory.CreateGridBubble(position, bubble.Color); 
            this.Level.BubblesManager.AddBubbles(new List<IBubble>(){bubbleToAdd});
            this.Level.LoadShootingBubble();
            this.Level.LoadSwitchBubble();
            return bubbleToAdd; 
        }
        
        /// <summary>
        /// Gets all Ibubbles in the grid.
        /// </summary>
        /// <returns></returns>
        private List<IBubble> GetBubbleGrid()
        {
            return this.Level.BubblesManager.BubbleGrid; 
        }
        
    }
}