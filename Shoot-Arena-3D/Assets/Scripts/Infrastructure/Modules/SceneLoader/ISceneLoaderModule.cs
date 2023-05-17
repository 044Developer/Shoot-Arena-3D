using System;
using UnityEngine.SceneManagement;

namespace ShootArena.Infrastructure.Modules.SceneLoader
{
    public interface ISceneLoaderModule
    {
        public void Load(string sceneName, LoadSceneMode loadSceneMode, Action onLoadingFinished = null);
    }
}