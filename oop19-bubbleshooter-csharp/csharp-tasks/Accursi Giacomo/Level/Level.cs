namespace csharp_tasks.Accursi_Giacomo.Level
{
    public interface ILevel
    {
        void Start();

        void Update();

        BubblesManager GetBubblesManager();

        void LoadShootingBubble();

        void LoadSwitchBubble();

        void SetLevelType(LevelType levelType);

        void SetGameStatus(GameStatus status);

        BubbleGridManager GetGridManager();

        BubbleGridHelper GetGridHelper();
        
        CollisionController GetCollisionController();
        
        GameData GetGameData();
        
        LevelType GetLevelType();    
    
        BubbleFactory GetBubbleFactory();
    }
}