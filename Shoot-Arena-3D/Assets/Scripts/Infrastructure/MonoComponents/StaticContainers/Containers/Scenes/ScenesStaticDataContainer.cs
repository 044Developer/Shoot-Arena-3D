using System.Collections.Generic;
using ShootArena.Infrastructure.Modules.SceneLoader.Data;
using ShootArena.Infrastructure.MonoComponents.StaticContainers.Data.Scenes;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.StaticContainers.Containers.Scenes
{
    [CreateAssetMenu(menuName = "Static Data/Scenes/Scene Names", fileName = "Scene_Static_Container")]
    public class ScenesStaticDataContainer : ScriptableObject
    {
        [SerializeField] private List<ScenesStaticData> _scenesStaticList = new List<ScenesStaticData>();

        public string GetSceneNameByType(SceneType type)
        {
            ScenesStaticData tempData = _scenesStaticList.Find(data => data.SceneType == type);

            return tempData != null 
                ? tempData.SceneName 
                : string.Empty;
        }
    }
}