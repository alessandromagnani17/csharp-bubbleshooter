using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Magnani_Alessandro
{
    [TestClass]
    class TestGameOver
    {
        private static readonly double BUBBLE_POSITION_TRUE  = Model.WORLD_HEIGHT / 1.1;
        private static readonly double BUBBLE_POSITION_FALSE = 0;

        private readonly Level basicMode = new BasicLevel();
        private readonly Level survivalMode = new SurvivalLevel();

        /**
         * Method to test if {@link GameOverChecker} launch a GameOver
         * to the basic mode.
         */
        
        [TestMethod]
        public void TestBasicGameOver() {
            GameOverChecker gameOverChecker = new GameOverChecker(this.basicMode);
            Assert.IsTrue(gameOverChecker.IsGameOver(BUBBLE_POSITION_TRUE));
            Assert.IsFalse(gameOverChecker.IsGameOver(BUBBLE_POSITION_FALSE));
        }

        /**
         * Method to test if {@link GameOverChecker} launch a GameOver
         * to the survival mode.
         */
        
        [TestMethod]
        public void TestSurvivalGameOver() {
            GameOverChecker gameOverChecker = new GameOverChecker(this.survivalMode);
            Assert.IsTrue(gameOverChecker.IsGameOver(BUBBLE_POSITION_TRUE));
            Assert.IsFalse(gameOverChecker.IsGameOver(BUBBLE_POSITION_FALSE));
        }
    }
}