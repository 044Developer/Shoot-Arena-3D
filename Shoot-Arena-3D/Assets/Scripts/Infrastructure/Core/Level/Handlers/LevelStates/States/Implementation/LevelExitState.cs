using System;
using ShootArena.Infrastructure.Modules.AppStateMachine;
using ShootArena.Infrastructure.Modules.AppStateMachine.States.Implementation;
using ShootArena.Infrastructure.Modules.SceneLoader.Data;
using ShootArena.Infrastructure.Modules.UIPanels;
using ShootArena.Infrastructure.Modules.UIPanels.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.LoadingScreen.Implementation;
using UnityEngine.SceneManagement;

namespace ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States.Implementation
{
    public class LevelExitState : BaseLevelState
    {
        private readonly IAppStateMachine _appStateMachine = null;
        private readonly IUIPanelsModule _panelsModule = null;

        public LevelExitState(
            IAppStateMachine appStateMachine,
            IUIPanelsModule panelsModule
            )
        {
            _appStateMachine = appStateMachine;
            _panelsModule = panelsModule;
        }

        public override void Enter()
        {
            base.Enter();

            OpenLoadingPanel();
        }

        private void OpenLoadingPanel()
        {
            _panelsModule.ShowPanel<LoadingScreenPanel>(UIPanelType.Loading, 
                onPanelOpenAction: LoadMainMenuScene,
                onPanelClosedAction: EnterMainMenu);
        }

        private void LoadMainMenuScene()
        {
            _appStateMachine.Enter<SceneLoadState, SceneType, LoadSceneMode, Action>(SceneType.Main, LoadSceneMode.Additive, null);
        }

        private void EnterMainMenu()
        {
            _appStateMachine.Enter<AppMainMenuState>();
        }
    }
}