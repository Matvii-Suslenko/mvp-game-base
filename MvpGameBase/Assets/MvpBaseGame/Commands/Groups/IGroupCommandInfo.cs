using MvpBaseGame.Commands.Groups.Impl;
using System.Collections.Generic;
using MvpBaseGame.Commands.Core;
using System;

namespace MvpBaseGame.Commands.Groups
{
    public interface IGroupCommandInfo : ICommandInfo
    {
        CommandGroupType GroupType { get; }
        IEnumerable<ICommandInfo> Types { get; }
        IGroupCommandInfo Add<T>(params object[] args) where T : ICommand;
        IGroupCommandInfo Add(Type type, params object[] args);
        IGroupCommandInfo Add(ICommandInfo info);
    }
}
