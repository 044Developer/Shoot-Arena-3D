using System;
using DG.Tweening;
using ShootArena.Infrastructure.Modules.AppStateMachine;
using ShootArena.Infrastructure.Modules.AppStateMachine.States.Implementation;
using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.MainMenu.ViewModel;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.MainMenu.Mediator
{
    public class MainMenuMediator : IMainMenuMediator
    {
        private readonly IAppStateMachine _stateMachine = null;
        private const string GIT_HUB_URL = "https://github.com/044Developer";
        private const string LINKED_IN_URL = "https://www.linkedin.com/in/kyrylo-sydorenko-049248135/";
        private const string TELEGRAM_URL = "https://t.me/o44Developer";
        
        private IMainMenuViewModel _viewModel = null;
        private Sequence _logoAnimationSequence = null;

        public MainMenuMediator(IAppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
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
            _stateMachine.Enter<SceneLoadState, string, LoadSceneMode, Action>("Core", LoadSceneMode.Additive, null);
        }

        public void OnGitHubButtonClicked()
        {
            OpenUrl(GIT_HUB_URL);
        }

        public void OnLinkedInButtonClicked()
        {
            OpenUrl(LINKED_IN_URL);
        }

        public void OnTelegramButtonClicked()
        {
            OpenUrl(TELEGRAM_URL);
        }

        private void OpenUrl(string path)
        {
            Application.OpenURL(path);
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