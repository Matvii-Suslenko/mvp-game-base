using System.Collections.Generic;
using MvpBaseGame.Promises;

namespace MvpBaseGame.Commands.Core.Impl
{
    internal class CommandController : ICommandController, ICommandAborter
    {
        private readonly ICommandBinder _binder;
        private readonly ICommandFactory _commandFactory;
        private readonly List<IAbortable> _commandsToAbort = new List<IAbortable>();
        
        public CommandController(
            ICommandBinder binder,
            ICommandFactory commandFactory)
        {
            _binder = binder;
            _commandFactory = commandFactory;
        }

        public IPromise Execute<TTrigger>() where TTrigger : ICommand
        {
            var command = CreateCommand<TTrigger>();
            
            var promise = command.Execute(null);
            promise.Finally(() =>
            {
                RemoveCommandFromAbortingList(command);
                command.Dispose();
            });
            
            return promise;
        }

        public IPromise Execute<TTrigger>(ICommandPayload data) where TTrigger : ICommand<ICommandPayload>
        {
            var command = CreateCommand<TTrigger>();
            
            var promise = command.Execute(data);
            promise.Finally(() =>
            {
                RemoveCommandFromAbortingList(command);
                command.Dispose();
            });
            
            return promise;
        }

        private void RemoveCommandFromAbortingList(ICommand command)
        {
            if (command is IAbortable commandToAbort)
            {
                _commandsToAbort.Remove(commandToAbort);
            }
        }
        
        private ICommand CreateCommand<TTrigger>()
        {
            var binder = _binder.GetBind<TTrigger>();
            var commandInfo = binder.CommandInfo;
            var command = _commandFactory.Create(commandInfo);
            
            if(binder.CanBeAborted && command is IAbortable commandToAbort)
            {
                _commandsToAbort.Add(commandToAbort);
            }
            
            return command;
        }

        public void AbortRunningCommands()
        {
            for (var i = _commandsToAbort.Count - 1; i >= 0; i--)
            {
                _commandsToAbort[i].Abort();
            }
        }
    }
}
