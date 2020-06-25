namespace csharp_tasks.Accursi_Giacomo
{
    /// <summary>
    /// Represents a class that collects game information.
    /// </summary>
    public class GameData
    {
        public GameData()
        {
            WrongShoots = 0;
            DestroyedBubbles = 0;
            Score = 0;
            GameTime = 0; 
        }

        /// <summary>
        /// Getter and Setter for the score
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Getter and private Setter for DestroyedBubbles.
        /// </summary>
        public int DestroyedBubbles { get; private set; }

        /// <summary>
        /// Add one DestroyedBubbles
        /// </summary>
        public void AddDestroyedBubbles()
        {
            DestroyedBubbles += 1; 
        }
       
        /// <summary>
        /// Getter and Setter for GameTime
        /// </summary>
        public double GameTime
        {
            get => GameTime;
            set => GameTime += value;
        }

        /// <summary>
        /// Getter and private Setter for WrongShoots.
        /// </summary>
        public int WrongShoots { get; private set; }

        /// <summary>
        /// Resets WrongShoot counter.
        /// </summary>
        public void ClearWrongShoots()
        {
            WrongShoots = 0;
        }

        /// <summary>
        /// Adds one WrongShoot
        /// </summary>
        public void AddWrongShoots()
        {
            WrongShoots += 1; 
        }
    }
}