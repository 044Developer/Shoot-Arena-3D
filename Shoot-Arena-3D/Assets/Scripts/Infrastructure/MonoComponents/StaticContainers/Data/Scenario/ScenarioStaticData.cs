using System;
using ShootArena.Infrastructure.Modules.XMLReader.Data;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.StaticContainers.Data.Scenario
{
    [Serializable]
    public class ScenarioStaticData
    {
        [SerializeField] private XMLScenarioType _scenarioType = XMLScenarioType.None;
        [SerializeField] private string _scenarioPath = string.Empty;

        public XMLScenarioType ScenarioType => _scenarioType;
        public string ScenarioPath => _scenarioPath;
    }
}