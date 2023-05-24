using System;
using DG.Tweening;
using ShootArena.Infrastructure.Modules.AppStateMachine;
using ShootArena.Infrastructure.Modules.AppStateMachine.States.Implementation;
using ShootArena.Infrastructure.Modules.SceneLoader.Data;
using ShootArena.Infrastructure.Modules.UIPanels;
using ShootArena.Infrastructure.Modules.UIPanels.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.LoadingScreen.Implementation;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.MainMenu.ViewModel;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.MainMenu.Mediator
{
    public class MainMenuMediator : IMainMenuMediator
    {
        private readonly IAppStateMachine _stateMachine = null;
        private readonly IUIPanelsModule _panelsModule = null;
        private const string GIT_HUB_URL = "https://github.com/044Developer";
        private const string LINKED_IN_URL = "https://www.linkedin.com/in/kyrylo-sydorenko-049248135/";
        private const string TELEGRAM_URL = "https://t.me/o44Developer";
        
        private IMainMenuViewModel _viewModel = null;
        private Sequence _logoAnimationSequence = null;

        public MainMenuMediator(IAppStateMachine stateMachine, IUIPanelsModule panelsModule)
        {
            _stateMachine = stateMachine;
            _panelsModule = panelsModule;
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
            LoadLevel();
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

        private void LoadLevel()
        {
            _panelsModule.ShowPanel<LoadingScreenPanel>(UIPanelType.Loading, onPanelOpenAction: OnLoadingScreenOpened);
            
            CloseMainMenu();
        }

        private void OnLoadingScreenOpened() => 
            _stateMachine.Enter<SceneLoadState, SceneType, LoadSceneMode, Action>(SceneType.Core, LoadSceneMode.Additive, null);

        private void CloseMainMenu()
        {
            _panelsModule.ClosePanel(UIPanelType.Menu);
        }
    }
}