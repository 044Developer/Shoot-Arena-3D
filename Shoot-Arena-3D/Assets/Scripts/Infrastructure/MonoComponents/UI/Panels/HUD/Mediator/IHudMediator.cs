using ShootArena.Infrastructure.MonoComponents.UI.Base;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.Mediator
{
    public interface IHudMediator : IUIMediator
    {
        void SetUpPanel();
        void OnUltButtonClick();
        void OnPauseButtonClick();
        void OnChangeHpValue();
        void OnChangeUltValue();
    }
}