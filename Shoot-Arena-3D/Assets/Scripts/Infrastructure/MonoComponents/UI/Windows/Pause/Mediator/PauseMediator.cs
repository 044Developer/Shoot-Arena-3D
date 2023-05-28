using ShootArena.Infrastructure.Modules.UIWindows;
using ShootArena.Infrastructure.Modules.UIWindows.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Pause.RuntimeData;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Pause.ViewModel;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Pause.Mediator
{
    public class PauseMediator : IPauseMediator
    {
        private readonly ILevelPauseRuntimeData _levelPauseRuntimeData = null;
        private readonly IUIWindowsModule _windowsModule = null;

        private IPauseViewModel _viewModel = null;

        public PauseMediator(ILevelPauseRuntimeData levelPauseRuntimeData, IUIWindowsModule windowsModule)
        {
            _levelPauseRuntimeData = levelPauseRuntimeData;
            _windowsModule = windowsModule;
        }
        
        public void SetModel(IUIViewModel viewModel)
        {
            _viewModel = viewModel as IPauseViewModel;
        }

        public void OnResumeButtonClicked()
        {
            _levelPauseRuntimeData.OnResumeButtonClick?.Invoke();

            CloseWindow();
        }

        public void OnExitButtonClicked()
        {
            _levelPauseRuntimeData.OnExitButtonClick?.Invoke();

            CloseWindow();
        }

        private void CloseWindow()
        {
            _windowsModule.CloseWindow(UIWindowType.Pause);
        }
    }
}