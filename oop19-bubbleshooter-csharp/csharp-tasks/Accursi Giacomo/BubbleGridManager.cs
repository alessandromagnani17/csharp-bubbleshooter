using System.Collections.Generic;
using System.Linq;
using csharp_tasks.Acampora_Andrea;
using csharp_tasks.Accursi_Giacomo.Level;

namespace csharp_tasks.Accursi_Giacomo
{
    public class BubbleGridManager
    {
        private int CreatedRows { get; set; } 
        private bool OffSetRow { get; set; }
        private ILevel Level;

        public BubbleGridManager(ILevel level)
        {
            this.Level = level;
            this.OffSetRow = false;
            this.CreatedRows = 0; 
        }

        public List<IBubble> CreateNewRow(int bubblesPerRow)
        {
            List<IBubble> newRow = new List<IBubble>();
            double offset = this.OffSetRow ? Ibubble.WIDTH : Ibubble.RADIUS; //da sistemare, non si possono assegnare campi statici ad una interfaccia
            this.MoveDownBubbles();
            for (int x = 0; x < bubblesPerRow; x++)
            {
                newRow.Add(this.Level.BubbleFactory.CreateGridBubble(new Point2D(x * IBubble.WIDTH + offset, Ibubble.RADIUS)));
            }

            this.CreatedRows++;
            this.OffSetRow = !OffSetRow;
            return newRow;

        }

        private void MoveDownBubbles()
        {
            foreach (IBubble bubble in this.GetBubbleGrid().AsEnumerable())
            {
                bubble.SetPosition(new Point2D(bubble.));
            }
        }

        private List<IBubble> GetBubbleGrid()
        {
            return this.Level.BubblesManager.BubbleGrid; 
        }
        
    }
}