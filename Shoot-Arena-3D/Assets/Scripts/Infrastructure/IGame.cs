namespace ShootArena.Infrastructure
{
    public interface IGame
    {
        public void StartApplication();
        public void PauseApplication();
        public void ResumeApplication();
        public void QuitApplication();
    }
}