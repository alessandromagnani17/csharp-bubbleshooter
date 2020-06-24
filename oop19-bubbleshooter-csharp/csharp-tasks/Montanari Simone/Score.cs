using csharp_tasks.Accursi_Giacomo.Level;

namespace csharp_tasks.Montanari_Simone
{
    public class Score
    {

        private readonly int theScore { get; }
        private int x;
        private readonly LevelTypes level { get; }

        /// <summary>Constructor for a new score specifying the modality.</summary>
        /// <param name="startPoint">The start point.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="e">Class used to draw in the form.</param>
        public Score(readonly int score, readonly LevelType levelType)
        {
            this.theScore = score;
            this.level = levelType;
        }

    }
}