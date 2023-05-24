using DG.Tweening;
using ShootArena.Infrastructure.Modules.UIPanels;
using ShootArena.Infrastructure.Modules.UIPanels.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.LoadingScreen.ViewModel;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.LoadingScreen.Mediator
{
    public class LoadingScreenMediator : ILoadingScreenMediator
    {
        private readonly IUIPanelsModule _panelsModule = null;
        private ILoadingScreenViewModel _viewModel = null;
        private Sequence _loadingBarSequence = null;

        public LoadingScreenMediator(IUIPanelsModule panelsModule)
        {
            _panelsModule = panelsModule;
        }
        
        public void SetModel(IUIViewModel viewModel)
        {
            _viewModel = viewModel as ILoadingScreenViewModel;
        }

        public void Initialize()
        {
            SetUpAnimation();
        }

        public void Execute()
        {
            PlayAnimation();
        }

        private void PlayAnimation() => 
            _loadingBarSequence.Play();

        private void SetUpAnimation()
        {
            float progressWidth = GetProgressWidth();
            Vector2 progressEndValue = new Vector2(progressWidth, _viewModel.ProgressBarRect.sizeDelta.y);

            _loadingBarSequence = DOTween.Sequence();
            _loadingBarSequence.SetRecyclable(true);
            _loadingBarSequence.Append(_viewModel.ProgressBarRect.DOSizeDelta(progressEndValue, _viewModel.LoadingDuration));
            _loadingBarSequence.AppendCallback(OnLoadingAnimationFinished);
        }

        private void OnLoadingAnimationFinished() =>
            CloseLoadingPanel();

        private float GetProgressWidth()
        {
            return _viewModel.ProgressBarBackRect.sizeDelta.x;
        }

        private void CloseLoadingPanel() => 
            _panelsModule.ClosePanel(UIPanelType.Loading);
    }
}