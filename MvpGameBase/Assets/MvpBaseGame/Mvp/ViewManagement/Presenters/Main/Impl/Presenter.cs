namespace MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl
{
    public abstract class Presenter<TView> : IPresenter<TView> where TView : IView
    {
        protected TView View { get; }

        protected Presenter(TView view)
        {
            View = view;
        }

        public abstract void Initialize();
        public abstract void Dispose();
    }
}