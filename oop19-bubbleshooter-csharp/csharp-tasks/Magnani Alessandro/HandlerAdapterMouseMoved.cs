using csharp_tasks.Accursi_Giacomo;
using System;
using System.Drawing;
using csharp_tasks.Montanari_Simone;

namespace HandlerAdapterMouseMoved
{
    class Program
    {
        private readonly Rotate cannonRotation;
        private readonly Rotate lineRotation;
        private readonly DrawHelpLine drawHelpLine;
        private readonly Point2D shootingBubblePosition;
        private Point2D eventPosition;

        /**
        * Constructor for a new DrawCannon.
        * <param name="cannonRotation">the rotation of the cannon.</param>
        * <param name="lineRotation">the rotation of the help line.</param>
        * <param name="shootingBubblePosition">the shooting bubble position.</param>
        * <param name="drawHelpLine">the DrawHelpLine.</param>
        */
        public HandlerAdapterMouseMoved(Rotate cannonRotation, Rotate lineRotation,
                 Point2D shootingBubblePosition, DrawHelpLine drawHelpLine)
        {
            this.cannonRotation = cannonRotation;
            this.lineRotation = lineRotation;
            this.shootingBubblePosition = shootingBubblePosition;
            this.drawHelpLine = drawHelpLine;
        }

        public void Handle(MouseEvent @event)
        {
            this.eventPosition = new Point2D(@event.getX(), @event.getY());
            this.cannonRotation.SetAngle(PhysicHelper.CalculateAngle(eventPosition, shootingBubblePosition));
            this.lineRotation.SetAngle(PhysicHelper.CalculateAngle(eventPosition, shootingBubblePosition));
            this.checkBounds(eventPosition);
        }

        /**
         * @return the rotation of the cannon.
         */
        public double GetRotationAngle()
        {
            return this.cannonRotation.GetAngle();
        }

        /**
         * Private method used to calculate the direction of the bounds line and draw it by calling
         * the method drawBoundsLine of {@link DrawHelpLine}.
         * 
         * @param eventPosition position of the mouse.
         */
        private void CheckBounds(Point2D eventPosition)
        {
            double angularCoefficient;
            double intercepts;
            bool flag = false;
            Point2D startPointFirstLine = new Point2D(this.drawHelpLine.helpLine.GetStartX(),
                          this.drawHelpLine.helpLine.GetStartY());
            Point2D startPointSecondLine = null;
            Point2D endPointSecondLine = null;

            angularCoefficient = PhysicHelper.CalculateAngularCoefficient(startPointFirstLine, this.eventPosition);
            intercepts = PhysicHelper.CalculateIntercepts(startPointFirstLine, this.eventPosition);

            if (!this.drawHelpLine.helpLine.IsVisible() && this.drawHelpLine.helpSelected)) 
            {
                this.drawHelpLine.helpLine.SetVisible(true);
            }

            if (this.drawHelpLine.GetHelpBounds().Intersects(this.drawHelpLine.GetLeftBounds())
                    && this.drawHelpLine.helpSelected)
            {

                startPointSecondLine = new Point2D(0, intercepts);
                endPointSecondLine = new Point2D(Settings.GetGuiWidth(),
                        -angularCoefficient * Settings.GetGuiWidth() + intercepts);

                flag = PhysicHelper.AngleTooHigh(eventPosition, startPointFirstLine);

            }
            else if (this.drawHelpLine.GetHelpBounds().Intersects(this.drawHelpLine.GetRightBounds())
                  && this.drawHelpLine.helpSelected)
            {

                startPointSecondLine = new Point2D(Settings.GetGuiWidth(),
                        angularCoefficient * Settings.GetGuiWidth() + intercepts);
                endPointSecondLine = new Point2D(this.drawHelpLine.helpLine.GetStartX(),
                        startPointFirstLine.Y - (startPointFirstLine.Y - startPointSecondLine.Y) * 2);

                intercepts = PhysicHelper.CalculateIntercepts(startPointSecondLine, endPointSecondLine);

                endPointSecondLine = new Point2D(0, -angularCoefficient * 0 + intercepts);

                flag = PhysicHelper.AngleTooHigh(eventPosition, startPointFirstLine);

            }
            else
            {
                this.drawHelpLine.GetHelpBounds().SetVisible(false);
            }

            if (flag)
            {
                this.drawHelpLine.DrawLine();
                this.drawHelpLine.DrawBoundsLine(startPointSecondLine, endPointSecondLine);
            }
        }
    }
}