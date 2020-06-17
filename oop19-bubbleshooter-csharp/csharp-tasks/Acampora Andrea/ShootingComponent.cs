namespace csharp_tasks.Acampora_Andrea
{
    public class ShootingComponent : AbstractComponent
    {
        public ShootingComponent(IBubble container) : base(container)
        {
            base.Type = ComponentType.ShootingComponent;
        }
            
    }
}