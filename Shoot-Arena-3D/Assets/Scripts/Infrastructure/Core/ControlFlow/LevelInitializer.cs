using System;
using ShootArena.Infrastructure.Core.Level.Handlers.LevelStates;
using ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States.Implementation;
using ShootArena.Infrastructure.Core.Level.RuntimeData.ControlFlow;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.RuntimeData;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Pause.RuntimeData;
using Zenject;

namespace ShootArena.Infrastructure.Core.ControlFlow
{
    public class LevelInitializer : IInitializable, IDisposable
    {
        private readonly ILevelStatesHandler _levelStatesHandler = null;
        private readonly HUDRuntimeData _hudRuntimeData = null;
        private readonly LevelPauseRuntimeData _levelPauseRuntimeData = null;
        private readonly LevelControlFlowRuntimeData _controlFlowRuntimeData = null;

        public LevelInitializer(
            ILevelStatesHandler levelStatesHandler,
            ILevelControlFlowRuntimeData controlFlowRuntimeData,
            ILevelPauseRuntimeData levelPauseRuntimeData,
            IHUDRuntimeData hudRuntimeData
            )
        {
            _levelStatesHandler = levelStatesHandler;
            _hudRuntimeData = hudRuntimeData as HUDRuntimeData;
            _levelPauseRuntimeData = levelPauseRuntimeData as LevelPauseRuntimeData;
            _controlFlowRuntimeData = controlFlowRuntimeData as LevelControlFlowRuntimeData;
        }
        
        public void Initialize()
        {
            InitializeEvents();
            
            SetUpHudActions();
            
            SetUpPauseWindowActions();
            
            EnterPrepareState();
        }

        public void Dispose()
        {
            DisposeEvents();
        }

        private void InitializeEvents()
        {
            _controlFlowRuntimeData.OnLevelPrepareStateAction += EnterPrepareState;
            _controlFlowRuntimeData.OnLevelEnterStateAction += EnterLevelEnterState;
            _controlFlowRuntimeData.OnLevelPauseStateAction += EnterPauseState;
            _controlFlowRuntimeData.OnLevelResumeStateAction += EnterResumeState;
            _controlFlowRuntimeData.OnLevelExitStateAction += EnterExitState;
            _controlFlowRuntimeData.OnLevelRestartStateAction += EnterRestartState;
        }

        private void DisposeEvents()
        {
            _controlFlowRuntimeData.OnLevelPrepareStateAction += EnterPrepareState;
            _controlFlowRuntimeData.OnLevelEnterStateAction += EnterLevelEnterState;
            _controlFlowRuntimeData.OnLevelPauseStateAction += EnterPauseState;
            _controlFlowRuntimeData.OnLevelResumeStateAction += EnterResumeState;
            _controlFlowRuntimeData.OnLevelExitStateAction += EnterExitState;
            _controlFlowRuntimeData.OnLevelRestartStateAction += EnterRestartState;
        }

        private void EnterPrepareState() => 
            _levelStatesHandler.ChangeLevelStateTo<PrepareLevelState>();

        private void EnterLevelEnterState() => 
            _levelStatesHandler.ChangeLevelStateTo<LevelEnterState>();

        private void EnterPauseState() => 
            _levelStatesHandler.ChangeLevelStateTo<LevelPauseState>();

        private void EnterResumeState() => 
            _levelStatesHandler.ChangeLevelStateTo<LevelResumeState>();

        private void EnterExitState() => 
            _levelStatesHandler.ChangeLevelStateTo<LevelExitState>();

        private void EnterRestartState() => 
            _levelStatesHandler.ChangeLevelStateTo<LevelRestartState>();

        private void SetUpHudActions()
        {
            _hudRuntimeData.OnPauseButtonClick = EnterPauseState;
        }
        
        private void SetUpPauseWindowActions()
        {
            _levelPauseRuntimeData.OnResumeButtonClick = EnterResumeState;
            _levelPauseRuntimeData.OnExitButtonClick = EnterExitState;
        }
    }
}