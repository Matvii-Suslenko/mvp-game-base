using System;

namespace MvpBaseGame.Mvp.ViewManagement.Presenters.Main
{
    public interface IPresenterBinder
    {
        IPresenterBinding BindView<TContract>() where TContract : IView;
        void UnBind<TContract>() where TContract : IView;
        IPresenterBinding GetBind<TContract>() where TContract : IView;
        IPresenterBinding GetBind(Type type);
        bool HasBind(Type type);
    }
}