using MvpBaseGame.Commands.Groups;

namespace MvpBaseGame.Commands.Core
{
    public interface ICommandBinding
    {
        IGroupCommandInfo CommandInfo { get; }
    }

    public interface ICommandBinding<in TContract> : ICommandBinding
    {
        /// <summary>
        /// True if Command Can be Aborted
        /// </summary>
        bool CanBeAborted { get; }
        
        ICommandBinding<TContract> ToCommand<TConcrete>(params object[] args) where TConcrete : TContract, ICommand;
        
        /// <summary>
        /// Prevents Command From Being Aborted
        /// </summary>
        /// <returns></returns>
        ICommandBinding<TContract> NoAbort();
    }
}