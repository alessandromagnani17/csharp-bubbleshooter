using System;
using System.Collections.Generic;
using csharp_tasks.Accursi_Giacomo;

namespace csharp_tasks.Acampora_Andrea
{
    public abstract class AbstractBubble : IBubble
    {
        private Point2D position;
        private Boolean isDestroyed;
        private BubbleType type;
        private List<IComponent> components;
        private Point2D direction;
        private double height;
        private double width;
        private double radius;

        public AbstractBubble(BubbleType type, Point2D position)
        {
            Type = type;
            Position = position;
        }
        
        public Point2D Position
        {
            get => position;
            set => position = value;
        }

        public List<IComponent> Components
        {
            get => components;
        }

        public bool Destroyed
        {
            get => isDestroyed;
            set => isDestroyed = value;
        }

        public Point2D Direction
        {
            get => direction;
            set => direction = value;
        }

        public BubbleType Type
        {
            get => type;
            set => type = value;
        }

        public double Height
        {
            get => height;
            set => height = value;
        }

        public double Width
        {
            get => width;
            set => width = value;
        }

        public void Update(double elapsed)
        {
        }
        
        public double Radius
        {
            get => radius;
            set => radius = value;
        }
    }
}