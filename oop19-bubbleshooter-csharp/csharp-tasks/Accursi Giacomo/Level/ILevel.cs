namespace csharp_tasks.Accursi_Giacomo.Level
{
    public interface ILevel
    {
        void Start();

        void Update(double elapsed);

        void LoadShootingBubble();

        void LoadSwitchBubble();
        
        BubbleFactory BubbleFactory { get;}
        
        BubblesManager BubblesManager { get; }
        
        
        
    }
}