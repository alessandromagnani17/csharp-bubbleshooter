namespace csharp_tasks.Montanari_Simone
{
    /// <summary>
    /// Class called by {@link ControllerImpl} used to get information about the score.
    /// The informations are taken by calling the {@link GameData}.
    /// </summary>
    class ScoreManager 
    {

        private readonly GameData scoresInfo;

        /// <summary>Constructor for a new ScoreManager.</summary>
        /// <param name="gameData">The {@link GameData}.</param>
        public ScoreManager(GameData gameData)
        {
            this.scoresInfo = gameData;
        }

        /// <summary>Private method used to get the score of the game.</summary>
        /// <returns>Return the score of the game.</returns>
        private int GetScore()
        {
            return this.scoreInfo.GetScore();
        }

        /// <summary>Private method used to get the destroyed balls of the game.</summary>
        /// <returns>Return the destroyed balls of the game.</returns>
        private int GetDestroyedBubbles()
        {
            return this.scoreInfo.GetDestroyedBubbles();
        }

        /// <summary>Private method used to get the game time.</summary>
        /// <returns>Return the game time.</returns>
        private double GetGameTime()
        {
            return this.scoreInfo.GetGameTime();
        }

    }
}