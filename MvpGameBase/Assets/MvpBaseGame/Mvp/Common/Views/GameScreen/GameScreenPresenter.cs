using MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core;

namespace MvpBaseGame.Mvp.Common.Views.GameScreen
{
    public class GameScreenPresenter : Presenter<IGameScreenView>
    {
        private readonly IViewManager _viewManager;

        public GameScreenPresenter(
            IGameScreenView view,
            IViewManager viewManager) : base(view)
        {
            _viewManager = viewManager;
        }

        public override void Initialize()
        {
            // TODO remove after testing
            View.DeviceBackClicked += OnDeviceBack;
        }

        // TODO remove after testing
        private void OnDeviceBack()
        {
            _viewManager.OpenView(ViewNames.Paused);
        }

        public override void Dispose()
        {
            View.DeviceBackClicked -= OnDeviceBack;
        }
    }
}
