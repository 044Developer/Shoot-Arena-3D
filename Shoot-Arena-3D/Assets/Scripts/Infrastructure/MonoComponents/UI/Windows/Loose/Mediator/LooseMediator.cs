using ShootArena.Infrastructure.Core.Level.RuntimeData.LevelStats;
using ShootArena.Infrastructure.Modules.UIWindows;
using ShootArena.Infrastructure.Modules.UIWindows.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.RuntimeData;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.ViewModel;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.Mediator
{
    public class LooseMediator : ILooseMediator
    {
        private readonly ILevelLooseRuntimeData _runtimeData = null;
        private readonly IUIWindowsModule _windowsModule = null;
        private ILooseViewModel _viewModel = null;

        public LooseMediator(
            ILevelLooseRuntimeData runtimeData,
            IUIWindowsModule windowsModule
            )
        {
            _runtimeData = runtimeData;
            _windowsModule = windowsModule;
        }
        
        public void SetModel(IUIViewModel viewModel)
        {
            _viewModel = viewModel as ILooseViewModel;
        }

        public void SetWindowData()
        {
            SetTotalKills();
            
            SetTotalTime();
        }

        public void OnRestartButtonClicked()
        {
            _runtimeData.OnRestartButtonClickAction?.Invoke();
            
            CloseWindow();
        }

        public void OnExitButtonClicked()
        {
            _runtimeData.OnExitButtonClickAction?.Invoke();
            
            CloseWindow();
        }

        private void CloseWindow() => 
            _windowsModule.CloseWindow(UIWindowType.Loose);

        private void SetTotalKills()
        {
            _viewModel.TotalKillText.text = _runtimeData.TotalEnemiesKilledValue.ToString();
        }

        private void SetTotalTime()
        {
            _viewModel.TotalTimeText.text = _runtimeData.TotalTimeSpendValue.ToString();
        }
    }
}