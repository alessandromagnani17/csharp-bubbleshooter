using csharp_tasks.Accursi_Giacomo;
using System;
using System.Drawing;

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
        public readonly double GetRotationAngle() 
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
            Point2D startPointFirstLine = new Point2D(this.drawHelpLine.GetHelpLine().GetStartX(), 
                          this.drawHelpLine.GetHelpLine().GetStartY());
            Point2D startPointSecondLine = null;
            Point2D endPointSecondLine = null;

            angularCoefficient = PhysicHelper.CalculateAngularCoefficient(startPointFirstLine, this.eventPosition);
            intercepts = PhysicHelper.CalculateIntercepts(startPointFirstLine, this.eventPosition);

            if (!this.drawHelpLine.GetHelpLine().IsVisible() && this.drawHelpLine.IsHelpSelected()) {
                this.drawHelpLine.GetHelpLine().SetVisible(true);
            }

            if (this.drawHelpLine.GetHelpBounds().Intersects(this.drawHelpLine.GetLeftBounds()) 
                    && this.drawHelpLine.isHelpSelected()) {

                startPointSecondLine = new Point2D(0, intercepts);
                endPointSecondLine = new Point2D(Settings.GetGuiWidth(),
                        -angularCoefficient * Settings.GetGuiWidth() + intercepts);

                flag = PhysicHelper.AngleTooHigh(eventPosition, startPointFirstLine);

            } else if (this.drawHelpLine.GetHelpBounds().Intersects(this.drawHelpLine.GetRightBounds()) 
                    && this.drawHelpLine.IsHelpSelected()) {

                startPointSecondLine = new Point2D(Settings.GetGuiWidth(),
                        angularCoefficient * Settings.GetGuiWidth() + intercepts);
                endPointSecondLine = new Point2D(this.drawHelpLine.GetHelpLine().GetStartX(), 
                        startPointFirstLine.getY() - (startPointFirstLine.GetY() - startPointSecondLine.GetY()) * 2);

                intercepts = PhysicHelper.CalculateIntercepts(startPointSecondLine, endPointSecondLine);

                endPointSecondLine = new Point2D(0, -angularCoefficient * 0 + intercepts);

                flag = PhysicHelper.AngleTooHigh(eventPosition, startPointFirstLine);

            } else {
                this.drawHelpLine.GetBoundsLine().SetVisible(false);
            }

            if (flag) {
                this.drawHelpLine.DrawLine();
                this.drawHelpLine.DrawBoundsLine(startPointSecondLine, endPointSecondLine);
            } 
        }
    }
}