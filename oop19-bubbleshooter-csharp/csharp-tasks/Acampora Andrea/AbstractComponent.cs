using System.ComponentModel;

namespace csharp_tasks.Acampora_Andrea
{
    public class AbstractComponent : IComponent
    {
        public AbstractComponent(IBubble container)
        {
            this.Container = Container;
        }
        public IBubble Container { get; set; }
        
        public ComponentType Type { get; set; }

        public void Update(double elapsed)
        {
        }
        
    }
}