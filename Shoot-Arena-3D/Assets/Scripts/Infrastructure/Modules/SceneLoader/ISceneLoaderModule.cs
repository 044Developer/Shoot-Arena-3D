using System;
using ShootArena.Infrastructure.Modules.SceneLoader.Data;
using UnityEngine.SceneManagement;

namespace ShootArena.Infrastructure.Modules.SceneLoader
{
    public interface ISceneLoaderModule
    {
        public void Load(SceneType sceneType, LoadSceneMode loadSceneMode, Action onLoadingFinished = null);
    }
}