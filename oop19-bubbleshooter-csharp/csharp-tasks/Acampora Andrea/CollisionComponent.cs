namespace csharp_tasks.Acampora_Andrea
{
    public class CollisionComponent : AbstractComponent
    {
        public CollisionComponent(IBubble container) : base(container)
        {
            base.Type = ComponentType.CollisionComponent;
        }
            
    }
}