using ShootArena.Infrastructure.MonoComponents.UI.Base;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.Mediator
{
    public interface IHudMediator : IUIMediator
    {
        void OnFireButtonClick();
        void OnUltButtonClick();
        void OnChangeHpValue(float newValue);
        void OnChangeUltValue(float newValue);
    }
}