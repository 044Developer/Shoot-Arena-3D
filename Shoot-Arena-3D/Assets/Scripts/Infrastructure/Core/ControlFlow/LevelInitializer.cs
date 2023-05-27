using ShootArena.Infrastructure.Core.Level.Handlers.LevelStates;
using ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States.Implementation;
using Zenject;

namespace ShootArena.Infrastructure.Core.ControlFlow
{
    public class LevelInitializer : IInitializable
    {
        private readonly ILevelStatesHandler _levelStatesHandler = null;

        public LevelInitializer(
            ILevelStatesHandler levelStatesHandler)
        {
            _levelStatesHandler = levelStatesHandler;
        }
        
        public void Initialize()
        {
            _levelStatesHandler.ChangeLevelStateTo<PrepareLevelState>();
        }
    }
}