using ShootArena.Infrastructure.Core.Level.Handlers.LevelStates;
using ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States.Implementation;
using ShootArena.Infrastructure.Modules.UIWindows;
using ShootArena.Infrastructure.Modules.UIWindows.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.Implementation;

namespace ShootArena.Infrastructure.Core.Player.Handlers.PlayerDie.Implementation
{
    public class PlayerDieHandler : IPlayerDieHandler
    {
        private readonly ILevelStatesHandler _levelStatesHandler;
        private readonly IUIWindowsModule _windowsModule = null;

        public PlayerDieHandler(
            ILevelStatesHandler levelStatesHandler,
            IUIWindowsModule windowsModule
            )
        {
            _levelStatesHandler = levelStatesHandler;
            _windowsModule = windowsModule;

        }
        
        public void Die()
        {
            _levelStatesHandler.ChangeLevelStateTo<LevelPauseState>();
            
            _windowsModule.ShowWindow<LooseWindow>(UIWindowType.Loose);
        }
    }
}