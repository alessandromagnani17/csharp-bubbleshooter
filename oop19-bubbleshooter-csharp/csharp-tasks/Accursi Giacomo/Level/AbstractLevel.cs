using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using csharp_tasks.Acampora_Andrea;

namespace csharp_tasks.Accursi_Giacomo.Level
{
    public abstract class AbstractLevel : ILevel
    {
        private const int NumBubblePerRow = 19;
        private const int NumRows = 8; 
        


        private static readonly int MILLISECONDS_IN_A_SECOND = 1000; 
        private static readonly Point2D ShootingBubblePosition = new Point2D(WORLD_WIDTH / 2, WORLD_HEIGHT / 1.10); 
        private static readonly Point2d SwitchBubblePosition = new Point2D(WORLD_WIDTH / 2, WORLD_HEIGHT / 1.10);


        private BubblesManager bubblesManager { get;}
        private BubbleGridManager BubbleGridManager { get; }
        private  BubbleGridHelper BubbleGridHelper { get; }
        private  CollisionController CollisionController { get; }
        private  GameData GameData { get; }
        private  GameOverChecker GameOverChecker { get; }
        private  BubbleFactory BubbleFactory { get; }
        private GameStatus Status { get; set;}
        
        private LevelType CurrentGameType { get; set;}

        public AbstractLevel(BubblesManager bubblesManager, BubbleGridManager bubbleGridManager, BubbleGridHelper bubbleGridHelper, CollisionController collisionController, GameData gameData, GameOverChecker gameOverChecker, BubbleFactory bubbleFactory, GameStatus status)
        {
            this.bubblesManager = bubblesManager;
            this.BubbleGridManager = bubbleGridManager;
            this.BubbleGridHelper = bubbleGridHelper;
            this.CollisionController = collisionController;
            this.GameData = gameData;
            this.GameOverChecker = gameOverChecker;
            this.BubbleFactory = bubbleFactory;
            this.Status = status;
        }

        public void Start()
        {
            this.Status = new GameStatus().RUNNING;
            this.InitBubbles(); 
        }

        private void InitBubbles()
        {
            for (int i = 0; i < NumRows; i++)
            {
                this.CreateNewRow(); 
            }
        }

        private void CreateNewRow()
        {
            this.bubblesManager.AddBubbles(this.BubbleGridHelper.CreateNewRow(NumBubblePerRow)); 
        }

        public void Update(double elapsed)
        {
            this.bubblesManager.Update(elapsed);
            this.CollisionController.CheckCollision();
            this.GameData.UpdateGameTime(elapsed);
            this.UpdateScore(elapsed / MILLISECONDS_IN_A_SECOND);
            if (this.isTimeToNewRow(elapsed / MILLISECONDS_IN_A_SECOND))
            {
                this.CreateNewRow();
            }
        }

        public BubblesManager GetBubblesManager()
        {
            throw new System.NotImplementedException();
        }

        public void LoadShootingBubble()
        {
            if (this.bubblesManager.ShootingBubble is { })
            {
                IBubble shootingBubble = this.bubblesManager.ShootingBubble; 
                shootingBubble.Position = ShootingBubblePosition;
                shootingBubble.Direction = shootingBubble.Position;
                shootingBubble.Color = this.bubblesManager.ShootingBubble.Color;
            }
            else
            {
               this.bubblesManager.AddBubbles(new List<IBubble>(this.BubbleFactory.createShootingBubble(ShootingBubblePosition, BubbleColor.RandomColor))); 
            }
        }
        
        

        public void LoadSwitchBubble()
        {
            if (this.bubblesManager.SwitchBubble is { })
            {
                Random rand = new Random(); 
                IBubble switchBubble = this.bubblesManager.SwitchBubble;
                switchBubble.Position = SwitchBubblePosition;
                switchBubble.Color =
                    this.BubbleGridHelper.RemaingColors[rand.Next(this.BubbleGridHelper.RemaingColors.Count - 1)]; 
            }
            else
            {
                this.bubblesManager.AddBubbles(new List<IBubble>(this.BubbleFactory.createSwitchBubble(SwitchBubblePosition, BubbleColor.RandomColor))); 
            }
        }
        
    }
}