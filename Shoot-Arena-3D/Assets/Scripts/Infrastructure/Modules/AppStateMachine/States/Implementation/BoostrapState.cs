using System;
using DG.Tweening;
using ShootArena.Infrastructure.Modules.DeviceCheck;
using ShootArena.Infrastructure.Modules.DeviceCheck.Data;
using ShootArena.Infrastructure.Modules.SceneLoader.Data;
using ShootArena.Infrastructure.Modules.UIPanels;
using ShootArena.Infrastructure.Modules.UIPanels.Data;
using ShootArena.Infrastructure.Modules.UIWindows;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.LoadingScreen.Implementation;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.SplashScreen.Implementation;
using UnityEngine.SceneManagement;

namespace ShootArena.Infrastructure.Modules.AppStateMachine.States.Implementation
{
    public class BoostrapState : AppBaseState
    {
        private readonly IAppStateMachine _stateMachine = null;
        private readonly IDeviceCheckModule _deviceCheckModule = null;
        private readonly IUIPanelsModule _panelsModule = null;
        private readonly IUIWindowsModule _windowsModule = null;

        public BoostrapState(IAppStateMachine stateMachine, IDeviceCheckModule deviceCheckModule, IUIPanelsModule panelsModule, IUIWindowsModule windowsModule)
        {
            _stateMachine = stateMachine;
            _deviceCheckModule = deviceCheckModule;
            _panelsModule = panelsModule;
            _windowsModule = windowsModule;
        }
        
        public override void Enter()
        {
            SetUp();
            
            LoadMainScene();
            ShowSplash();
        }

        private void SetUp()
        {
            RegisterDevice();
            RegisterUI();
            RegisterDoTween();
        }

        private void RegisterDevice()
        {
            _deviceCheckModule.CheckCurrentDevice();
        }

        private void RegisterDoTween()
        {
            CurrentDeviceType deviceType = _deviceCheckModule.CurrentDeviceType;
            
            if (deviceType.HasFlag(CurrentDeviceType.Mobile))
            {
                DOTween.useSafeMode = false;
            }
            else
            {
                DOTween.useSafeMode = true;
            }
        }

        private void RegisterUI()
        {
            _panelsModule.Initialize();
            _windowsModule.Initialize();
        }

        private void ShowSplash() => 
            _panelsModule.ShowPanel<SplashScreenPanel>(UIPanelType.Splash, onPanelClosedAction: OnSplashScreenCloseAction);

        private void OnSplashScreenCloseAction()
        {
            _panelsModule.ShowPanel<LoadingScreenPanel>(UIPanelType.Loading, onPanelClosedAction: OnLoadingScreenCloseAction);
        }

        private void LoadMainScene() => 
            _stateMachine.Enter<SceneLoadState, SceneType, LoadSceneMode, Action>(SceneType.Main, LoadSceneMode.Additive, null);

        private void OnLoadingScreenCloseAction() => 
            _stateMachine.Enter<AppMainMenuState>();
    }
}