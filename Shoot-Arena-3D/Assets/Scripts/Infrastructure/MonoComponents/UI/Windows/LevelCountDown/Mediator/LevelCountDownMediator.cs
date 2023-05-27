using DG.Tweening;
using ShootArena.Infrastructure.Modules.UIWindows;
using ShootArena.Infrastructure.Modules.UIWindows.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.LevelCountDown.ViewModel;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.LevelCountDown.Mediator
{
    public class LevelCountDownMediator : ILevelCountDownMediator
    {
        private readonly IUIWindowsModule _windowsModule = null;
        private ILevelCountDownViewModel _viewModel = null;
        private Sequence _countDownSequence = null;

        public LevelCountDownMediator(IUIWindowsModule windowsModule)
        {
            _windowsModule = windowsModule;
        }
        
        public void SetModel(IUIViewModel viewModel)
        {
            _viewModel = viewModel as ILevelCountDownViewModel;
        }

        public void SetUpWindow()
        {
            SetUpValues();

            SetUpAnimation();
        }

        public void OpenWindow()
        {
            _countDownSequence.Play();
        }

        private void SetUpAnimation()
        {
            _countDownSequence = DOTween.Sequence();
            _countDownSequence.SetRecyclable(true);
            _countDownSequence.Append(ImageFadeTween());
            _countDownSequence.Join(CountDownTween());
            _countDownSequence.OnComplete(OnAnimationEnd);
        }

        private void SetUpValues()
        {
            _viewModel.CounterText.text = "3";
            var currentColor = _viewModel.FadeImage.color;
            _viewModel.FadeImage.color =
                new Color(currentColor.r, currentColor.g, currentColor.b, _viewModel.FadeStartValue);
        }

        private Tween ImageFadeTween()
        {
            return _viewModel.FadeImage.DOFade(_viewModel.FadeEndValue, _viewModel.AnimationDuration);
        }

        private Tween CountDownTween()
        {
            return DOVirtual.Int(3, 0, _viewModel.AnimationDuration, value =>
            {
                _viewModel.CounterText.text = value.ToString();
            });
        }

        private void OnAnimationEnd()
        {
            _windowsModule.CloseWindow(UIWindowType.LevelCountDown);
        }
    }
}