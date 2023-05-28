using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.UI.Base
{
    public abstract class UIViewBase : MonoBehaviour, IUIView
    {
        public virtual void Initialize()
        {
        }

        public virtual void Show()
        {
        }

        public virtual void Close()
        {
            Destroy(this.gameObject);
        }

        public virtual void Dispose()
        {
        }
    }
}