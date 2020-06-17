namespace csharp_tasks.Acampora_Andrea
{
    public interface IComponent
    {
        void Update(double elapsed);
        
        IBubble Container { get; set; }
            
        ComponentType Type { get; set; }

    }
}