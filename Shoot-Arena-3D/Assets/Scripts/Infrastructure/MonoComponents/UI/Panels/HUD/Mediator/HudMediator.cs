using ShootArena.Infrastructure.Modules.DeviceCheck;
using ShootArena.Infrastructure.Modules.DeviceCheck.Data;
using ShootArena.Infrastructure.Modules.UIWindows;
using ShootArena.Infrastructure.Modules.UIWindows.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.RuntimeData;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.ViewModel;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Pause.Implementation;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.Mediator
{
    public class HudMediator : IHudMediator
    {
        private const float HP_MAX_PERCENT_VALUE = 1f;
        private readonly IHUDRuntimeData _hudRuntimeData = null;
        private readonly IDeviceCheckModule _deviceCheckModule = null;
        private readonly IUIWindowsModule _windowsModule = null;

        private IHudViewModel _viewModel = null;

        public HudMediator(
            IHUDRuntimeData hudRuntimeData,
            IDeviceCheckModule deviceCheckModule,
            IUIWindowsModule windowsModule
            )
        {
            _hudRuntimeData = hudRuntimeData;
            _deviceCheckModule = deviceCheckModule;
            _windowsModule = windowsModule;
        }

        public void SetUpPanel()
        {
            UpdateHpValue();
            UpdateUltValue();
            
            _viewModel.MobileInputHolder.SetActive(false);
            UpdateHudViewState(false);
        }
        
        public void SetModel(IUIViewModel viewModel)
        {
            _viewModel = viewModel as IHudViewModel;
        }

        public void OnPauseButtonClick()
        {
            _hudRuntimeData.OnPauseButtonClick?.Invoke();
            
            _windowsModule.ShowWindow<PauseWindow>(UIWindowType.Pause);
        }

        public void OnChangeHpValue() => 
            UpdateHpValue();

        public void OnChangeUltValue() => 
            UpdateUltValue();

        public void OnLevelStart()
        {
            UpdateHudViewState(true);
            CheckForInputView();
        }

        public void OnLevelReset()
        {
            _viewModel.MobileInputHolder.SetActive(false);
            UpdateHudViewState(false);
        }

        private void UpdateHpValue()
        {
            float maxBarWidth = GetMaxProgressWidth(_viewModel.PlayerHpProgressBackRect);
            
            Vector2 newHpBarValue = new Vector2(maxBarWidth * _hudRuntimeData.CurrentHealthPercentValue, _viewModel.PlayerHpProgressRect.sizeDelta.y);
            
            _viewModel.PlayerHpProgressRect.sizeDelta = newHpBarValue;

            UpdateHealthVisualTrigger();
        }

        private void UpdateUltValue()
        {
            float maxBarWidth = GetMaxProgressWidth(_viewModel.PlayerUltProgressBackRect);
            Vector2 newUltBarValue = new Vector2(maxBarWidth * _hudRuntimeData.CurrentStrengthPercentValue, _viewModel.PlayerUltProgressRect.sizeDelta.y);
            
            _viewModel.PlayerUltProgressRect.sizeDelta = newUltBarValue;
        }

        private float GetMaxProgressWidth(RectTransform barBack)
        {
            return barBack.sizeDelta.x;
        }

        private void UpdateHealthVisualTrigger()
        {
            float currentFadeValue = HP_MAX_PERCENT_VALUE - _hudRuntimeData.CurrentHealthPercentValue;

            _viewModel.HealthCanvasGroup.alpha = currentFadeValue;
        }

        private void UpdateHudViewState(bool viewState)
        {
            _viewModel.GamePlayPanel.SetActive(viewState);
        }

        private void CheckForInputView()
        {
            if (_deviceCheckModule.CurrentDeviceType.HasFlag(CurrentDeviceType.Mobile))
            {
                _viewModel.MobileInputHolder.SetActive(true);
            }
            else
            {
                _viewModel.MobileInputHolder.SetActive(false);
            }
        }
    }
}