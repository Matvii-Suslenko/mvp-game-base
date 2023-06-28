using System.Collections.Generic;
using Zenject;
using System;

namespace MvpBaseGame.Commands.Core.Impl
{
    internal class CommandInstantiator : ICommandInstantiator
    {
        private readonly IInstantiator _instantiator;

        public CommandInstantiator(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }
        
        public ICommand Instantiate(Type concreteType)
        {
            return _instantiator.Instantiate(concreteType) as ICommand ??
                   throw GetFormattedException(concreteType);        
        }

        public ICommand Instantiate(Type concreteType, IEnumerable<object> extraArgs)
        {
            return _instantiator.Instantiate(concreteType, extraArgs) as ICommand ??
                   throw GetFormattedException(concreteType);        
        }

        public ICommand Instantiate<T>() where T : ICommand
        {
            return _instantiator.Instantiate<T>();
        }

        public ICommand Instantiate<T>(IEnumerable<object> extraArgs) where T : ICommand
        {
            return _instantiator.Instantiate<T>(extraArgs);
        }
        
        private static Exception GetFormattedException(Type concreteType)
        {
            return new ArgumentException(
                $"Argument {nameof(concreteType)} does not implement {nameof(ICommand)} value: {concreteType.Name}");
        }
    }
}
