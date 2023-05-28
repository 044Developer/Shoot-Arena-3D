using ShootArena.Infrastructure.MonoComponents.UI.Root.Data;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.UI.Root
{
    public interface IUIRoot
    {
        public RectTransform GetRootByType(UIRootType type);
    }
}