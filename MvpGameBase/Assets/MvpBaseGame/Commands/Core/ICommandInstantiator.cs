using System.Collections.Generic;
using System;

namespace MvpBaseGame.Commands.Core
{
    internal interface ICommandInstantiator
    {
        ICommand Instantiate(Type concreteType);
    
        ICommand Instantiate(Type concreteType, IEnumerable<object> extraArgs);
    
        ICommand Instantiate<T>() where T : ICommand;
    
        ICommand Instantiate<T>(IEnumerable<object> extraArgs) where T : ICommand;
    }
}
