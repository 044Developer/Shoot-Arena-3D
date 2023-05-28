using System;
using System.Collections;
using ShootArena.Infrastructure.Modules.SceneLoader.Data;
using ShootArena.Infrastructure.MonoComponents.CoroutineRunner;
using ShootArena.Infrastructure.MonoComponents.StaticContainers.Containers.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootArena.Infrastructure.Modules.SceneLoader.Implementation
{
    public class SceneLoaderModule : ISceneLoaderModule
    {
        private readonly ICoroutineRunner _coroutineRunner = null;
        private readonly ScenesStaticDataContainer _staticDataContainer = null;
        private SceneType _previousSceneType = SceneType.None;

        public SceneLoaderModule(ICoroutineRunner coroutineRunner, ScenesStaticDataContainer staticDataContainer)
        {
            _coroutineRunner = coroutineRunner;
            _staticDataContainer = staticDataContainer;
        }
        
        public void Load(SceneType sceneType, LoadSceneMode loadSceneMode, Action onLoadingFinished = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(sceneType, loadSceneMode, onLoadingFinished));
        }

        private IEnumerator LoadScene(SceneType sceneType, LoadSceneMode loadSceneMode, Action onLoadingFinished)
        {
            string sceneName = _staticDataContainer.GetSceneNameByType(sceneType);
            
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onLoadingFinished?.Invoke();
                yield break;
            }
            
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);

            while (!waitNextScene.isDone)
                yield return null;

            UnloadPreviousScene();
            _previousSceneType = sceneType;
            onLoadingFinished?.Invoke();
        }

        private void UnloadPreviousScene()
        {
            if (_previousSceneType == SceneType.None)
                return;

            string sceneName = _staticDataContainer.GetSceneNameByType(_previousSceneType);

            SceneManager.UnloadSceneAsync(sceneName, UnloadSceneOptions.None);
        }
    }
}