using MvpBaseGame.Commands.Groups.Impl;
using MvpBaseGame.Commands.Groups;

namespace MvpBaseGame.Commands.Core.Impl
{
    internal class CommandBinding<TContract> : ICommandBinding<TContract>
    {
        public IGroupCommandInfo CommandInfo => _commandGroupInfo;
        public bool CanBeAborted { get; private set; } = true;
        private IGroupCommandInfo _commandGroupInfo;
        
        public ICommandBinding<TContract> ToCommand<TConcrete>(params object[] args) where TConcrete : TContract, ICommand
        {
            _commandGroupInfo ??= new GroupCommandInfo(CommandGroupType.Sequence);
            _commandGroupInfo.Add<TConcrete>(args);
            return this;
        }

        public ICommandBinding<TContract> NoAbort()
        {
            CanBeAborted = false;
            return this;
        }
    }
}
