using System.Threading;

namespace csharp_tasks.Accursi_Giacomo.Level
{
    public class BasicLevel : AbstractLevel
    {
        private const int BubbleScore = 20;
        private const int WrongShootsBeforeNewRow = 5; 
        
        public BasicLevel()
        {
            this.LevelType = LevelType.BasicMode; 
        }

        protected override bool IsTimeToNewRow(double elapsed)
        {
            GameData gameData = this.GameData;
            if (gameData.GetWrongShoots() == WrongShootsBeforeNewRow)
            {
                gameData.ClearWrongShoots();
                return true; 
            }
            return false; 
        }

        protected override void UpdateScore(double elapsed)
        {
            GameData gameData = this.GameData;
            gameData.UpdateScore(gameData.GetDestroyedBubbles() * BubbleScore); 
        }

        protected override bool CheckVictory()
        {
            return this.BubblesManager.BubbleGrid.Count == 0; 
        }
    }
}