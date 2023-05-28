using ShootArena.Infrastructure.Modules.UIWindows;
using ShootArena.Infrastructure.Modules.UIWindows.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.RuntimeData;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.ViewModel;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.Mediator
{
    public class LooseMediator : ILooseMediator
    {
        private const float PARSED_TIME_VALUE = 60f;
        private const string SECONDS_STRING = "seconds";
        private const string MINUTES_STRING = "minutes";
        
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
            _viewModel.TotalTimeText.text = GetParsedLevelTime();
        }

        private string GetParsedLevelTime()
        {
            int minutes = Mathf.FloorToInt(_runtimeData.TotalTimeSpendValue / PARSED_TIME_VALUE);
            int seconds = Mathf.FloorToInt(_runtimeData.TotalTimeSpendValue % PARSED_TIME_VALUE);
            
            string parsedTime = string.Empty;
            string secondsString = $"{seconds} {SECONDS_STRING}";
            string minutesString = $"{minutes} {MINUTES_STRING}";

            if (minutes > 0 && seconds > 0)
                parsedTime = $"{minutesString} {secondsString}";
            else
                parsedTime = secondsString;

            return parsedTime;
        }
    }
}