using System;
using System.Collections;
using ShootArena.Infrastructure.MonoComponents.CoroutineRunner;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootArena.Infrastructure.Modules.SceneLoader.Implementation
{
    public class SceneLoaderModule : ISceneLoaderModule
    {
        private readonly ICoroutineRunner _coroutineRunner = null;

        public SceneLoaderModule(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        public void Load(string sceneName, LoadSceneMode loadSceneMode, Action onLoadingFinished = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, loadSceneMode, onLoadingFinished));
        }

        private IEnumerator LoadScene(string sceneName, LoadSceneMode loadSceneMode, Action onLoadingFinished)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onLoadingFinished?.Invoke();
                yield break;
            }
            
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);

            while (!waitNextScene.isDone)
                yield return null;
            
            onLoadingFinished?.Invoke();
        }
    }
}