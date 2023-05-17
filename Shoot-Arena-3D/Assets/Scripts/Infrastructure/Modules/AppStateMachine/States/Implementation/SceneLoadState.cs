using System;
using ShootArena.Infrastructure.Modules.SceneLoader;
using UnityEngine.SceneManagement;

namespace ShootArena.Infrastructure.Modules.AppStateMachine.States.Implementation
{
    public class SceneLoadState : IThreePayloadedState<string, LoadSceneMode, Action>
    {
        private readonly ISceneLoaderModule _sceneLoader = null;

        public SceneLoadState(ISceneLoaderModule sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        public void Enter(string sceneName, LoadSceneMode loadMode, Action onCompleteAction)
        {
            _sceneLoader.Load(sceneName, loadMode, onCompleteAction);
        }

        public void Exit()
        {
        }
    }
}