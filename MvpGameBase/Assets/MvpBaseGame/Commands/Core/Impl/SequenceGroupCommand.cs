using MvpBaseGame.Commands.Groups;
using MvpBaseGame.Promises;
using System.Linq;
using System;

namespace MvpBaseGame.Commands.Core.Impl
{
    public class SequenceGroupCommand : AsyncBaseCommand
    {
        private readonly IGroupCommandInfo _groupCommandInfo;
        private readonly ICommandFactory _commandFactory;
        private ICommandPayload _args;
        private ICommand _activeCommand;
        private int _index;
        private ICommandInfo[] _commandTypesArray;
        
        public SequenceGroupCommand(IGroupCommandInfo groupCommandInfo, ICommandFactory commandFactory)
        {
            _groupCommandInfo = groupCommandInfo;
            _commandFactory = commandFactory;
        }
        
        public sealed override IPromise Execute(ICommandPayload args)
        {
            _index = 0;
            _args = args;
            _commandTypesArray = _groupCommandInfo.Types.ToArray();
            ExecuteNext();
            return Outcome;
        }
        
        private void ExecuteNext()
        {
            if (_index < _commandTypesArray.Length)
            {
                _activeCommand = _commandFactory.Create(_commandTypesArray[_index++]);
                _activeCommand.Execute(_args).Then(OnReleased).Fail(OnAborted);
            }
            else
            {
                Release();
            }
        }
        
        private void OnReleased()
        {
            DisposeActiveCommand();
            ExecuteNext();
        }
        
        private void OnAborted(Exception exception)
        {
            DisposeActiveCommand();
            Abort(exception);
        }
        
        private void DisposeActiveCommand()
        {
            if (_activeCommand != null)
            {
                _activeCommand.Dispose();
            }
        }

        public override void Dispose()
        {
            DisposeActiveCommand();
            base.Dispose();
        }
    }
}