using csharp_tasks.Accursi_Giacomo.Level;

namespace csharp_tasks.Montanari_Simone
{
    /// <summary>
    /// Class which represent a basic score with score and his game modality.
    /// </summary>
    public class Score
    {

        private int theScore { get; }
        private LevelTypes level { get; }

        /// <summary>Constructor for a new score specifying the modality.</summary>
        /// <param name="startPoint">The start point.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="e">Class used to draw in the form.</param>
        public Score(int score, LevelType levelType)
        {
            this.theScore = score;
            this.level = levelType;
        }

    }
}