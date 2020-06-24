namespace csharp_tasks.Accursi_Giacomo.Level
{
    
    public interface ILevel
    {

        const int NumBubblesPerRow = 19; 
        const int NumRows = 8; 
        
        void Start();

        void Update(double elapsed);

        void LoadShootingBubble();

        void LoadSwitchBubble();

        BubbleGridHelper BubbleGridHelper { get; }
        BubbleFactory BubbleFactory { get; }

        BubblesManager BubblesManager { get; }

        BubbleGridManager BubbleGridManager { get; }

        CollisionController CollisionController { get; }

        GameData GameData { get; }

        GameStatus Status { get; set; }

        LevelType LevelType { get; set; }
    }
}