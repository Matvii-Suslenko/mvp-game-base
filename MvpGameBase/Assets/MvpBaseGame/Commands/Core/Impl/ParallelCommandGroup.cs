using MvpBaseGame.Commands.Groups;
using System.Collections.Generic;
using MvpBaseGame.Promises;
using System.Linq;
using System;

namespace MvpBaseGame.Commands.Core.Impl
{
    public class ParallelGroupCommand : AsyncBaseCommand
    {
        private readonly IGroupCommandInfo _groupCommandInfo;
        private readonly ICommandFactory _commandFactory;
        private IEnumerable<ICommandInfo> _commandTypes;
        private int _countReleased;
        private bool _isCommandAborted;
        private ICommand[] _createdCommands;
        private IPromise[] _commandPromises;
        
        public ParallelGroupCommand(IGroupCommandInfo groupCommandInfo, ICommandFactory commandFactory)
        {
            _groupCommandInfo = groupCommandInfo;
            _commandFactory = commandFactory;
        }

        public override IPromise Execute(ICommandPayload args)
        {
            _countReleased = 0;
            _isCommandAborted = false;
            _commandTypes = _groupCommandInfo.Types.ToArray();
            _createdCommands = new ICommand[_commandTypes.Count()];
            _commandPromises = new IPromise[_commandTypes.Count()];
            
            var index = 0;
            foreach (var commandType in _commandTypes)
            {
                _createdCommands[index++] = _commandFactory.Create(commandType);
            }

            _countReleased = _createdCommands.Length;
            index = 0;
            foreach (var command in _createdCommands)
            {
                if (_isCommandAborted)
                {
                    break;
                }
                
                var commandPromise = command.Execute(args);
                _commandPromises[index++] = commandPromise;
                commandPromise.Then(OnParallelCommandReleased).Fail(OnParallelCommandAborted);
            }

            Complete();
            return Outcome;
        }

        private void OnParallelCommandAborted(Exception exception)
        {
            if (_isCommandAborted)
            {
                return;
            }

            _isCommandAborted = true;
            DisposeAllCommands(true);
            Abort(exception);
        }
        
        private void OnParallelCommandReleased()
        {
            _countReleased--;
            Complete();
        }

        private void Complete()
        {
            if (_countReleased == 0 && !_isCommandAborted)
            {
                DisposeAllCommands(false);
                Release();
            }
        }
        
        private void DisposeAllCommands(bool abortCommandPromises)
        {
            foreach (var promise in _commandPromises)
            {
                if (promise == null)
                {
                    continue;
                    
                }

                promise.RemoveAllListeners();
                
                if (abortCommandPromises && promise.CanBeAborted)
                {
                    promise.Abort();
                }
            }
            
            foreach (var command in _createdCommands)
            {
                command.Dispose();
            }
            
            _createdCommands = Array.Empty<ICommand>();
            _commandPromises = Array.Empty<IPromise>();
        }
        
        public override void Dispose()
        {
            DisposeAllCommands(true);
            base.Dispose();
        }
    }
}
