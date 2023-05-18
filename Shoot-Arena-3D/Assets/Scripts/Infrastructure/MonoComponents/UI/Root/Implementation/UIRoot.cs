using System;
using ShootArena.Infrastructure.MonoComponents.UI.Root.Data;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.UI.Root.Implementation
{
    public class UIRoot : MonoBehaviour, IUIRoot
    {
        [Header("Panels")]
        [SerializeField] private RectTransform _panelsRoot = null;

        [Header("Windows")]
        [SerializeField] private RectTransform _windowsRoot = null;
        
        public RectTransform GetRootByType(UIRootType type)
        {
            switch (type)
            {
                case UIRootType.Panels:
                    return _panelsRoot;
                case UIRootType.Windows:
                    return _windowsRoot;
                case UIRootType.None:
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}