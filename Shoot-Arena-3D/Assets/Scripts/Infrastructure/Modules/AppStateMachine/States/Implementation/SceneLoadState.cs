using System;
using ShootArena.Infrastructure.Modules.SceneLoader;
using ShootArena.Infrastructure.Modules.SceneLoader.Data;
using UnityEngine.SceneManagement;

namespace ShootArena.Infrastructure.Modules.AppStateMachine.States.Implementation
{
    public class SceneLoadState : IThreePayloadedState<SceneType, LoadSceneMode, Action>
    {
        private readonly ISceneLoaderModule _sceneLoader = null;

        public SceneLoadState(ISceneLoaderModule sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        public void Enter(SceneType sceneType, LoadSceneMode loadMode, Action onCompleteAction)
        {
            _sceneLoader.Load(sceneType, loadMode, onCompleteAction);
        }

        public void Exit()
        {
        }
    }
}