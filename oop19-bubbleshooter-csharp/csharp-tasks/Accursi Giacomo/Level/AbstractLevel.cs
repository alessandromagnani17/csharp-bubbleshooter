using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace csharp_tasks.Accursi_Giacomo.Level
{
    public abstract class AbstractLevel : ILevel
    {
        private const int NumBubblePerRow = 19;
        private const int NumRows = 8; 
        


        private static readonly int MILLISECONDS_IN_A_SECOND = 1000; 
        private static readonly Point2D ShootingBubblePosition = new Point2D(WORLD_WIDTH / 2, WORLD_HEIGHT / 1.10); 
        private static readonly Point2d SwitchBubblePosition = new Point2D(WORLD_WIDTH / 2, WORLD_HEIGHT / 1.10);
        
        
        private readonly BubblesManager bubblesManager;
        private readonly BubbleGridManager bubbleGridManager;
        private readonly BubbleGridHelper bubbleGridHelper;
        private readonly CollisionController collisionController;
        private readonly GameData gameData;
        private readonly GameOverChecker gameOverChecker;
        private readonly BubbleFactory bubbleFactory;
        private GameStatus status;
        private LevelType currentGameType;

        public BasicLevel(BubblesManager bubblesManager, BubbleGridManager bubbleGridManager, BubbleGridHelper bubbleGridHelper, CollisionController collisionController, GameData gameData, GameOverChecker gameOverChecker, BubbleFactory bubbleFactory, GameStatus status)
        {
            this.bubblesManager = bubblesManager;
            this.bubbleGridManager = bubbleGridManager;
            this.bubbleGridHelper = bubbleGridHelper;
            this.collisionController = collisionController;
            this.gameData = gameData;
            this.gameOverChecker = gameOverChecker;
            this.bubbleFactory = bubbleFactory;
            this.status = status;
        }

        public void Start()
        {
            this.status = new GameStatus().RUNNING;
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
            this.bubblesManager.AddBubbles(this.bubbleGridHelper.CreateNewRow(NumBubblePerRow)); 
        }

        public void Update(double elapsed)
        {
            this.bubblesManager.Update(elapsed);
            this.collisionController.CheckCollision();
            this.gameData.UpdateGameTime(elapsed);
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
            if (this.bubblesManager.SwitchBubble)
        }

        public void LoadSwitchBubble()
        {
            throw new System.NotImplementedException();
        }

        public void SetLevelType(LevelType levelType)
        {
            throw new System.NotImplementedException();
        }

        public void SetGameStatus(GameStatus status)
        {
            throw new System.NotImplementedException();
        }

        public BubbleGridManager GetGridManager()
        {
            throw new System.NotImplementedException();
        }

        public BubbleGridHelper GetGridHelper()
        {
            throw new System.NotImplementedException();
        }

        public CollisionController GetCollisionController()
        {
            throw new System.NotImplementedException();
        }

        public GameData GetGameData()
        {
            throw new System.NotImplementedException();
        }

        public LevelType GetLevelType()
        {
            throw new System.NotImplementedException();
        }

        public BubbleFactory GetBubbleFactory()
        {
            throw new System.NotImplementedException();
        }
    }
}