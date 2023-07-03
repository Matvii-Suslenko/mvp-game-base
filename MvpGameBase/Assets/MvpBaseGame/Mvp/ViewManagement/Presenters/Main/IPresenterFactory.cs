using System;

namespace MvpBaseGame.Mvp.ViewManagement.Presenters.Main
{
    public interface IPresenterFactory
    {
        IPresenter<IView> Create(Type type, IView view, object payload);
    }
}