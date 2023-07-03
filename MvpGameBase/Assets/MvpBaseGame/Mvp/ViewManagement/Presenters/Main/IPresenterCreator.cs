namespace MvpBaseGame.Mvp.ViewManagement.Presenters.Main
{
    public interface IPresenterCreator
    {
        IPresenter CreatePresenter(IView view, object payload = null);
        void DestroyPresenter(IView view);
    }
}