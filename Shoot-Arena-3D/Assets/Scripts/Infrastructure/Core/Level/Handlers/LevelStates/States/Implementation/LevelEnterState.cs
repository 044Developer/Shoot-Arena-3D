using System.Collections;
using ShootArena.Infrastructure.Core.Level.RuntimeData;
using ShootArena.Infrastructure.Modules.UIPanels;
using ShootArena.Infrastructure.Modules.UIPanels.Data;
using ShootArena.Infrastructure.Modules.UIWindows;
using ShootArena.Infrastructure.Modules.UIWindows.Data;
using ShootArena.Infrastructure.MonoComponents.CoroutineRunner;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.LevelCountDown.Implementation;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States.Implementation
{
    public class LevelEnterState : BaseLevelState
    {
        private readonly ILevelTimingRuntimeData _timingRuntimeData = null;
        private readonly IUIWindowsModule _windowsModule = null;
        private readonly IUIPanelsModule _panelsModule = null;
        private readonly ICoroutineRunner _coroutineRunner = null;

        public LevelEnterState(
            ILevelTimingRuntimeData timingRuntimeData,
            IUIWindowsModule windowsModule, IUIPanelsModule panelsModule, ICoroutineRunner coroutineRunner
            )
        {
            _timingRuntimeData = timingRuntimeData;
            _windowsModule = windowsModule;
            _panelsModule = panelsModule;
            _coroutineRunner = coroutineRunner;
        }

        public override void Enter()
        {
            base.Enter();
            
            ResetLevel();

            DelayStartIfNeeded();
        }

        private void ShowCountDownWindow()
        {
            _windowsModule.ShowWindow<LevelCountDownWindow>(UIWindowType.LevelCountDown, onWindowClosedAction: OnWindowCountDownEnd);
        }

        private void ResetLevel()
        {
            _timingRuntimeData.CurrentRespawnRate = 5;
            _timingRuntimeData.IsLevelPaused = true;
        }

        private void OnWindowCountDownEnd()
        {
            _timingRuntimeData.IsLevelPaused = false;
        }

        private void DelayStartIfNeeded()
        {
            _coroutineRunner.StartCoroutine(DelayLevelStartDuringLoading());
        }
        
        private IEnumerator DelayLevelStartDuringLoading()
        {
            while (_panelsModule.IsPanelOpened(UIPanelType.Loading))
            {
                yield return new WaitForSeconds(1f);
            }
            
            ShowCountDownWindow();
        }
    }
}