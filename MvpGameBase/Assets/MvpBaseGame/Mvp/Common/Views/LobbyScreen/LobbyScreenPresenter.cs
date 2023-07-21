using MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl;

namespace MvpBaseGame.Mvp.Common.Views.LobbyScreen
{
    public class LobbyScreenPresenter : Presenter<ILobbyScreenView>
    {
        public LobbyScreenPresenter(ILobbyScreenView view) : base(view)
        {
        }

        public override void Initialize()
        {
            
        }

        public override void Dispose()
        {
            
        }
    }
}