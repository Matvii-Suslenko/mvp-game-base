using System;
using System.Collections.Generic;
using Zenject;

namespace MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl
{
    public class PresenterBinding : IPresenterBinding
    {
        private readonly IPresenterFactory _presenterFactory;
        private readonly IInstantiator _instantiator;
        private readonly Dictionary<IView, IPresenter<IView>> _allPresenters;
        private Type _presenterType;
        
        public PresenterBinding(IPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory;
            _allPresenters = new Dictionary<IView, IPresenter<IView>>();
        }

        public IPresenter<IView> GetPresenter(IView view)
        {
            _allPresenters.TryGetValue(view, out var presenter);
            return presenter;
        }

        public IPresenter CreatePresenter(IView view, object payload = null)
        {
            if (_allPresenters.ContainsKey(view))
            {
                throw new Exception($"Presenter for this view {view.GetType()} already exists");
            }

            var presenter = _presenterFactory.Create(_presenterType, view, payload);
            presenter.Initialize();
            _allPresenters.Add(view, presenter);
            return presenter;
        }

        public void DestroyPresenter(IView view)
        {
            if (_allPresenters.TryGetValue(view, out var presenter))
            {
                presenter.Dispose();
                _allPresenters.Remove(view);
            }
        }

        public void ToPresenter<TConcrete>() where TConcrete : IPresenter<IView>
        {
            _presenterType = typeof(TConcrete);
        }

        public void Dispose() 
        {
            foreach (var binding in _allPresenters.Values)
            {
                binding.Dispose();
            }
            _allPresenters.Clear();
        }
    }
}