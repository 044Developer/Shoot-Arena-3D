using ShootArena.Infrastructure.MonoComponents.UI.Base;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.MainMenu.Mediator
{
    public interface IMainMenuMediator : IUIMediator
    {
        void Initialize();
        void Execute();
        void OnPanelClosed();
        void OnPlayButtonClicked();
        void OnGitHubButtonClicked();
        void OnLinkedInButtonClicked();
        void OnTelegramButtonClicked();
    }
}