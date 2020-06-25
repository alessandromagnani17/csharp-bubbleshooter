using System;
using System.Collections.Generic;
using csharp_tasks.Accursi_Giacomo;

namespace csharp_tasks.Acampora_Andrea
{
    public interface IBubble
    {
        void Update(double elapsed);
        
        List<IComponent>Components { get;}
        
        Boolean Destroyed { get; set; }

        Point2D Position { get; set; }
        
        Point2D Direction { get; set; }

        BubbleType Type { get; set; }
        
        double Radius { get; set; }

        double Width { get; set; }

        double Height { get; set; }
    }
}