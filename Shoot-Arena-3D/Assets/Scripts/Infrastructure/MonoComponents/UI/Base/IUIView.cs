namespace ShootArena.Infrastructure.MonoComponents.UI.Base
{
    public interface IUIView
    {
        public void Initialize();
        public void Show();
        public void Close();
        public void Dispose();
    }
}