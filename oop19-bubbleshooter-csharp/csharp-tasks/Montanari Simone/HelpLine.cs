using csharp_tasks.Accursi_Giacomo;
using System.Drawing;

namespace csharp_tasks.Montanari_Simone
{
    /// <summary>Class used to create a line using the start and end point given.</summary>
    public class HelpLine 
    {

        private static readonly double DASH_WIDTH = Settings.GetGuiHeight() / 200;
        private readonly Graphics g;
        public Pen line { get; }
        
        /// <summary>Constructor for a new Line passing the start and end point.</summary>
        /// <param name="startPoint">The start point.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="e">Class used to draw in the form.</param>
        public HelpLine(Point2D startPoint, Point2D endPoint, PaintEventArgs e)
        {
            this.line = new Pen(Color.RED);
            this.g = e.Graphics;

            this.EditLine();

            this.g.DrawLine(this.line, startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);

            this.SetInvisible();

        }

        /// <summary>Private method used to edit the line created.</summary>
        private void EditLine()
        {
            this.line.Width = DASH_WIDTH;
            this.line.DashStyle = DashStyle.Dash;
            /// Not set the dash size because it depends on the line’s width.
        }

        /// <summary>Private method used to make invisible the line created.</summary>
        private void SetInvisible()
        {
            this.g.Clear();
            /// Now it necessary to re-draw all the items execpt the line.
        }

    }
}