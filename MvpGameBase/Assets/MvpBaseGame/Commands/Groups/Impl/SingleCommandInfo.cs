using System.Collections.Generic;
using System;

namespace MvpBaseGame.Commands.Groups.Impl
{
    internal sealed class SingleCommandInfo : ISingleCommandInfo
    {
        public Type Type { get; }
        public IEnumerable<object> Args { get; }
        
        public SingleCommandInfo(Type type, IEnumerable<object> args)
        {
            Type = type;
            Args = args;
        }
    }
}
