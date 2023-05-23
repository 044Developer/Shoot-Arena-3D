using System;
using DG.Tweening;
using ShootArena.Infrastructure.Modules.DeviceCheck;
using ShootArena.Infrastructure.Modules.DeviceCheck.Data;
using ShootArena.Infrastructure.Modules.UIPanels;
using ShootArena.Infrastructure.Modules.UIPanels.Data;
using ShootArena.Infrastructure.Modules.UIWindows;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.SplashScreen.Implementation;
using UnityEngine.SceneManagement;

namespace ShootArena.Infrastructure.Modules.AppStateMachine.States.Implementation
{
    public class BoostrapState : IAppState
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
        
        public void Enter()
        {
            SetUp();
            
            _panelsModule.ShowPanel<SplashScreenPanel>(UIPanelType.Splash);
            
            _stateMachine.Enter<SceneLoadState, string, LoadSceneMode, Action>("Main", LoadSceneMode.Additive, null);
        }
        
        public void Exit()
        {
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

            DOTween.defaultAutoPlay = AutoPlay.None;
        }

        private void RegisterUI()
        {
            _panelsModule.Initialize();
            _windowsModule.Initialize();
        }
    }
}