using System;
using System.Collections.Generic;

namespace MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl
{
    public class PresenterBinder : IPresenterBinder
    {
        private readonly IPresenterFactory _presenterFactory;
        private readonly Dictionary<Type, IPresenterBinding> _bindings = new Dictionary<Type, IPresenterBinding>();
        
        public PresenterBinder(IPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory;
        }
        
        public IPresenterBinding BindView<TContract>() where TContract:IView
        {
            var type = typeof(TContract);
            if (_bindings.ContainsKey(type))
            {
                throw new Exception($"Binding with such key: {type} already exists");
            }

            var binding = new PresenterBinding(_presenterFactory);
            _bindings.Add(type, binding);
            return binding;
        }
        
        public IPresenterBinding GetBind<TContract>() where TContract:IView
        {
            return GetBind(typeof(TContract));
        }

        public IPresenterBinding GetBind(Type type)
        {
            _bindings.TryGetValue(type, out var binding);
            if (binding == null)
            {
                throw new Exception($"No Binding with such key: {type}");
            }
            
            return binding;
        }
        
        public void UnBind<TContract>() where TContract:IView
        {
            UnBind(typeof(TContract));
        }
        
        private void UnBind(Type type)
        {
            if (_bindings.TryGetValue(type, out var binding))
            {
                binding.Dispose();
                _bindings.Remove(type);
            }
        }

        public bool HasBind(Type type)
        {
            _bindings.TryGetValue(type, out var binding);
            return binding != null;
        }
    }
}