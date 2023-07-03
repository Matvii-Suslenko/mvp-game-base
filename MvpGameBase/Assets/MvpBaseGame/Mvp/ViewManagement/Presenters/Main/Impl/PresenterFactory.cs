using System;
using Zenject;

namespace MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl
{
    public class PresenterFactory : IPresenterFactory
    {
        private readonly IInstantiator _instantiator;

        public PresenterFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }
        
        public IPresenter<IView> Create(Type type, IView view, object payload)
        {
            object[] extraArgs;
            if (payload == null)
            {
                extraArgs = new object[] { view };
            }
            else
            {
                extraArgs = new object[] { view, payload };
            }
            
            var presenter = _instantiator.Instantiate(type, extraArgs) as IPresenter<IView>;
            
            return presenter;
        }
    }
}