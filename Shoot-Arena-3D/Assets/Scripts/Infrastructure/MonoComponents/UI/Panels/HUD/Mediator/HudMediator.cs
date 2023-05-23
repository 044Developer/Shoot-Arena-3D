using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.ViewModel;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.Mediator
{
    public class HudMediator : IHudMediator
    {
        private IHudViewModel _viewModel = null;
        private float _maxHpValue = 100f;
        private float _maxUltValue = 100f;
        
        public void SetModel(IUIViewModel viewModel)
        {
            _viewModel = viewModel as IHudViewModel;
        }

        public void OnFireButtonClick()
        {
        }

        public void OnUltButtonClick()
        {
        }

        public void OnChangeHpValue(float newValue) => 
            UpdateHpValue(newValue);

        public void OnChangeUltValue(float newValue) => 
            UpdateUltValue(newValue);

        private void UpdateHpValue(float newValue)
        {
            float maxBarWidth = GetMaxProgressWidth(_viewModel.PlayerHpProgressBackRect);
            float currentPercent = newValue / _maxHpValue;
            Vector2 newHpBarValue = new Vector2(maxBarWidth * currentPercent, _viewModel.PlayerHpProgressRect.sizeDelta.y);
            
            _viewModel.PlayerHpProgressRect.sizeDelta = newHpBarValue;
        }

        private void UpdateUltValue(float newValue)
        {
            float maxBarWidth = GetMaxProgressWidth(_viewModel.PlayerUltProgressBackRect);
            float currentPercent = newValue / _maxUltValue;
            Vector2 newUltBarValue = new Vector2(maxBarWidth * currentPercent, _viewModel.PlayerUltProgressRect.sizeDelta.y);
            
            _viewModel.PlayerUltProgressRect.sizeDelta = newUltBarValue;
        }

        private float GetMaxProgressWidth(RectTransform barBack)
        {
            return barBack.sizeDelta.x;
        }
    }
}