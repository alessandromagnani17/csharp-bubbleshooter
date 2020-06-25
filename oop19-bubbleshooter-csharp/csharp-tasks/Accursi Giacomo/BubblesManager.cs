#nullable enable
using System.Collections.Generic;
using System.Linq;
using csharp_tasks.Acampora_Andrea;

namespace csharp_tasks.Accursi_Giacomo
{
    /// <summary>
    /// Class that hold and manages all the IBubbles in the game.
    /// </summary>
    public class BubblesManager
    {
        private List<IBubble> bubbles;

        /// <summary>
        /// Constructor used to initialize bubbles list.
        /// </summary>
        public BubblesManager()
        {
            this.bubbles = new List<IBubble>();
        }

        /// <summary>
        /// Updates the ShootingBubble and removes the destroyed Bubbles.
        /// </summary>
        /// <param name="elapsed"> Time elapsed every gameLoop cycle. </param>
        public void Update(double elapsed)
        {
            this.ShootingBubble?.Update(elapsed);
            this.bubbles.RemoveAll(a => a.IsDestroyed());
        }
       
        /// <summary>
        /// Add Bubbles to the list.
        /// </summary>
        /// <param name="bubblesList"> List off Bubbles to add. </param>
        public void AddBubbles(List<IBubble> bubblesList)
        {
            this.bubbles.AddRange(bubblesList);
        }

        /// <summary>
        /// Gets the ShootingBubble.
        /// </summary>
        public IBubble? ShootingBubble
        {
            get

            {
                IBubble? shootingBubble = this.bubbles.AsEnumerable()
                    .First(a => a.GetType().Equals(BubbleType.ShootingBubble));
                return shootingBubble;
            }
        }

        /// <summary>
        /// Gets the SwitchBubble.
        /// </summary>
        public IBubble? SwitchBubble
        {
            get
            {
                IBubble? switchBubble =
                    this.bubbles.AsEnumerable().First(a => a.GetType().Equals(BubbleType.SwitchBubble));
                return switchBubble;
            }
        }

        /// <summary>
        /// Gets the list of Bubbles in the grid 
        /// </summary>
        public List<IBubble> BubbleGrid
        {
            get { return this.bubbles.AsEnumerable().Where(a => a.GetType().Equals(BubbleType.GridBubble)).ToList(); }
        }

        /// <summary>
        /// Gets all Bubbles in the game
        /// </summary>
        public List<IBubble> AllBubbles => bubbles;
    }
}