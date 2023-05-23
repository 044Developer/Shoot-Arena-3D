using System;
using System.Collections.Generic;
using ShootArena.Infrastructure.Modules.CustomFactory;
using ShootArena.Infrastructure.Modules.CustomLogger;
using ShootArena.Infrastructure.Modules.UIWindows.Container;
using ShootArena.Infrastructure.Modules.UIWindows.Data;
using ShootArena.Infrastructure.Modules.UIWindows.Models;
using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Root;
using ShootArena.Infrastructure.MonoComponents.UI.Root.Data;
using UnityEngine;

namespace ShootArena.Infrastructure.Modules.UIWindows.Implementation
{
    public class UIWindowsModule : IUIWindowsModule
    {
        private readonly IUIRoot _uiRoot = null;
        private readonly IUIWindowsContainer _windowsContainer = null;
        private readonly ICustomFactoryModule _customFactory = null;
        private readonly ICustomLoggerModule _logger = null;

        private List<IWindowConfigModel> _openedWindows = null;

        public UIWindowsModule(
            IUIRoot uiRoot,
            IUIWindowsContainer windowsContainer,
            ICustomFactoryModule customFactory,
            ICustomLoggerModule logger)
        {
            _uiRoot = uiRoot;
            _windowsContainer = windowsContainer;
            _customFactory = customFactory;
            _logger = logger;

            _openedWindows = new List<IWindowConfigModel>(4);
        }
        
        /*
         *  Public
         */

        public void Initialize()
        {
            _windowsContainer.Initialize();
        }

        public void ShowWindow<TWindow>(UIWindowType windowType, Action onWindowOpenAction = null, Action onWindowClosedAction = null) where TWindow : IUIView
        {
            var tempConfig = ReadConfig(windowType);

            if (tempConfig == null)
                return;

            tempConfig.OnWindowOpenAction = onWindowOpenAction;
            tempConfig.OnWindowCloseAction = onWindowClosedAction;
            
            SpawnImpl<TWindow>(tempConfig);
            OpenImpl(tempConfig);
        }

        public void CloseWindow(UIWindowType windowType)
        {
            if (!IsWindowOpened(windowType))
                return;

            var tempConfig = _openedWindows.Find(model => model.WindowType == windowType);
            
            CloseImpl(tempConfig);
        }
        
        /*
         *  Private
         */

        private IWindowConfigModel ReadConfig(UIWindowType windowType)
        {
            return _windowsContainer.GetWindowConfig(windowType);
        }

        private void SpawnImpl<TWindow>(IWindowConfigModel configModel) where TWindow : IUIView
        {
            var parent = ConvertRootTypeToParent(configModel.RootLayerType);
            var temp = _customFactory.Create<TWindow>(configModel.PrefabPath, parent);

            configModel.Implementation = temp;
        }

        private void OpenImpl(IWindowConfigModel configModel)
        {
            if (configModel.Implementation == null)
                return;
            
            configModel.Implementation.Initialize();
            configModel.Implementation.Show();
            
            _openedWindows.Add(configModel);
        }

        private void CloseImpl(IWindowConfigModel configModel)
        {
            if (configModel.Implementation == null)
                return;
            
            configModel.Implementation.Dispose();
            configModel.Implementation.Close();
            
            configModel.Implementation = null;
            _openedWindows.Remove(configModel);
        }

        private bool IsWindowOpened(UIWindowType windowType)
        {
            try
            {
                return _openedWindows.Find(model => model.WindowType == windowType) != null;
            }
            catch (Exception exception)
            {
                _logger.LogException(exception);
                throw;
            }
        }

        private Transform ConvertRootTypeToParent(UIRootType type)
        {
            return _uiRoot.GetRootByType(type);
        }
    }
}