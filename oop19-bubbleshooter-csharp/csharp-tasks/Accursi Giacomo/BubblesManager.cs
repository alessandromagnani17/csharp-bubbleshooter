#nullable enable

using System.Collections.Generic;
using System.Linq;
using csharp_tasks.Acampora_Andrea;

namespace csharp_tasks.Accursi_Giacomo
{
    public class BubblesManager
    {
        private List<IBubble> bubbles;

        public BubblesManager()
        {
            this.bubbles = new List<IBubble>();
        }

        public void Update(double elapsed)
        {
            this.ShootingBubble?.Update(elapsed);
            this.bubbles.RemoveAll(a => a.IsDestroyed()); 

        }

        public void AddBubbles(List<IBubble> bubblesList)
        {
            this.bubbles.AddRange(bubblesList);
        }
        
        public IBubble? ShootingBubble
        {
            get
            {
                IBubble? shootingBubble = this.bubbles.AsEnumerable().First(a => a.GetType().Equals(BubbleType.ShootingBubble));
                return shootingBubble; 
            }
            
        }
        
        public IBubble? SwitchBubble
        {
            get
            {
                IBubble? switchBubble = this.bubbles.AsEnumerable().First(a => a.GetType().Equals(BubbleType.SwitchBubble));
                return switchBubble;  
            }
             
        }
        
        public List<IBubble> BubbleGrid
        {
            get
            {
                return this.bubbles.AsEnumerable().Where(a => a.GetType().Equals(BubbleType.GridBubble)).ToList();
            }
        }

        public List<IBubble> AllBubbles => bubbles;
    }
}