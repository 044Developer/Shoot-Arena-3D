using ShootArena.Infrastructure.Core.Level.RuntimeData.ControlFlow;
using ShootArena.Infrastructure.Core.Level.RuntimeData.LevelStats;
using ShootArena.Infrastructure.Core.Level.RuntimeData.LevelTimings;
using ShootArena.Infrastructure.Modules.UIWindows;
using ShootArena.Infrastructure.Modules.UIWindows.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.Implementation;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.RuntimeData;

namespace ShootArena.Infrastructure.Core.Player.Handlers.PlayerDie.Implementation
{
    public class PlayerDieHandler : IPlayerDieHandler
    {
        private readonly IUIWindowsModule _windowsModule = null;
        private readonly ILevelControlFlowRuntimeData _levelControlFlowRuntimeData = null;
        private readonly ILevelTimingRuntimeData _levelTimingRuntimeData = null;
        private readonly ILevelStatsRuntimeData _levelStatsRuntimeData = null;
        private readonly LevelLooseRuntimeData _looseRuntimeData = null;

        public PlayerDieHandler(
            IUIWindowsModule windowsModule,
            ILevelControlFlowRuntimeData levelControlFlowRuntimeData,
            ILevelLooseRuntimeData looseRuntimeData,
            ILevelTimingRuntimeData levelTimingRuntimeData,
            ILevelStatsRuntimeData levelStatsRuntimeData
            )
        {
            _windowsModule = windowsModule;
            _levelControlFlowRuntimeData = levelControlFlowRuntimeData;
            _levelTimingRuntimeData = levelTimingRuntimeData;
            _levelStatsRuntimeData = levelStatsRuntimeData;
            _looseRuntimeData = looseRuntimeData as LevelLooseRuntimeData;
        }
        
        public void Die()
        {
            _levelControlFlowRuntimeData.OnLevelPauseStateAction?.Invoke();

            SetUpLooseWindow();
            
            _windowsModule.ShowWindow<LooseWindow>(UIWindowType.Loose);
        }

        private void SetUpLooseWindow()
        {
            _looseRuntimeData.TotalEnemiesKilledValue = _levelStatsRuntimeData.TotalEnemiesCount;
            _looseRuntimeData.TotalTimeSpendValue = _levelTimingRuntimeData.CurrenLevelTime;
            _looseRuntimeData.OnRestartButtonClickAction = OnRestartButtonClick;
            _looseRuntimeData.OnExitButtonClickAction = OnExitButtonClick;
        }

        private void OnRestartButtonClick() => 
            _levelControlFlowRuntimeData.OnLevelRestartStateAction?.Invoke();

        private void OnExitButtonClick() => 
            _levelControlFlowRuntimeData.OnLevelExitStateAction?.Invoke();
    }
}