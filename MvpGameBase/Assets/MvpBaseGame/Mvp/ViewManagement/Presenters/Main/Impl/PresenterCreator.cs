namespace MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl
{
    public class PresenterCreator : IPresenterCreator
    {
        private readonly IPresenterBinder _presenterBinder;

        public PresenterCreator(IPresenterBinder presenterBinder)
        {
            _presenterBinder = presenterBinder;
        }
        public IPresenter CreatePresenter(IView view, object payload = null)
        {
            var type = view.GetType();
            if (_presenterBinder.HasBind(type))
            {
                var binding = _presenterBinder.GetBind(type);
                return binding.CreatePresenter(view, payload);
            }

            return null;
        }

        public void DestroyPresenter(IView view)
        {
            var type = view.GetType();
            if (_presenterBinder.HasBind(type))
            {
                var binding = _presenterBinder.GetBind(type);
                binding.DestroyPresenter(view);
            }
        }
    }
}