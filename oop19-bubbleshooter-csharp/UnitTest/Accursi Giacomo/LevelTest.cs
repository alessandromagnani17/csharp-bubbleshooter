using System;
using csharp_tasks.Accursi_Giacomo;
using csharp_tasks.Accursi_Giacomo.Level;
using NUnit.Framework;


namespace UnitTest.Accursi_Giacomo
{
    /// <summary>
    /// Class to test the correct behaviour of the ILevel.
    /// </summary>
    [TestFixture]
    public class LevelTest
    {
        private const double Elapsed = 1;  

        [Test]
        public void TestStartBasicLevel()
        {
            ILevel level = new BasicLevel();
            Assert.Equals(level.Status, GameStatus.Pause); 
            level.Start();
            level.Update(Elapsed);
            Assert.Equals(level.Status, GameStatus.Running); 
        }

        [Test]
        public void LestLoadShootingBubble()
        {
            ILevel level = new BasicLevel();
            Assert.True(level.BubblesManager.ShootingBubble == null);
            level.Start();
            level.Update(Elapsed);
            Assert.False(level.BubblesManager.ShootingBubble == null);
        }

        [Test]
        public void TestNewRowBasicLevel()
        {
            ILevel level = new BasicLevel();
            level.Start();
            Assert.Equals(level.BubbleGridManager.CreatedRows, ILevel.NumRows); 
            level.GameData.AddWrongShoots();
            level.GameData.AddWrongShoots();
            level.GameData.AddWrongShoots();
            level.GameData.AddWrongShoots();
            level.GameData.AddWrongShoots();
            level.Update(Elapsed);
            Assert.AreNotEqual(level.BubbleGridManager.CreatedRows, ILevel.NumRows);
        }
    }
}