using System;
using MvpBaseGame.Promises;

namespace MvpBaseGame.Commands.Core
{
    public interface ICommand : IDisposable
    {
        IPromise Execute(ICommandPayload args);
    }
    
    public interface ICommand<out T> where T : ICommandPayload
    {

    }
}
