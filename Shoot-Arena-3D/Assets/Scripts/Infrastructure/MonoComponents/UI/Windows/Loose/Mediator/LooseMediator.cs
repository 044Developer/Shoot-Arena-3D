using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.ViewModel;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.Mediator
{
    public class LooseMediator : ILooseMediator
    {
        private ILooseViewModel _viewModel = null;
        
        public void SetModel(IUIViewModel viewModel)
        {
            _viewModel = viewModel as ILooseViewModel;
        }

        public void OnRestartButtonClicked()
        {
        }

        public void OnExitButtonClicked()
        {
        }
    }

    public interface ILooseMediator : IUIMediator
    {
        void OnRestartButtonClicked();
        void OnExitButtonClicked();
    }
}