using System;
using UnityEngine.SceneManagement;

namespace ShootArena.Infrastructure.Modules.AppStateMachine.States.Implementation
{
    public class BoostrapState : IAppState
    {
        private readonly IAppStateMachine _stateMachine = null;

        public BoostrapState(IAppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            _stateMachine.Enter<SceneLoadState, string, LoadSceneMode, Action>("Core", LoadSceneMode.Additive, null);
        }
        
        public void Exit()
        {
        }
    }
}