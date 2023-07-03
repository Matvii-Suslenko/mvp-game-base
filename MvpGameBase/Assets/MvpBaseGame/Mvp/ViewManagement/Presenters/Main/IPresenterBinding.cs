using System;

namespace MvpBaseGame.Mvp.ViewManagement.Presenters.Main
{
    public interface IPresenterBinding : IDisposable, IPresenterCreator
    {
        IPresenter<IView> GetPresenter(IView view);
        void ToPresenter<TConcrete>() where TConcrete : IPresenter<IView>;
    }
}