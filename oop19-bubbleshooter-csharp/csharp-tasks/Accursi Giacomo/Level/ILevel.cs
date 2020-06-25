namespace csharp_tasks.Accursi_Giacomo.Level
{
    /// <summary>
    /// Represents the game. It's responsible to initialize all IBubbles and create new row of bubbles. 
    /// </summary>
    public interface ILevel
    {

        /// <summary>
        /// Number of bubble per row in the game.
        /// </summary>
        const int NumBubblesPerRow = 19; 

        /// <summary>
        /// Number of row of bubbles in the game.
        /// </summary>
        const int NumRows = 8; 
        
        /// <summary>
        /// Starts selected game and initialize all bubbles.
        /// </summary>
        void Start();

         /// <summary>
         /// Updates the game;
         /// </summary>
         /// <param name="elapsed"> Time elapsed every gameLoop cycle. </param>
        void Update(double elapsed);

        /// <summary>
        /// Loads the ShootingBubble.
        /// </summary>
        void LoadShootingBubble();

        /// <summary>
        /// Loads the SwitchBubble.
        /// </summary>
        void LoadSwitchBubble();

        /// <summary>
        /// Getter for BubbleGridHelper.
        /// </summary>
        BubbleGridHelper BubbleGridHelper { get; }
       
        /// <summary>
        /// Getter for BubbleFactory.
        /// </summary>
        BubbleFactory BubbleFactory { get; }

        /// <summary>
        /// Getter for BubbleManager.
        /// </summary>
        BubblesManager BubblesManager { get; }

        /// <summary>
        /// Getter for BubbleGridManager.
        /// </summary>
        BubbleGridManager BubbleGridManager { get; }

        /// <summary>
        /// Getter for CollisionController
        /// </summary>
        CollisionController CollisionController { get; }

        /// <summary>
        /// Getter for GameData
        /// </summary>
        GameData GameData { get; }

        /// <summary>
        /// Getter and Setter for GameStatus
        /// </summary>
        GameStatus Status { get; set; }

        /// <summary>
        /// Getter and Setter for LevelType
        /// </summary>
        LevelType LevelType { get; set; }
    }
}