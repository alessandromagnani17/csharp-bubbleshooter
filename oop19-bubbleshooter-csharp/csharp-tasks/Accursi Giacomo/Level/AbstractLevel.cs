using System;
using System.Collections.Generic;
using csharp_tasks.Acampora_Andrea;

namespace csharp_tasks.Accursi_Giacomo.Level
{
    /// <summary>
    /// Class which contains the main methods of ILevel interface.
    /// </summary>
    public abstract class AbstractLevel : ILevel
    {
        private const int NumBubblePerRow = 19;
        private const int NumRows = 8; 

        private const int MillisecondsInASecond = 1000;
        private static readonly Point2D ShootingBubblePosition = new Point2D(IModel.WorldWidth / 2, IModel.WorldHeight / 1.10);
        private static readonly Point2D SwitchBubblePosition = new Point2D(IModel.WorldWidth / 2, IModel.WorldHeight  / 1.10);
        
        public BubbleGridHelper BubbleGridHelper { get; }
        public BubbleFactory BubbleFactory { get; }
        public BubblesManager BubblesManager { get; }
        public BubbleGridManager BubbleGridManager { get; }
        public CollisionController CollisionController { get; }
        public GameData GameData { get; }
        public GameStatus Status { get; set; }
        public LevelType LevelType { get; set; }
        private GameOverChecker gameOverChecker; 

        /// <summary>
        /// Constructor used to initialize all entities of the ILevel.
        /// </summary>
        public AbstractLevel()
        {
            this.BubblesManager = new BubblesManager();
            this.BubbleFactory = new BubbleFactory();
            this.BubbleGridManager = new BubbleGridManager(this);
            this.BubbleGridHelper = new BubbleGridHelper(this.BubblesManager);
            this.CollisionController = new CollisionController(this);
            this.GameData = new GameData();
            this.gameOverChecker = new GameOverChecker(this);
            this.Status = GameStatus.Pause;

        }
        
        public void Update(double elapsed)
        {
            this.BubblesManager.Update(elapsed);
            this.CollisionController.CheckCollision();
            this.GameData.UpdateGameTime(elapsed);
            this.UpdateScore(elapsed / MillisecondsInASecond);
            if (this.IsTimeToNewRow(elapsed / MillisecondsInASecond))
            {
                this.CreateNewRow();
            }

            if (this.CheckGameOver() || CheckVictory())
            {
                this.Status = GameStatus.GameOver; 
            }
        }

        public void Start()
        {
            this.Status = GameStatus.Running;
            this.InitBubbles();
        }

        /// <summary>
        /// Initialize all IBubbles in the game
        /// </summary>
        private void InitBubbles()
        {
            for (int i = 0; i < NumRows; i++)
            {
                this.CreateNewRow();
            }
        }

        /// <summary>
        /// Creates new row of IBubbles
        /// </summary>
        private void CreateNewRow()
        {
            this.BubblesManager.AddBubbles(this.BubbleGridHelper.CreateNewRow(NumBubblePerRow));
        }

        public void LoadShootingBubble()
        {
            if (this.BubblesManager.ShootingBubble != null)
            {
                IBubble shootingBubble = this.BubblesManager.ShootingBubble;
                shootingBubble.Position = ShootingBubblePosition;
                shootingBubble.Direction = shootingBubble.Position;
                shootingBubble.Color = this.BubblesManager.ShootingBubble.Color;
            }
            else
            {
                this.BubblesManager.AddBubbles(new List<IBubble>(
                    this.BubbleFactory.CreateShootingBubble(ShootingBubblePosition, BubbleColor.RandomColor)));
            }
        }


        public void LoadSwitchBubble()
        {
            if (this.BubblesManager.SwitchBubble != null)
            {
                Random rand = new Random();
                IBubble switchBubble = this.BubblesManager.SwitchBubble;
                switchBubble.Position = SwitchBubblePosition;
                switchBubble.Color =
                    this.BubbleGridHelper.RemaingColors[rand.Next(this.BubbleGridHelper.RemaingColors.Count - 1)];
            }
            else
            {
                this.BubblesManager.AddBubbles(new List<IBubble>(
                    this.BubbleFactory.CreateSwitchBubble(SwitchBubblePosition, BubbleColor.RandomColor)));
            }
        }

        /// <summary>
        /// Check if it's game over.
        /// </summary>
        /// <returns>True if it's game over, false otherwise. </returns>
        private bool CheckGameOver()
        {
            return this.gameOverChecker.CheckGameOver(); 
        }

        /// <summary>
        /// Check if it's time to create new row.
        /// </summary>
        /// <param name="elapsed"> Time elapsed every gameLoop cycle. </param>
        /// <returns> True if it's time to create new row, false otherwise. </returns>
        protected abstract bool IsTimeToNewRow(double elapsed);
       
        /// <summary>
        /// Updates the score
        /// </summary>
        /// <param name="elapsed"> Time elapsed every gameLoop cycle. </param>
        protected abstract void UpdateScore(double elapsed);
        
        /// <summary>
        /// Check if the player has won.
        /// </summary>
        /// <returns> True if is victory. </returns>
        protected abstract bool CheckVictory();
    }
}