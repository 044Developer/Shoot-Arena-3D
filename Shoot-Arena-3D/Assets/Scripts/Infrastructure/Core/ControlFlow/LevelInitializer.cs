using System;
using ShootArena.Infrastructure.Core.Level.Handlers.LevelStates;
using ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States.Implementation;
using ShootArena.Infrastructure.Core.Level.RuntimeData;
using ShootArena.Infrastructure.Core.Level.RuntimeData.ControlFlow;
using Zenject;

namespace ShootArena.Infrastructure.Core.ControlFlow
{
    public class LevelInitializer : IInitializable, IDisposable
    {
        private readonly ILevelStatesHandler _levelStatesHandler = null;
        private readonly LevelControlFlowRuntimeData _controlFlowRuntimeData = null;

        public LevelInitializer(
            ILevelStatesHandler levelStatesHandler,
            ILevelControlFlowRuntimeData controlFlowRuntimeData)
        {
            _levelStatesHandler = levelStatesHandler;
            _controlFlowRuntimeData = controlFlowRuntimeData as LevelControlFlowRuntimeData;
        }
        
        public void Initialize()
        {
            InitializeEvents();
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

        private void EnterPrepareState()
        {
            _levelStatesHandler.ChangeLevelStateTo<PrepareLevelState>();
        }

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
    }
}