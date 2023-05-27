using System;
using System.Collections.Generic;
using ShootArena.Infrastructure.Modules.CustomFactory;
using ShootArena.Infrastructure.Modules.CustomLogger;
using ShootArena.Infrastructure.Modules.UIPanels.Container;
using ShootArena.Infrastructure.Modules.UIPanels.Data;
using ShootArena.Infrastructure.Modules.UIPanels.Models;
using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Root;
using ShootArena.Infrastructure.MonoComponents.UI.Root.Data;
using UnityEngine;

namespace ShootArena.Infrastructure.Modules.UIPanels.Implementation
{
    public class UIPanelsModule : IUIPanelsModule
    {
        private readonly IUIRoot _uiRoot = null;
        private readonly IUIPanelsContainer _panelsContainer = null;
        private readonly ICustomFactoryModule _customFactory = null;
        private readonly ICustomLoggerModule _logger = null;

        private List<IPanelConfigModel> _openedPanels = null;

        public UIPanelsModule(
            IUIRoot uiRoot,
            IUIPanelsContainer panelsContainer,
            ICustomFactoryModule customFactory,
            ICustomLoggerModule logger)
        {
            _uiRoot = uiRoot;
            _panelsContainer = panelsContainer;
            _customFactory = customFactory;
            _logger = logger;

            _openedPanels = new List<IPanelConfigModel>(4);
        }
        
        /*
         *  Public
         */

        public void Initialize()
        {
            _panelsContainer.Initialize();
        }

        public void ShowPanel<TPanel>(UIPanelType panelType, Action onPanelOpenAction = null, Action onPanelClosedAction = null) where TPanel : IUIView
        {
            IPanelConfigModel tempConfig = ReadConfig(panelType);

            if (tempConfig == null)
                return;

            tempConfig.OnPanelOpenAction = onPanelOpenAction;
            tempConfig.OnPanelClosedAction = onPanelClosedAction;
            
            SpawnImpl<TPanel>(tempConfig);
            OpenImpl(tempConfig);
        }

        public void ClosePanel(UIPanelType panelType)
        {
            if (!IsPanelOpened(panelType))
                return;

            IPanelConfigModel tempConfig = _openedPanels.Find(model => model.PanelType == panelType);
            
            CloseImpl(tempConfig);
        }

        public bool IsPanelOpened(UIPanelType panelType)
        {
            return _openedPanels.Find(model => model.PanelType == panelType) != null;
        }
        
        /*
         *  Private
         */

        private IPanelConfigModel ReadConfig(UIPanelType panelType)
        {
            return _panelsContainer.GetPanelConfig(panelType);
        }

        private void SpawnImpl<TPanel>(IPanelConfigModel configModel) where TPanel : IUIView
        {
            Transform parent = ConvertRootTypeToParent(configModel.RootLayerType);
            TPanel temp = _customFactory.Create<TPanel>(configModel.PrefabPath, parent);

            configModel.Implementation = temp;
        }

        private void OpenImpl(IPanelConfigModel configModel)
        {
            if (configModel.Implementation == null)
                return;
            
            configModel.Implementation.Initialize();
            configModel.Implementation.Show();
            configModel.OnPanelOpenAction?.Invoke();
            
            _openedPanels.Add(configModel);
        }

        private void CloseImpl(IPanelConfigModel configModel)
        {
            if (configModel.Implementation == null)
                return;
            
            configModel.Implementation.Dispose();
            configModel.Implementation.Close();
            configModel.OnPanelClosedAction?.Invoke();
            
            configModel.Implementation = null;
            _openedPanels.Remove(configModel);
        }

        private Transform ConvertRootTypeToParent(UIRootType type)
        {
            return _uiRoot.GetRootByType(type);
        }
    }
}