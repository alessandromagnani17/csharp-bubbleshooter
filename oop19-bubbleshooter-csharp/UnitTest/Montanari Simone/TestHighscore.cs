
using System;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using csharp_tasks.Montanari_Simone;
using csharp_tasks.Accursi_Giacomo.Level;
using System.Collections.ObjectModel;
using System.Linq;
using csharp_tasks.Accursi_Giacomo.Level;
using csharp_tasks.Montanari_Simone;
using NUnit.Framework;

namespace UnitTest.Montanari_Simone
{
    /// <summary>Class used to test the {@link HighscoreStoreImpl} of the Game.</summary>
    [TestClass]
    public class TestHighscore
    {

        private readonly IHighscoreStore highscoreStore = new HighscoreStoreImpl();
        private static readonly int POINTS = 500;
        private static readonly int LIMIT = 10;
        private static readonly String PLAYER = "Player";
        private ObservableCollection<HighscoreStructure> rightList;
        private ObservableCollection<HighscoreStructure> scoreList;

        private static readonly string PLAYER = "Player";
        private readonly ObservableCollection<HighscoreStructure> rightList = new ObservableCollection<HighscoreStructure>();
        private readonly ObservableCollection<HighscoreStructure> scoreList = new ObservableCollection<HighscoreStructure>();

        /// <summary>Method to test if a {@link HighscoreStore} add a new {@link HighscoreStructure}
        /// to the basic mode highscores. </summary>
        [TestMethod]
        public void TestAddABasicModeScore()
        {
            this.highscoreStore.CleanFile();
            this.rightList = new ObservableCollection<HighscoreStructure>();
            this.scoreList = new ObservableCollection<HighscoreStructure>();

            this.highscoreStore.AddScore(new HighscoreStructure(PLAYER, POINTS, LevelType.BasicMode));
            this.highscoreStore.GetHighscoresForModality(LevelType.BasicMode).ToList().ForEach(this.scoreList.Add);

            this.rightList.Add(new HighscoreStructure(PLAYER, POINTS, LevelType.BasicMode));

            Assert.IsTrue(this.rightList[0].Name.Equals(this.scoreList[0].Name),
                            "Error in name comparison!");
            Assert.AreEqual(this.rightList[0].theScore, this.scoreList[0].theScore,
                            "Error in score comparison!");
        }

        /// <summary>Method to test if a {@link HighscoreStore} add a new {@link HighscoreStructure}
        /// to the survival mode highscores. </summary>
        [TestMethod]
        public void TestAddASurvivalModeScore()
        {
            this.highscoreStore.CleanFile();
            this.rightList = new ObservableCollection<HighscoreStructure>();
            this.scoreList = new ObservableCollection<HighscoreStructure>();

            this.highscoreStore.AddScore(new HighscoreStructure(PLAYER, POINTS, LevelType.SurvivalMode));
            this.highscoreStore.GetHighscoresForModality(LevelType.SurvivalMode).ToList().ForEach(this.scoreList.Add);

            this.rightList.Add(new HighscoreStructure(PLAYER, POINTS, LevelType.SurvivalMode));

            Assert.IsTrue(this.rightList[0].Name.Equals(this.scoreList[0].Name),
                "Error in name comparison!");
            Assert.AreEqual(this.rightList[0].theScore, this.scoreList[0].theScore,
                "Error in score comparison!");
        }

        /// <summary>Method to test if a {@link HighscoreStore} add some new {@link HighscoreStructure}
        /// to the basic mode highscores in the correct order. </summary>
        [TestMethod]
        public void TestOrderBasicModeScore()
        {
            this.highscoreStore.CleanFile();
            this.rightList = new ObservableCollection<HighscoreStructure>();
            this.scoreList = new ObservableCollection<HighscoreStructure>();

            this.highscoreStore.AddScore(new HighscoreStructure(PLAYER, POINTS * 2, LevelType.BasicMode));
            this.highscoreStore.AddScore(new HighscoreStructure(PLAYER + 1, POINTS, LevelType.BasicMode));
            this.highscoreStore.AddScore(new HighscoreStructure(PLAYER + 2, POINTS * 3, LevelType.BasicMode));

            this.highscoreStore.GetHighscoresForModality(LevelType.BasicMode).ToList().ForEach(this.scoreList.Add);

            rightList.Add(new HighscoreStructure(PLAYER + 2, POINTS * 3, LevelType.BasicMode));
            rightList.Add(new HighscoreStructure(PLAYER, POINTS * 2, LevelType.BasicMode));
            rightList.Add(new HighscoreStructure(PLAYER + 1, POINTS, LevelType.BasicMode));


            for (int i = 0; i < this.rightList.Count; i += 1)
            {
                Assert.IsTrue(this.rightList[i].Name.Equals(this.scoreList[i].Name),
                                  "Error in name comparison!");
                Assert.AreEqual(this.rightList[i].theScore, this.scoreList[i].theScore,
                                  "Error in score comparison!");
            }
        }

