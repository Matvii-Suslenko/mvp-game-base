using MvpBaseGame.Commands.Groups.Impl;
using MvpBaseGame.Commands.Groups;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MvpBaseGame.Commands.Core.Impl
{
    internal class CommandFactory : ICommandFactory
    {
        private readonly ICommandInstantiator _commandInstantiator;
        
        public CommandFactory(ICommandInstantiator commandInstantiator)
        {
            _commandInstantiator = commandInstantiator;
        }
        
        public ICommand Create(ICommandInfo commandInfo)
        {
            if (commandInfo is IGroupCommandInfo groupCommandInfo)
            {
                if (groupCommandInfo.Types.Count() == 1)
                {
                    return Create(groupCommandInfo.Types.First());
                }
                
                if (groupCommandInfo.GroupType == CommandGroupType.Parallel)
                {
                    return _commandInstantiator.Instantiate<ParallelGroupCommand>(new object[] {groupCommandInfo});
                }
                
                if (groupCommandInfo.GroupType == CommandGroupType.Sequence)
                {
                    return _commandInstantiator.Instantiate<SequenceGroupCommand>(new object[] {groupCommandInfo});
                }

                throw new ArgumentOutOfRangeException($"Command Factory: Can NOT Handle Command Group Type: {groupCommandInfo.GroupType}");
            }
            
            if (commandInfo is ISingleCommandInfo singleCommandInfo)
            {
                return CreateCommand(singleCommandInfo.Type, singleCommandInfo.Args);
            }
            
            throw new ArgumentException($"Command with type:{commandInfo} is null");
        }

        private ICommand CreateCommand(Type type, IEnumerable<object> args = null)
        {
            if (args == null)
            {
                return _commandInstantiator.Instantiate(type);
            }

            return _commandInstantiator.Instantiate(type, args);
        }
    }
}
