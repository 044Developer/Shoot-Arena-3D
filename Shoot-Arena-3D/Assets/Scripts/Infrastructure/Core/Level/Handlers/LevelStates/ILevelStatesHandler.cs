using ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States;

namespace ShootArena.Infrastructure.Core.Level.Handlers.LevelStates
{
    public interface ILevelStatesHandler
    {
        void ChangeLevelStateTo<TState>() where TState : class, ILevelState;
    }
}