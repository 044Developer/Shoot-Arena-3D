using DG.Tweening;
using ShootArena.Infrastructure.Modules.AppStateMachine;
using ShootArena.Infrastructure.Modules.AppStateMachine.States.Implementation;
using ShootArena.Infrastructure.Modules.UIPanels;
using ShootArena.Infrastructure.Modules.UIPanels.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.LoadingScreen.Implementation;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.MainMenu.Implementation;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.SplashScreen.ViewModel;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.SplashScreen.Mediator
{
    public class SplashScreenMediator : ISplashScreenMediator
    {
        private readonly IUIPanelsModule _panelsModule = null;
        private readonly IAppStateMachine _appStateMachine = null;
        private ISplashScreenViewModel _viewModel = null;
        private Sequence _splashScreenSequence = null;

        public SplashScreenMediator(
            IUIPanelsModule panelsModule,
            IAppStateMachine appStateMachine
            )
        {
            _panelsModule = panelsModule;
            _appStateMachine = appStateMachine;
        }
        
        public void SetModel(IUIViewModel viewModel)
        {
            _viewModel = viewModel as ISplashScreenViewModel;
        }

        public void Initialize()
        {
            SetUpSequence();
        }

        public void Execute()
        {
            PlaySequence();
        }

        private void SetUpSequence()
        {
            _splashScreenSequence = DOTween.Sequence();
            _splashScreenSequence.SetRecyclable();
            _splashScreenSequence.AppendInterval(_viewModel.SplashScreenDuration);
            _splashScreenSequence.AppendCallback(OnSplashScreenAnimationEnd);
        }

        private void PlaySequence() => 
            _splashScreenSequence.Play();

        private void OnSplashScreenAnimationEnd()
        {
            ShowLoadingScreen();
            
            CloseSplash();
        }

        private void ShowLoadingScreen()
        {
            _panelsModule.ShowPanel<LoadingScreenPanel>(UIPanelType.Loading, onPanelClosedAction: OnLoadingScreenCloseAction);
        }

        private void OnLoadingScreenCloseAction()
        {
            _appStateMachine.Enter<AppMainMenuState>();
            _panelsModule.ShowPanel<MainMenuPanel>(UIPanelType.Menu);
        }

        private void CloseSplash()
        {
            _panelsModule.ClosePanel(UIPanelType.Splash);
        }
    }
}