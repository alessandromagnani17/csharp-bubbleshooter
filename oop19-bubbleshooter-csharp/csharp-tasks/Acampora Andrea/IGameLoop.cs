using System;

namespace csharp_tasks.Acampora_Andrea
{
    public interface IGameLoop
    {
        void StartLoop();

        void StopLoop();

        void PauseLoop();

        void ResumeLoop();

        Boolean IsPaused();

        Boolean IsStopped();
    }
}