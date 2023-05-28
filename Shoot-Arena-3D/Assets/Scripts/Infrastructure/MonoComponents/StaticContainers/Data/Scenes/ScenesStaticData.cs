using System;
using ShootArena.Infrastructure.Modules.SceneLoader.Data;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.StaticContainers.Data.Scenes
{
    [Serializable]
    public class ScenesStaticData
    {
        [SerializeField] private SceneType _sceneType = SceneType.None;
        [SerializeField] private string _sceneName = string.Empty;

        public SceneType SceneType => _sceneType;
        public string SceneName => _sceneName;
    }
}