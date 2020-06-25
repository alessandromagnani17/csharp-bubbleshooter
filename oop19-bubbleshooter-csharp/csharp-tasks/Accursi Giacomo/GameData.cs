namespace csharp_tasks.Accursi_Giacomo
{
    public class GameData
    {
        public GameData()
        {
            WrongShoots = 0;
            DestroyedBubbles = 0;
            Score = 0;
            GameTime = 0; 
        }

        public int Score { get; set; }

        public int DestroyedBubbles { get; private set; }

        public void AddDestroyedBubbles()
        {
            DestroyedBubbles += 1; 
        }
        public double GameTime
        {
            get { return GameTime; }
            set => GameTime += value;
        }

        public int WrongShoots { get; private set; }

        public void ClearWrongShoots()
        {
            WrongShoots = 0;
        }

        public void AddWrongShoots()
        {
            WrongShoots += 1; 
        }
    }
}