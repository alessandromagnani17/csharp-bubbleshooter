using csharp_tasks.Accursi_Giacomo.Level;


namespace csharp_tasks.Montanari_Simone
{
    /// <summary>
    /// Class which represent a basic score with score and his game modality.
    /// </summary>
    public class HighscoreStructure : Score
    {
        public string name { get; }

        public string Name { get; }

        /// <summary>Constructor for a new HighscoreStructure.</summary>
        /// <param name="name">The player name.</param>
        /// <param name="score">The score made by the player.</param>
        /// <param name="gameMode">The current game modality.</param>
        public HighscoreStructure(string playerName, int score, LevelType gameMode) : base(score, gameMode)
        {
            this.name = playerName;
        }

    }
}