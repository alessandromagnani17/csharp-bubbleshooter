using System;

namespace csharp_tasks.Acampora_Andrea
{
    public interface IBubble
    {
        void Update(double elapsed);

        IComponent Component { get; set; }
        
        bool IsDestroyed();

        void SetPosition();
        
        void SetDirection();

        void SetType(BubbleType type);

        void Destroy();

        void AddComponent(IComponent component);

        double GetRadius();

        double GetWidth();

        double GetHeight();

        BubbleType GetType();
    }
}