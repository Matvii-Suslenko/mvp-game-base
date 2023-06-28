using System.Collections.Generic;
using System;

namespace MvpBaseGame.Commands.Core.Impl
{
    internal class CommandBinder : ICommandBinder
    {
        private readonly Dictionary<Type, ICommandBinding> _bindings = new Dictionary<Type, ICommandBinding>();
        
        public ICommandBinding<TContract> Bind<TContract>()
        {
            var type = typeof(TContract);
            if (_bindings.ContainsKey(type))
            {
                throw new Exception($"Binding with such key: {type} already exists");
            }

            var binding = new CommandBinding<TContract>();
            _bindings.Add(type, binding);
            return binding;
        }

        public ICommandBinding<TContract> ReBind<TContract>()
        {
            UnBind<TContract>();
            return Bind<TContract>();
        }

        public void UnBind<TContract>()
        {
            UnBind(typeof(TContract));
        }
        
        private void UnBind(Type type)
        {
            if (_bindings.ContainsKey(type))
            {
                _bindings.Remove(type);
            }
        }
        
        public ICommandBinding<TContract> GetBind<TContract>()
        {
            var type = typeof(TContract);
            _bindings.TryGetValue(type, out var binding);
            if (binding == null)
            {
                throw new Exception($"No Binding with such key: {type}");
            }
            
            return binding as ICommandBinding<TContract>;
        }
    }
}
