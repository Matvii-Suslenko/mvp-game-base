using MvpBaseGame.Commands.Groups;

namespace MvpBaseGame.Commands.Core
{
    public interface ICommandFactory
    {
        ICommand Create(ICommandInfo commandInfo);
    }
}
