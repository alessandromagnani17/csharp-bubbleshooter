using csharp_tasks.Accursi_Giacomo.Level;
using System.IO;
using System.Collections.ObjectModel;


namespace csharp_tasks.Montanari_Simone
{
    /// <summary>
    /// Interface of the {@link HighscoreStore] of the game. It's used to read, save
    /// and modify the scores from a file.
    /// </summary>
    public interface IHighscoreStore
    {
        /// <summary>Method for get the file where scores are saved.</summary>
        /// <returns>the file where the scores are saved.</returns>
        File GetFile();

        /// <summary>Method for add a score for a game modality.</summary>
        /// <param name="score">The current {@link HighscoreStructure} to save.</param>
        void AddScore(HighscoreStructure score);

        /// <summary>Method to have a list of scores for a specific game modality.</summary>
        /// <param name="gameMode">The game modality which we want the scores.</param>
        /// <returns>the scores for a game modality.</returns>
        ObservableCollection<HighscoreStructure> GetHighscoresForModality(LevelType gameMode);

        /// <summary>Method used for clean file.</summary>
        void CleanFile();
    }
}