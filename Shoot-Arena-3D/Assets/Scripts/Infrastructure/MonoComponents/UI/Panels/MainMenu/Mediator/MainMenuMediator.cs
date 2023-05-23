using DG.Tweening;
using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.MainMenu.ViewModel;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.MainMenu.Mediator
{
    public class MainMenuMediator : IMainMenuMediator
    {
        private const string GIT_HUB_URL = "";
        private const string LINKED_IN_URL = "";
        private const string TELEGRAM_URL = "";
        
        private IMainMenuViewModel _viewModel = null;
        private Sequence _logoAnimationSequence = null;
        
        public void SetModel(IUIViewModel viewModel)
        {
            _viewModel = viewModel as IMainMenuViewModel;
        }

        public void Initialize()
        {
            SetUpAnimation();
        }

        public void Execute()
        {
            ResetLogoPosition();
            PlayAnimation();
        }

        public void OnPlayButtonClicked()
        {
        }

        public void OnGitHubButtonClicked()
        {
            Application.OpenURL(GIT_HUB_URL);
        }

        public void OnLinkedInButtonClicked()
        {
            Application.OpenURL(LINKED_IN_URL);
        }

        public void OnTelegramButtonClicked()
        {
            Application.OpenURL(TELEGRAM_URL);
        }

        private void SetUpAnimation()
        {
            _logoAnimationSequence = DOTween.Sequence();
            _logoAnimationSequence.SetRecyclable(true);
            _logoAnimationSequence.Append(_viewModel.LogoTextRect.DOAnchorPos(_viewModel.EndAnimationValue, _viewModel.LogoAnimationDuration));
            _logoAnimationSequence.Append(_viewModel.LogoTextRect.DOPunchAnchorPos(_viewModel.LogoPunchVibrationValue, _viewModel.LogoPunchVibrationDuration));
        }

        private void ResetLogoPosition() => 
            _viewModel.LogoTextRect.anchoredPosition = _viewModel.StartAnimationValue;

        private void PlayAnimation() => 
            _logoAnimationSequence.Play();
    }
}