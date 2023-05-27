using ShootArena.Infrastructure.Core.Level.RuntimeData;
using ShootArena.Infrastructure.Modules.UIWindows;
using ShootArena.Infrastructure.Modules.UIWindows.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.Implementation;

namespace ShootArena.Infrastructure.Core.Player.Handlers.PlayerDie.Implementation
{
    public class PlayerDieHandler : IPlayerDieHandler
    {
        private readonly IUIWindowsModule _windowsModule = null;
        private readonly LevelControlFlowRuntimeData _levelControlFlowRuntimeData = null;

        public PlayerDieHandler(
            IUIWindowsModule windowsModule,
            LevelControlFlowRuntimeData levelControlFlowRuntimeData
            )
        {
            _windowsModule = windowsModule;
            _levelControlFlowRuntimeData = levelControlFlowRuntimeData;
        }
        
        public void Die()
        {
            _levelControlFlowRuntimeData.OnLevelPauseStateAction?.Invoke();
            _windowsModule.ShowWindow<LooseWindow>(UIWindowType.Loose);
        }
    }
}