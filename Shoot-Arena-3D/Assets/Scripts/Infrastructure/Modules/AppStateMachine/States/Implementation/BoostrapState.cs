using System;
using DG.Tweening;
using ShootArena.Infrastructure.Modules.DeviceCheck;
using ShootArena.Infrastructure.Modules.DeviceCheck.Data;
using UnityEngine.SceneManagement;

namespace ShootArena.Infrastructure.Modules.AppStateMachine.States.Implementation
{
    public class BoostrapState : IAppState
    {
        private readonly IAppStateMachine _stateMachine = null;
        private readonly IDeviceCheckModule _deviceCheckModule = null;

        public BoostrapState(IAppStateMachine stateMachine, IDeviceCheckModule deviceCheckModule)
        {
            _stateMachine = stateMachine;
            _deviceCheckModule = deviceCheckModule;
        }
        
        public void Enter()
        {
            SetUp();
            
            _stateMachine.Enter<SceneLoadState, string, LoadSceneMode, Action>("Core", LoadSceneMode.Additive, null);
        }
        
        public void Exit()
        {
        }

        private void SetUp()
        {
            _deviceCheckModule.CheckCurrentDevice();

            RegisterDoTween();
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
    }
}