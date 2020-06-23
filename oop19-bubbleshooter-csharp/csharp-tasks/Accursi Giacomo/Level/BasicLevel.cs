using System.Xml.Schema;

namespace csharp_tasks.Accursi_Giacomo.Level
{
    public class BasicLevel : AbstractLevelModel
    {
        private static readonly int MILLISECONDS_IN_A_SECOND = 1000; 
        private static readonly Point2D SHOOTING_BUBBLE_POSITION = new Point2D(WORLD_WIDTH / 2, WORLD_HEIGHT / 1.10); 
        private static readonly Point2d SWITCH_BUBBLE_POSITION = new Point2D(WORLD_WIDTH / 2, WORLD_HEIGHT / 1.10);
        
        
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
    }
}