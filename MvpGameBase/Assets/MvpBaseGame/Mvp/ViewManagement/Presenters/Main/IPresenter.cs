using System;

namespace MvpBaseGame.Mvp.ViewManagement.Presenters.Main
{
    public interface IPresenter<out TView> : IPresenter where TView : IView
    {
    }

    public interface IPresenter : IDisposable
    {
      void Initialize();
    }
}
