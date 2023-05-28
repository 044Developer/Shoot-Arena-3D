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

        public LoadingScreenMediator(IUIPanelsModule panelsModule)
        {
            _panelsModule = panelsModule;
        }
        
        public void SetModel(IUIViewModel viewModel)
        {
            _viewModel = viewModel as ILoadingScreenViewModel;
        }

        public void Execute()
        {
            PlayAnimation();
        }

        private void PlayAnimation() => 
                SetUpAnimation();

        private void SetUpAnimation()
        {
            _viewModel.ProgressBarRect.sizeDelta = new Vector2(0f, _viewModel.ProgressBarRect.sizeDelta.y);
            
            float progressWidth = GetProgressWidth();
            Vector2 progressEndValue = new Vector2(progressWidth, _viewModel.ProgressBarRect.sizeDelta.y);

            Tween loadingTween = _viewModel.ProgressBarRect
                .DOSizeDelta(progressEndValue, _viewModel.LoadingDuration)
                .OnComplete(OnLoadingAnimationFinished)
                .SetRecyclable(true);

            loadingTween.Play();
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