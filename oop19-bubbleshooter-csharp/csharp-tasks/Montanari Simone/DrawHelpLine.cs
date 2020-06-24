namespace csharp_tasks.Montanari_Simone
{
    /// <summary>
    /// Class used for draw the help line if the 'help' CheckBox in {@link GameController} is selected. </summary>
    public class DrawHelpLine 
    {

        private readonly Graphics g;
        private readonly Point startPointFirstLine;
        private HelpLine helpLine { get; }
        private HelpLine boundsLine { get; }
        private readonly Pen borderRight;
        private readonly Pen borderLeft;
        private Rotate rotation { get; }
        private bool helpSelected { get; }

         /// <summary>Constructor for a new DrawHelpLine. </summary>
         /// <param name="graphics">Class used to draw the {@link HelpLine} in the form.</param>
         /// <param name="shootingBubblePosition">The position of {@link ShootingBubble}.</param>
        public DrawHelpLine(Graphics graphics, Point shootingBubblePosition)
        {
            this.startPointFirstLine = shootingBubblePosition;
            this.g = graphics;
            this.rotation = new Rotate();

            this.helpLine = new HelpLine(this.startPointFirstLine, new Point(this.startPointFirstLine.X, 0), this.g);
            this.boundsLine = new HelpLine(new Point(0, 0), new Point(0, 0), this.g);
            this.borderRight = new Pen();
            this.borderLeft = new Pen();

            this.SetRotation();

            this.g.DrawLine(this.borderRight, Settings.GetGuiWidth(), 0, Settings.GetGuiWidth(), Settings.GetGuiHeight());
            this.g.DrawLine(this.borderLeft, 0, 0, 0, Settings.GetGuiHeight());
            this.g.Clear();
        }

        /// <summary>Private method used for set the rotation of help line.</summary>
        public void SetRotation()
        {
            /// It's not necessary to add the rotation to the object for rotate that.
        }

        /// <summary>Method used for delete the help line.</summary>
        public void DeleteLine()
        {
            this.helpSelected = false;
            this.g.Clear();
            /// Now it necessary to re-draw all the items execpt helpline and boundsline.
        }

        /// <summary>Method used for draw the help line.</summary>
        public void DrawLine()
        {
            this.helpSelected = true;
            this.g.DrawLine(this.borderRight, Settings.GetGuiWidth(), 0, Settings.GetGuiWidth(), Settings.GetGuiHeight());
            this.g.DrawLine(this.borderLeft, 0, 0, 0, Settings.GetGuiHeight());
        }

        /// <summary>Method called by {@link HandlerAdapterMouseMoved} for draw the bounds line
        /// passing start point and end point. </summary>
        /// <param name="startPointSecondLine">The start point.</param>
        /// <param name="endPointSecondLine">The end point.</param>
        public void DrawBoundsLine(Point startPointSecondLine, Point endPointSecondLine) {
            this.g.DrawLine(this.boundsLine, startPointSecondLine.X, startPointSecondLine.Y,
                                      endPointSecondLine.X, endPointSecondLine.Y);
        }

        /// <summary>Method used to get the bounds of help line.</summary>
        /// <returns>Return the bounds of help line.</returns>
        public readonly Bounds GetHelpBounds()
        {
            return this.helpLine.line.GetBounds();
        }

        /// <summary>Method used to get the bounds of border right line.</summary>
        /// <returns>Return the bounds of border right line.</returns>
        public Bounds GetRightBounds()
        {
            return this.borderRight.GetBounds();
        }

        /// <summary>Method used to get the bounds of border left line.</summary>
        /// <returns>Return the bounds of border left line.</returns>
        public Bounds GetLeftBounds()
        {
            return this.borderLeft.GetBounds();
        }

    }
}