﻿using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.RuntimeData;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.ViewModel;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.Mediator
{
    public class HudMediator : IHudMediator
    {
        private const float ULT_MAX_PERCENT_VALUE = 1f;
        private readonly IHUDRuntimeData _hudRuntimeData = null;
        
        private IHudViewModel _viewModel = null;

        public HudMediator(IHUDRuntimeData hudRuntimeData)
        {
            _hudRuntimeData = hudRuntimeData;
        }
        
        public void SetModel(IUIViewModel viewModel)
        {
            _viewModel = viewModel as IHudViewModel;
        }

        public void OnFireButtonClick()
        {
        }

        public void OnUltButtonClick()
        {
            _hudRuntimeData.OnUltButtonPressed?.Invoke();
            UpdateUltButtonState();
        }

        public void OnChangeHpValue() => 
            UpdateHpValue();

        public void OnChangeUltValue() => 
            UpdateUltValue();

        private void UpdateHpValue()
        {
            float maxBarWidth = GetMaxProgressWidth(_viewModel.PlayerHpProgressBackRect);
            
            Vector2 newHpBarValue = new Vector2(maxBarWidth * _hudRuntimeData.CurrentHealthPercentValue, _viewModel.PlayerHpProgressRect.sizeDelta.y);
            
            _viewModel.PlayerHpProgressRect.sizeDelta = newHpBarValue;
        }

        private void UpdateUltValue()
        {
            float maxBarWidth = GetMaxProgressWidth(_viewModel.PlayerUltProgressBackRect);
            Vector2 newUltBarValue = new Vector2(maxBarWidth * _hudRuntimeData.CurrentStrengthPercentValue, _viewModel.PlayerUltProgressRect.sizeDelta.y);
            
            _viewModel.PlayerUltProgressRect.sizeDelta = newUltBarValue;

            UpdateUltButtonState();
        }

        private float GetMaxProgressWidth(RectTransform barBack)
        {
            return barBack.sizeDelta.x;
        }

        private void UpdateUltButtonState()
        {
            _viewModel.UltButton.interactable = HasEnoughUltStrength();
        }

        private bool HasEnoughUltStrength()
        {
            return _hudRuntimeData.CurrentStrengthPercentValue >= ULT_MAX_PERCENT_VALUE;
        }
    }
}