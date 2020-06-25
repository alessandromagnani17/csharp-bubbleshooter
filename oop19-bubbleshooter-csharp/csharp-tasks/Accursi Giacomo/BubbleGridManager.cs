using System.Collections.Generic;
using System.Linq;
using csharp_tasks.Acampora_Andrea;
using csharp_tasks.Accursi_Giacomo.Level;

namespace csharp_tasks.Accursi_Giacomo
{
    public class BubbleGridManager
    {
        public int CreatedRows { get; set; } 
        public bool OffSetRow { get; set; }
        private readonly ILevel Level;

        public BubbleGridManager(ILevel level)
        {
            this.Level = level;
            this.OffSetRow = false;
            this.CreatedRows = 0; 
        }

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

        private void MoveDownBubbles()
        {
            foreach (IBubble bubble in this.GetBubbleGrid().AsEnumerable())
            {
                bubble.SetPosition(new Point2D(bubble.Position.X, bubble.Position.Y + bubble.Width));
            }
        }

        public IBubble AddToGrid(IBubble bubble, Point2D position)
        {
            IBubble bubbleToAdd = this.Level.BubbleFactory.CreateGridBubble(position, bubble.Color); 
            this.Level.BubblesManager.AddBubbles(new List<IBubble>(){bubbleToAdd});
            this.Level.LoadShootingBubble();
            this.Level.LoadSwitchBubble();
            return bubbleToAdd; 
        }

        private List<IBubble> GetBubbleGrid()
        {
            return this.Level.BubblesManager.BubbleGrid; 
        }
        
    }
}