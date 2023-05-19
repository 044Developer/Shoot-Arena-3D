using System.Collections.Generic;
using ShootArena.Infrastructure.Modules.XMLReader.Data;
using ShootArena.Infrastructure.MonoComponents.StaticContainers.Data.Scenario;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.StaticContainers.Containers.Scenario
{
    [CreateAssetMenu(menuName = "Static Data/Scenario/XML Path", fileName = "XML_Scenario_Container")]
    public class ScenarioStaticDataContainer : ScriptableObject
    {
        [SerializeField] private List<ScenarioStaticData> _scenarioDataList = null;

        public ScenarioStaticData GetScenarioByType(XMLScenarioType type)
        {
            return _scenarioDataList.Find(data => data.ScenarioType == type);
        }
    }
}