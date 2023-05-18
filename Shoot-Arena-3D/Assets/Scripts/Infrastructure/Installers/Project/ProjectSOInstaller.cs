using ShootArena.Infrastructure.MonoComponents.StaticContainers.Contianers.Scenario;
using UnityEngine;
using Zenject;

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