        /// <summary>Method to test if a {@link HighscoreStore} add some new {@link HighscoreStructure}
        /// to the survival mode highscores in the correct order. </summary>
        [TestMethod]
        public void TestOrderSurvivalModeScore()
        {
            this.highscoreStore.CleanFile();
            this.rightList = new ObservableCollection<HighscoreStructure>();
            this.scoreList = new ObservableCollection<HighscoreStructure>();

            this.highscoreStore.AddScore(new HighscoreStructure(PLAYER, POINTS * 2, LevelType.SurvivalMode));
            this.highscoreStore.AddScore(new HighscoreStructure(PLAYER + 1, POINTS, LevelType.SurvivalMode));
            this.highscoreStore.AddScore(new HighscoreStructure(PLAYER + 2, POINTS * 3, LevelType.SurvivalMode));

            this.highscoreStore.GetHighscoresForModality(LevelType.SurvivalMode).ToList().ForEach(this.scoreList.Add);

            rightList.Add(new HighscoreStructure(PLAYER + 2, POINTS * 3, LevelType.SurvivalMode));
            rightList.Add(new HighscoreStructure(PLAYER, POINTS * 2, LevelType.SurvivalMode));
            rightList.Add(new HighscoreStructure(PLAYER + 1, POINTS, LevelType.SurvivalMode));


            for (int i = 0; i < this.rightList.Count; i += 1)
            {
                Assert.IsTrue(this.rightList[i].Name.Equals(this.scoreList[i].Name),
                    "Error in name comparison!");
                Assert.AreEqual(this.rightList[i].theScore, this.scoreList[i].theScore,
                    "Error in score comparison!");
            }
        }

        /// <summary>Method to test if a {@link HighscoreStore} remove {@link HighscoreStructure}
        /// from the basic mode list if there are over than 10 items. </summary>
        [TestMethod]
        public void TestLimitForBasicModeScore()
        {
            this.highscoreStore.CleanFile();
            this.rightList = new ObservableCollection<HighscoreStructure>();
            this.scoreList = new ObservableCollection<HighscoreStructure>();

            for (int i = 0; i < LIMIT * 2; i += 1)
            {
                this.highscoreStore.AddScore(new HighscoreStructure(PLAYER + i, POINTS + i, LevelType.BasicMode));
            }

            this.highscoreStore.GetHighscoresForModality(LevelType.BasicMode).ToList().ForEach(this.scoreList.Add);

            for (int j = 0; j < LIMIT; j += 1)
            {
                this.rightList.Add(new HighscoreStructure(PLAYER + j, POINTS + j, LevelType.BasicMode));
            }

            Assert.IsFalse(this.scoreList.Count > LIMIT,
                              "There are too much items in the list!");
            Assert.AreEqual(this.rightList.Count, this.scoreList.Count,
                              "Error in size list comparison!");
        }

        /// <summary>Method to test if a {@link HighscoreStore} remove {@link HighscoreStructure}
        /// from the survival mode list if there are over than 10 items. </summary>
        [TestMethod]
        public void TestLimitForSurvivalModeScore()
        {
            this.highscoreStore.CleanFile();
            this.rightList = new ObservableCollection<HighscoreStructure>();
            this.scoreList = new ObservableCollection<HighscoreStructure>();

            for (int i = 0; i < LIMIT * 2; i += 1)
            {
                this.highscoreStore.AddScore(new HighscoreStructure(PLAYER + i, POINTS + i, LevelType.SurvivalMode));
            }

            this.highscoreStore.GetHighscoresForModality(LevelType.SurvivalMode).ToList().ForEach(this.scoreList.Add);

            for (int j = 0; j < LIMIT; j += 1)
            {
                this.rightList.Add(new HighscoreStructure(PLAYER + j, POINTS + j, LevelType.SurvivalMode));
            }

            Assert.IsFalse(this.scoreList.Count > LIMIT,
                "There are too much items in the list!");
            Assert.AreEqual(this.rightList.Count, this.scoreList.Count,
                "Error in size list comparison!");
        }

    }
}