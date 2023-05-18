using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.UI.Base
{
    public abstract class UIViewBase : MonoBehaviour, IUIView
    {
        public abstract void Initialize();

        public abstract void Show();

        public abstract void Close();

        public abstract void Dispose();
    }
}