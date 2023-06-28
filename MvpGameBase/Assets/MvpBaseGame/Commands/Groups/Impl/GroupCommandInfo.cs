using System.Collections.Generic;
using MvpBaseGame.Commands.Core;
using System;

namespace MvpBaseGame.Commands.Groups.Impl
{
    public class GroupCommandInfo : IGroupCommandInfo
    {
        public IEnumerable<ICommandInfo> Types => _commandTypes;
        public CommandGroupType GroupType { get; }
        
        private readonly List<ICommandInfo> _commandTypes;
        
        public GroupCommandInfo(CommandGroupType commandGroupType)
        {
            _commandTypes = new List<ICommandInfo>();
            GroupType = commandGroupType;
        }

        public IGroupCommandInfo Add<T>(params object[] args) where T : ICommand
        {
            return Add(typeof(T), args);
        }
        
        public IGroupCommandInfo Add(Type type, params object[] args)
        {
            return Add(new SingleCommandInfo(type, args));
        }
        
        public IGroupCommandInfo Add(ICommandInfo type)
        {
            _commandTypes.Add(type);
            return this;
        }
    }
}
