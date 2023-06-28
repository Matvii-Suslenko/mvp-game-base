using System.Collections.Generic;
using System;

namespace MvpBaseGame.Commands.Groups
{
    internal interface ISingleCommandInfo : ICommandInfo
    {
        Type Type { get; }
        IEnumerable<object> Args { get; }
    }
}
