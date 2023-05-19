using ShootArena.Infrastructure.MonoComponents.StaticContainers.Containers.Scenario;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Installers.Project
{
    [CreateAssetMenu(fileName = "ProjectSOInstaller", menuName = "Installers/ProjectSOInstaller")]
    public class ProjectSOInstaller : ScriptableObjectInstaller<ProjectSOInstaller>
    {
        [Header("Scenario Containers")]
        [SerializeField] private ScenarioStaticDataContainer _scenarioStaticDataContainer = null;
    
        public override void InstallBindings()
        {
            BindStaticData();
        }

        private void BindStaticData()
        {
            Container
                .BindInstance(_scenarioStaticDataContainer);
        }
    }
}